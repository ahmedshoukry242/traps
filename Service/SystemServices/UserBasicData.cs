using Core.Interfaces.ISystemServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.SystemServices
{
    public class UserBasicData : IUserBasicData
    {
        private readonly IHttpContextAccessor _accessor;
        public UserBasicData(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public string GetRoleName() =>
        _accessor!.HttpContext == null ? string.Empty : _accessor!.HttpContext!.User.FindFirstValue(ClaimTypes.Role);

        public Guid GetUserId() =>
        Guid.Parse(_accessor!.HttpContext == null ? string.Empty : _accessor!.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
