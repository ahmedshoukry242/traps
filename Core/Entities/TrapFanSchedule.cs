using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class TrapFanSchedule
    {

        public int Id { get; set; }
        public int ScdTime { get; set; }
        public bool Status { get; set; }

        // Navigation Props
        public Trap Trap { get; set; }
        public int TrapId { get; set; }
    }
}
