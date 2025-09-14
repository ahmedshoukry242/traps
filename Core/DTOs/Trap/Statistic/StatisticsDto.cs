using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Trap.Statistic
{
    public class StatisticsDto
    {
        public int usersCount { get; set; }
        public int workingCount { get; set; }
        public int notWorkingCount { get; set; }
        public int trapsCount { get; set; }
    }
}
