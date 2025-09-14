using Core.Constants;
using Core.DTOs;
using Core.DTOs.Auth;
using Core.Entities;
using Core.Entities.Auth;
using Core.Interfaces.IRepositories;
using Core.Interfaces.IServices.IAuth;
using Core.Interfaces.ISystemServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Core.DTOs.Auth.UserReadDTOs;

namespace Service.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IUserBasicData _userBasicData;
        //private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        public AuthService(IUnitOfWork unitOfWork, UserManager<User> userManager, IUserBasicData userBasicData)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _userBasicData = userBasicData;
        }

        public async Task<GlobalResponse> GetAllUsers(Filter filter)
        {
            if (_userBasicData.GetRoleName() != RoleName.Superadmin)
                return new GlobalResponse { IsSuccess = false, Message = "unAuthorized!", StatusCode = HttpStatusCode.Unauthorized };

            var usersQuery = await GettingUser(x =>
            (filter.Email == null || x.Email!.Contains(filter.Email))
                                      &&
                                      (filter.UserName == null || x.Name!.Contains(filter.UserName))).ToListAsync();

            var result = usersQuery.GroupBy(x => x.Id).Select(x => new UserReadDTOs.UserreadResponseDto
            {
                Id = x.Key,
                Email = x.Select(e => e.Email).FirstOrDefault(),
                Name = x.Select(n => n.Name).FirstOrDefault(),
                RoleNames = x.Select(r => r.RoleName),
                IsLocked = x.Select(i => i.IsLocked).FirstOrDefault(),
                LockedReason = x.Select(l => l.LockedReason).FirstOrDefault(),
                TrapIds = x.Select(t => t.TrapId).FirstOrDefault() != null ? x.Select(t => t.TrapId.Value) : null
            }).ToList();


            return new GlobalResponse<List<UserReadDTOs.UserreadResponseDto>> { Data = result, IsSuccess = true, StatusCode = HttpStatusCode.OK };

        }

        public async Task<GlobalResponse> GetUserByIdAsync(Guid id)
        {
            var userQuery = await GettingUser(x => x.Id == id).ToListAsync();

            if (userQuery is null)
                return new GlobalResponse { IsSuccess = false, Message = "User not found!", StatusCode = HttpStatusCode.NotFound };

            var result = userQuery.GroupBy(x => x.Id).Select(x => new UserReadDTOs.UserreadResponseDto
            {
                Id = x.Key,
                Email = x.Select(e => e.Email).FirstOrDefault(),
                Name = x.Select(n => n.Name).FirstOrDefault(),
                RoleNames = x.Select(r => r.RoleName),
                IsLocked = x.Select(i => i.IsLocked).FirstOrDefault(),
                LockedReason = x.Select(l => l.LockedReason).FirstOrDefault(),
                TrapIds = x.Select(t => t.TrapId).FirstOrDefault() != null ? x.Select(t => t.TrapId.Value) : null
            }).FirstOrDefault();

            return new GlobalResponse<UserReadDTOs.UserreadResponseDto> { Data = result, IsSuccess = true, StatusCode = HttpStatusCode.OK };
        }

        public async Task<GlobalResponse> UpdateUserAsync(Guid id, UpdateUser model)
        {
            if (model.Id != id)
            {
                return new GlobalResponse<UpdateUser>()
                {
                    Data = model,
                    Message = "Must provide user id!",
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return new GlobalResponse<UpdateUser>()
                {
                    Data = model,
                    Message = "User Not Found!",
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound
                };
            }


            try
            {

                // Can't update superadmin
                if (await _userManager.IsInRoleAsync(user, RoleName.Superadmin))
                {
                    return new GlobalResponse<UpdateUser>()
                    {
                        Data = model,
                        Message = "Can't update this user!",
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest

                    };
                }

                if (_userBasicData.GetRoleName() == RoleName.Superadmin /*|| user.ParentUserId == _userBasicData.GetUserId()*/)
                {
                    await _unitOfWork.BeginTransactionAsync();
                    user.Email = model.Email;
                    user.Name = model.UserName;

                    await _userManager.UpdateAsync(user);
                    var traps = await _unitOfWork.UserTrapsRepository.GetAllQueryable().Where(n => n.UserId == user.Id).ToListAsync();

                    _unitOfWork.UserTrapsRepository.DeleteRangeAsync(traps);
                    if (!await _unitOfWork.SaveChangesAsync())
                    {
                        await _unitOfWork.RollbackTransactionAsync();
                        return new GlobalResponse { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest, Message = "#1 Faild to upodate!" };
                    }


                    await _unitOfWork.UserTrapsRepository.AddRangeAsync(model.TrapIds.Select(trapId => new UserTraps
                    {
                        TrapId = trapId,
                        UserId = user.Id
                    }));
                    if (!await _unitOfWork.SaveChangesAsync())
                    {
                        await _unitOfWork.RollbackTransactionAsync();
                        return new GlobalResponse
                        {
                            IsSuccess = false,
                            StatusCode = HttpStatusCode.BadRequest,
                            Message = "#2 Faild to upodate!"
                        };
                    }
                }
                else
                {

                    return new GlobalResponse
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Can't update this user!"
                    };
                }
                return new GlobalResponse()
                {
                    IsSuccess = true,
                    Message = "Updated",
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {

                return new GlobalResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message + (ex.InnerException == null ? string.Empty : ex.InnerException.Message)
                };
            }
        }

        public async Task<GlobalResponse> ChangePassword(ChangePassword model)
        {
            if (model.NewPassWord != model.ConfirmNewPassWord)
                return new GlobalResponse() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest, Message = "Check password and confirm password!" };

            var user = await _userManager.FindByIdAsync(model.User_Id);
            if (user == null)
                return new GlobalResponse() { IsSuccess = false, StatusCode = HttpStatusCode.NotFound, Message = "User not found!" };

            var passwordCheck = await _userManager.CheckPasswordAsync(user, model.OldPassWord);

            if (!passwordCheck)
                return new GlobalResponse() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest, Message = "Old password not correct!" };

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassWord, model.ConfirmNewPassWord);

            if (!result.Succeeded)
                return new GlobalResponse() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest, Message = "Couldn't update the password!" };

            return new GlobalResponse { IsSuccess = true, Message = "Password changed successfully!", StatusCode = HttpStatusCode.OK };
        }

        public async Task<GlobalResponse> SetNewPasswordToSpecificUserAsync(setNewPassword model)
        {
            if (_userBasicData.GetRoleName() != RoleName.Superadmin)
                return new GlobalResponse() { IsSuccess = false, StatusCode = HttpStatusCode.Unauthorized, Message = "Unauthorized!" };

            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return new GlobalResponse() { IsSuccess = false, StatusCode = HttpStatusCode.NotFound, Message = "User not found!" };

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);

            _unitOfWork.Users.Update(user);

            if (!result.Succeeded)
                return new GlobalResponse() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest, Message = "Faild to change password!" };

            return new GlobalResponse { IsSuccess = true, Message = "Password changed successfully!", StatusCode = HttpStatusCode.OK };
        }

        public async Task<GlobalResponse> LockOrUnlockUserAsync(LockUser model)
        {
            if (_userBasicData.GetRoleName() != RoleName.Superadmin)
                return new GlobalResponse() { IsSuccess = false, StatusCode = HttpStatusCode.Unauthorized, Message = "Unauthorized!" };

            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
                return new GlobalResponse() { IsSuccess = false, StatusCode = HttpStatusCode.NotFound, Message = "User not found!" };

            user.IsLocked = model.IsLocked;
            user.LockReason = model.IsLocked ? model.Reason : null;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return new GlobalResponse { Message = model.IsLocked ? "Failed to lock user" : "Failed to unlock user", IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };

            return new GlobalResponse { IsSuccess = true, Message = model.IsLocked ? "User locked successfully" : "User unlocked successfully", StatusCode = HttpStatusCode.OK };
        }



        // Helpers
        private IQueryable<UserreadRequestDto> GettingUser(Expression<Func<UserreadRequestDto, bool>> condition)
        {
            var query = from users in _unitOfWork.Users.GetAllQueryableAsNoTracking()

                        join userTraps in _unitOfWork.UserTrapsRepository.GetAllQueryableAsNoTracking() on users.Id equals userTraps.UserId into joinedUserTraps
                        from userTraps in joinedUserTraps.DefaultIfEmpty()

                        join traps in _unitOfWork.TrapRepository.GetAllQueryableAsNoTracking() on userTraps.TrapId equals traps.Id into joinedTraps
                        from traps in joinedTraps.DefaultIfEmpty()

                        join userRoles in _unitOfWork.UserRolesrepository.GetAllQueryableAsNoTracking() on users.Id equals userRoles.UserId into joinedUserRoles
                        from userRoles in joinedUserRoles.DefaultIfEmpty()

                        join roles in _unitOfWork.RoleRepository.GetAllQueryableAsNoTracking() on userRoles.RoleId equals roles.Id

                        select new UserReadDTOs.UserreadRequestDto
                        {
                            Id = users.Id,
                            Email = users.Email,
                            Name = users.UserName,
                            RoleId = roles.Id,
                            RoleName = roles.Name,
                            IsLocked = users.IsLocked,
                            LockedReason = users.LockReason,
                            TrapId = traps.Id
                        };
            query = query.Where(condition);
            return query;
        }

    }
}
