using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Trap.TrapRead
{
    public class ReadResponsesDTOs
    {

        public class ReadBasicDataDto
        {
            public int? Id { get; set; }
            public int? TrapId { get; set; }
            public string TrapName { get; set; } = string.Empty;
            public string SerialNumber { get; set; } = string.Empty;
            public string Lat { get; set; } = string.Empty;
            public string Long { get; set; } = string.Empty;
            public int? Fan { get; set; } = 0;
            
            public int? Counter { get; set; } = 0;
        }

        public class ReadProjectionDto : ReadBasicDataDto
        {
            public int? TrapReadId { get; set; }
            public DateOnly ReadingDate { get; set; }
            public TimeOnly ReadingTime { get; set; }

            public int? Co2 { get; set; } = 0;
            public string Co2Val { get; set; } = string.Empty;
            public int Readingsmall { get; set; }
            public int ReadingLarg { get; set; }
            public int ReadingMosuqitoes { get; set; }
            public string ReadingTempIn { get; set; } = string.Empty;
            public string ReadingTempOut { get; set; } = string.Empty;
            public string ReadingWindSpeed { get; set; } = string.Empty;
            public string ReadingHumidty { get; set; } = string.Empty;
            public int ReadingFly { get; set; }
            public string BigBattery { get; set; } = string.Empty;
            public string SmallBattery { get; set; } = string.Empty;
        }

        public class ReadResponseDto : ReadProjectionDto
        {
            public new string ReadingTime { get; set; } = string.Empty;
        }

        public class LastReadingResponseDto : ReadBasicDataDto
        {
            public string ReadingDate { get; set; }
            public int? ValveQut { get; set; }
            public bool IsThereEmergency { get; set; }
            public string ReadingTime { get; set; }
            public bool HasReads { get; set; }
            public int? ReadingSmall { get; set; }
            public int? ReadingLarg { get; set; }
            public int? ReadingMosuqitoes { get; set; }
        }


    }
}
