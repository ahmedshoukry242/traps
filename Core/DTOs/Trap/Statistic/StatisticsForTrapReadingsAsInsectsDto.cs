using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Trap.Statistic
{
    public class StatisticsForTrapReadingsAsInsectsDto
    {
        public int SmallCount { get; set; }
        public int LargeCount { get; set; }
        public int MosuqitoesCount { get; set; }
        public int FlyesCount { get; set; }
        public int SmallPercentage { get; set; }
        public int LargePercentage { get; set; }
        public int MosuqitoesPercentage { get; set; }
        public int FlyesPercentage { get; set; }
        public int TotalInsects { get; set; }
    }
}
