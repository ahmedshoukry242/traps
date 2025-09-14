using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Auth
{
    public class LockUser
    {
        public string UserId { get; set; }
        public bool IsLocked { get; set; }
        public string? Reason { get; set; }
    }
}
