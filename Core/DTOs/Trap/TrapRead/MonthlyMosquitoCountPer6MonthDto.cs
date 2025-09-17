using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Trap.TrapRead
{
    public class MonthlyMosquitoCountPer6MonthDto
    {
        public int DateInNumber { get; set; }
        public string DateOfMonth { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public int InsectsCount { get; set; }
    }
}
