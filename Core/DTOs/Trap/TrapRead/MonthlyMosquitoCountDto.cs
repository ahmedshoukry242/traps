using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Trap.TrapRead
{
    public class MonthlyMosquitoCountDto
    {
        public int dateInNumber { get; set; }
        public string date { get; set; }
        public int smallCount { get; set; }
        public int largeCount { get; set; }
        public int mosuqitoesCount { get; set; }
        public int flyesCount { get; set; }
    }

    public class MonthlyMosquitoCountResponseDto
    {
        public string message { get; set; }
        public bool isSuccess { get; set; }
        public bool isActive { get; set; }
        public List<MonthlyMosquitoCountDto> data { get; set; }
        public string error { get; set; }
        public int? count { get; set; }
    }
}