using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Auth
{
    public class User : IdentityUser<Guid>
    {

        public string? Name { get; set; }
        public bool IsLocked { get; set; } = false;
        public string? LockReason { get; set; }

        // Navigation Props
        public Guid? ParentUserId { get; set; }
        [ForeignKey(nameof(ParentUserId))]
        public User ParentUser { get; set; }

        public IEnumerable<User> Children { get; set; }
        public IEnumerable<UserTraps> UserTraps { get; set; }

    }
}
