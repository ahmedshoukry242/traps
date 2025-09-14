using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ReadDetails
    {
        public int Id { get; set; }

        public TimeOnly Time { get; set; }
        public string SerialNumber { get; set; }
        public string ReadingLat { get; set; }
        public string ReadingLng { get; set; }
        public int Counter { get; set; }
        public int Fan { get; set; }
        public int Co2 { get; set; }
        public string Co2Val { get; set; }
        public string ReadingSmall { get; set; }
        public string ReadingLarg { get; set; }
        public string ReadingMosuqitoes { get; set; }
        public string ReadingTempIn { get; set; }
        public string ReadingTempOut { get; set; }
        public string ReadingWindSpeed { get; set; }
        public string ReadingHumidty { get; set; }
        //public string Amb_Light { get; set; }
        //public string Battery { get; set; }
        //public string Reception { get; set; }
        //public string Power_Draw { get; set; }
        public string ReadingFly { get; set; }
        public string BigBattery { get; set; }
        public string SmallBattery { get; set; }
        public bool IsDone { get; set; }
        public bool IsClean { get; set; }


        // Navigation Props
        public TrapRead TrapRead { get; set; }
        public int TrapReadId { get; set; }
    }
}
