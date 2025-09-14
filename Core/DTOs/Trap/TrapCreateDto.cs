using Core.DTOs.Trap.TrapSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Trap
{
    public class TrapCreateDto
    {
        public string? Name { get; set; }
        public string? SerialNumber { get; set; }
        public int? Iema { get; set; }
        public string? Lat { get; set; }
        public string? Long { get; set; }
        public int? ValveQut { get; set; }
        public int? Fan { get; set; }
        public bool IsCounterOn { get; set; }
        public string? BigBattery { get; set; }
        public string? SmallBattery { get; set; }
        public string? FileDate { get; set; }
        public int? CategoryId { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public bool IsScheduleOn { get; set; }

        public List<TrapScheduleDto> TrapCounterSchedules { get; set; }
        public List<TrapScheduleDto> TrapValveQutSchedules { get; set; }
        public List<TrapScheduleDto> TrapFanSchedules { get; set; }

        //public List<TrapCounterScheduleDto> TrapCounterSchedules { get; set; }
        //public List<TrapValveQutSchedulsDto> TrapValveQutSchedules { get; set; }
        //public List<TrapFanScheduleDto> TrapFanSchedules { get; set; }

    }
}
