using Core.DTOs;
using Core.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.IServices.IAuth
{
    public interface IAuthService
    {
        Task<GlobalResponse> GetAllUsers(Filter filter);
        Task<GlobalResponse> GetUserByIdAsync(Guid id);
        Task<GlobalResponse> UpdateUserAsync(Guid id, UpdateUser model);
        Task<GlobalResponse> ChangePassword(ChangePassword model);
        Task<GlobalResponse> SetNewPasswordToSpecificUserAsync(setNewPassword model);
        Task<GlobalResponse> LockOrUnlockUserAsync(LockUser model);
    }
}
