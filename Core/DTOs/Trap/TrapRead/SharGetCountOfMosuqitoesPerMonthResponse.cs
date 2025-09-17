using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Trap.TrapRead
{
    public class SharGetCountOfMosuqitoesPerMonthResponse
    {
        public int DateInNumber { get; set; }
        public string Date { get; set; } = string.Empty;
        public string DateOfMonth { get; set; } = string.Empty;
        public int SmallCount { get; set; }
        public int LargeCount { get; set; }
        public int MosuqitoesCount { get; set; }
        public int FlyesCount { get; set; }
        public int InsectsCount { get; set; }
    }
}