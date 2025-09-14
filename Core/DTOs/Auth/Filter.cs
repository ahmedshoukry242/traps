using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Auth
{
    public class Filter
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? RoleId { get; set; }
    }
}
