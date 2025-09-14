using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Auth
{
    public class UserReadDTOs
    {
        public class UserreadRequestDto
        {
            public Guid Id { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
            public Guid RoleId { get; set; }
            public string RoleName { get; set; }
            public bool IsLocked { get; set; }
            public string? LockedReason { get; set; }
            public int? TrapId { get; set; }
        }
        public class UserreadResponseDto
        {
            public Guid Id { get; set; }
            public string? Email { get; set; }
            public string? Name { get; set; }
            //public Guid RoleId { get; set; }
            public IEnumerable<string>? RoleNames { get; set; }
            public IEnumerable<int>? TrapIds { get; set; }
            public bool IsLocked { get; set; }
            public string? LockedReason { get; set; }
        }
    }
}
