using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Trap.Statistic
{
    public class MosquitoStatisticsDto
    {
        public int totalMosquitoes { get; set; }
        public int totalSmall { get; set; }
        public int totalLarge { get; set; }
        public int totalFlies { get; set; }
        public int trapsWithData { get; set; }
        public string period { get; set; }
    }
}