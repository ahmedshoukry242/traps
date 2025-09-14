using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Auth
{
    public class setNewPassword
    {
        public required string UserId { get; set; }
        public required string NewPassword { get; set; }
    }
}
