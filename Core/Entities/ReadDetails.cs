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
        public int ReadingSmall { get; set; }
        public int ReadingLarg { get; set; }
        public int ReadingMosuqitoes { get; set; }
        public int ReadingTempIn { get; set; }
        public int ReadingTempOut { get; set; }
        public int ReadingWindSpeed { get; set; }
        public int ReadingHumidty { get; set; }
        //public string Amb_Light { get; set; }
        //public string Battery { get; set; }
        //public string Reception { get; set; }
        //public string Power_Draw { get; set; }
        public int ReadingFly { get; set; }
        public int BigBattery { get; set; }
        public int SmallBattery { get; set; }
        public bool IsDone { get; set; }
        public bool IsClean { get; set; }


        // Navigation Props
        public TrapRead TrapRead { get; set; }
        public int TrapReadId { get; set; }
    }
}
