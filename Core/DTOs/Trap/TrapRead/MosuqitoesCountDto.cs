using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Trap.TrapRead
{
    public class MosuqitoesCountDto
    {
        public int DateInNumber { get; set; }
        public DateOnly DateOfMonth { get; set; }
        public string Date { get; set; } = string.Empty;
        public int InsectsCount { get; set; }
    }
}
