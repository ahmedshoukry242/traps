using Core.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserTraps
    {
        public int Id { get; set; }


        // Navigation Props
        public User User { get; set; }
        public Guid UserId { get; set; }

        public Trap Trap { get; set; }
        public int TrapId { get; set; }

    }
}
