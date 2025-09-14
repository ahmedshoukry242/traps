using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Auth
{
    public class SigninDTOs
    {
        public class Request
        {
            public string UserNameOrEmail { get; set; }
            public string Password { get; set; }
        }
        public class Response
        {
            public string Email { get; set; }
            public Guid Id { get; set; }
            public string UserName { get; set; }
            public string Token { get; set; }
            public string Role { get; set; }
            public DateTime ExpiresOn { get; set; }
            public bool IsLocked { get; set; }
        }
    }
}
