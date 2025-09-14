using Core.Constants;
using Core.DTOs;
using Core.DTOs.Auth;
using Core.Entities.Auth;
using Core.Interfaces.IRepositories;
using Core.Interfaces.IServices.IAuth;
using Core.Interfaces.ISystemServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace API.Controllers.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Auth")]
    [Area("Auth")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;
        private readonly IUserBasicData _userBasicData;
        private readonly IUnitOfWork _unitOfWork;

        public AuthController(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager, IConfiguration configuration,
            IAuthService authService, IUserBasicData userBasicData, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _authService = authService;
            _userBasicData = userBasicData;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("CreateUser02")]
        public async Task<ActionResult<GlobalResponse>> CreateUser02(RegisterDto02 registerDto, string role = "user")
        {
            string msg = "";
            User user = await _userManager.FindByEmailAsync(registerDto.Email);

            if (user is not null)
                return new GlobalResponse<User>() { IsSuccess = false, Message = "Email is already exists" };

            user = await _userManager.FindByNameAsync(registerDto.UserName);
            if (user is not null)
                return BadRequest(new GlobalResponse { IsSuccess = false, Message = "Username is already exists" });

            user = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                Name = registerDto.UserName
            };

            var res = await _userManager.CreateAsync(user, registerDto.Password);

            if (!res.Succeeded)
            {
                foreach (var error in res.Errors)
                {
                    msg = string.Join(";", error.Description);
                }
                return BadRequest(new GlobalResponse { IsSuccess = false, Message = msg });
            }

            bool isRoleExists = await _roleManager.RoleExistsAsync(role);

            if (!isRoleExists)
                await _roleManager.CreateAsync(new IdentityRole<Guid> { Name = role });


            await _userManager.AddClaimsAsync(user, new List<Claim> {
                new Claim(ClaimTypes.Role,role),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            });

            await _userManager.AddToRoleAsync(user, role);


            return Ok(new GlobalResponse<User> { IsSuccess = true, Message = msg, Data = new() { UserName = user.UserName, Email = user.Email } });

        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<GlobalResponse>> CreateUser(RegisterDto registerDto)
        {
            string msg = "";
            string role = "";
            User user = await _userManager.FindByEmailAsync(registerDto.Email);

            if (user is not null)
                return new GlobalResponse<User>() { IsSuccess = false, Message = "Email is already exists" };

            user = await _userManager.FindByNameAsync(registerDto.UserName);
            if (user is not null)
                return BadRequest(new GlobalResponse { IsSuccess = false, Message = "Username is already exists" });

            user = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Name = registerDto.UserName
            };
            //user.UserTraps = registerDto.TrapIds.Distinct().Select(x => new Core.Entities.UserTraps { TrapId = x });

            user.EmailConfirmed = true;
            user.ParentUserId = _userBasicData.GetRoleName() == RoleName.User ? _userBasicData.GetUserId() : null;
            var res = await _userManager.CreateAsync(user, registerDto.Password);


            if (res.Succeeded)
            {
                if (user.ParentUserId == null)
                    role = RoleName.User;
                else
                    role = RoleName.UserChild;
            }
            else
            {
                foreach (var error in res.Errors)
                {
                    msg = string.Join(";", error.Description);
                }
                return BadRequest(new GlobalResponse { IsSuccess = false, Message = msg });
            }

            // adding user traps
            await _unitOfWork.UserTrapsRepository.AddRangeAsync(registerDto.TrapIds.Select(c => new Core.Entities.UserTraps { TrapId = c, UserId = user.Id }));

            await _userManager.AddToRoleAsync(user, role);

            await _userManager.AddClaimsAsync(user, new List<Claim> {
                new Claim(ClaimTypes.Role,role),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            });

            return Ok(new GlobalResponse<User> { IsSuccess = true, Message = msg, Data = new() { UserName = user.UserName, Email = user.Email } });
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult<GlobalResponse>> Login([FromBody] SigninDTOs.Request request)
        {
            User user = await _userManager.FindByNameAsync(request.UserNameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);

            if (user == null)
                return BadRequest(new GlobalResponse { IsSuccess = false, Message = "invalid username or password" });

            if (user.IsLocked)
                return new GlobalResponse { IsSuccess = false, Message = "Access Denied!", StatusCode = HttpStatusCode.BadRequest };

            var checkPassword = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!checkPassword)
                return BadRequest(new GlobalResponse { IsSuccess = false, Message = "invalid username or password" });

            //return new GlobalResponse<User> { Data = user, IsSuccess = true, Message = "Logged in!" };

            var claims = await _userManager.GetClaimsAsync(user);
            string audience = _configuration.GetSection("JWT").GetValue<string>("Audience");
            string issuer = _configuration.GetSection("JWT").GetValue<string>("Issuer");
            string role = _userManager.GetRolesAsync(user).Result.FirstOrDefault();

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("JWT").GetValue<string>("SecretKey")));
            DateTime expireyDateTime = DateTime.Now.AddDays(15);
            string token =
                new JwtSecurityTokenHandler().WriteToken(
                new JwtSecurityToken(
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(key, SecurityAlgorithms.HmacSha256),
                audience: audience,
                issuer: issuer,
                expires: expireyDateTime,
                claims: claims
                ));

            return Ok(new GlobalResponse<SigninDTOs.Response>
            {
                IsSuccess = true,
                Message = "Loggedin",
                StatusCode = HttpStatusCode.OK,
                Data = new SigninDTOs.Response
                {
                    Email = user.Email,
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = token,
                    ExpiresOn = expireyDateTime,
                    IsLocked = false,
                    Role = role
                }
            });
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<GlobalResponse>> GetAllUsers([FromQuery] Filter filter)
        {
            var res = await _authService.GetAllUsers(filter);

            if (!res.IsSuccess)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<GlobalResponse>> GetUserByIdAsync(Guid id)
        {
            var res = await _authService.GetUserByIdAsync(id);

            if (!res.IsSuccess)
                return NotFound(res);
            return Ok(res);
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<ActionResult<GlobalResponse>> UpdateUserAsync(Guid id, UpdateUser model)
        {
            var res = await _authService.UpdateUserAsync(id, model);
            if (!res.IsSuccess)
            {
                if (res.StatusCode == HttpStatusCode.NotFound)
                    return NotFound(res);
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPut("ChangePassword")]
        public async Task<ActionResult<GlobalResponse>> ChangePasswordAsync(ChangePassword model)
        {
            var response = await _authService.ChangePassword(model);
            if (!response.IsSuccess)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                    return NotFound(response);
                return BadRequest(response);
            }
            return Ok(response);

        }

        [HttpPut("SetNewPasswordToSpecificUser")]
        public async Task<ActionResult<GlobalResponse>> SetNewPasswordToSpecificUserAsync(setNewPassword model)
        {
            var response = await _authService.SetNewPasswordToSpecificUserAsync(model);
            if (!response.IsSuccess)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                    return NotFound(response);
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("LockOrUnlockUser")]
        public async Task<ActionResult<GlobalResponse>> LockOrUnlockUserAsync(LockUser model)
        {
            var response = await _authService.LockOrUnlockUserAsync(model);
            if (!response.IsSuccess)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                    return NotFound(response);
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
