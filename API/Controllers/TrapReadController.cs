using Core.Constants;
using Core.DTOs;
using Core.DTOs.Trap.Statistic;
using Core.DTOs.Trap.TrapRead;
using Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "General")]
    [Area("General")]
    public class TrapReadController : ControllerBase
    {
        private readonly ITrapReadService _trapReadService;
        public TrapReadController(ITrapReadService trapReadService)
        {
            _trapReadService = trapReadService;
        }

        [HttpPost("CreateTrapReading")]
        [AllowAnonymous]
        public async Task<ActionResult<GlobalResponse>> CreateTrapReading(ReadDetailsCreateDto dto)
        {
            var res = await _trapReadService.CreateTrapReading(dto);
            if (!res.IsSuccess)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpGet("GetAllTrapReadings")]
        [Authorize(Roles = $"{RoleName.Superadmin},{RoleName.SuperVisor},{RoleName.User}")]
        public async Task<ActionResult<GlobalResponse>> GetAllTrapReadingsAsync([FromQuery] ReadRequestDto model)
        {
            var res = await _trapReadService.GetAllTrapReadingsAsync(model);
            if (!res.IsSuccess)
                return BadRequest(res);
            return Ok(res);
        }


        [HttpGet("GetStatisticsOfTrapsOnlyCurrentUser")]
        [Authorize]
        public async Task<ActionResult<GlobalResponse<StatisticsDto>>> GetStatisticsOfTrapsOnlyCurrentUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new GlobalResponse<StatisticsDto> { IsSuccess = false, Message = "User not authenticated", StatusCode = System.Net.HttpStatusCode.Unauthorized });
            }

            var result = await _trapReadService.GetUserTrapStatistics(Guid.Parse(userId));
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

<<<<<<< HEAD
        [Authorize(Roles = $"{RoleName.Superadmin},{RoleName.User},{RoleName.UserChild},{RoleName.SuperVisor}")]
        [HttpGet("GetTrapsLastRead")]
        public async Task<ActionResult<GlobalResponse>> GetLastReadingToCurrentUserTrapsAsync(int? trapId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new GlobalResponse<StatisticsDto> { IsSuccess = false, Message = "User not authenticated", StatusCode = System.Net.HttpStatusCode.Unauthorized });
            }
            var result = await _trapReadService.GetTrapsLastRead(trapId);
            if (!result.IsSuccess)
=======
        [HttpGet("GetCountOfMosuqitoesToLast12Months")]
        [Authorize]
        public async Task<ActionResult<MonthlyMosquitoCountResponseDto>> GetCountOfMosuqitoesToLast12Months()
        {
            var result = await _trapReadService.GetCountOfMosuqitoesToLast12Months();
            if (!result.isSuccess)
>>>>>>> 6dc54f52fc3abb17fb486d0ee41845f0bfc02dbb
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("GetCountOfMosuqitoesPer6Month")]
        [Authorize]
        public async Task<ActionResult<GlobalResponse<List<MonthlyMosquitoCountPer6MonthDto>>>> GetCountOfMosuqitoesPer6Month()
        {

            var result = await _trapReadService.GetCountOfMosuqitoesPer6Month();
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("GetMosquitoStatisticsLast6Months")]
        [Authorize]
        public async Task<ActionResult<Response<IEnumerable<GetCountOfMosuqitoesPer6MonthResponse>>>> GetMosquitoStatisticsLast6Months()
        {
            var result = await _trapReadService.GetMosquitoStatisticsLast6Months();
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

     

    }
}
