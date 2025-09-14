using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Auth
{
    public class RegisterDto02
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
       
        public string PhoneNumber { get; set; }
    }
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public List<int> TrapIds { get; set; }
    }
}
