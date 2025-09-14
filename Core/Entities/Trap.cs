using Core.Entities.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Trap
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SerialNumber { get; set; }
        public int TrapStatus { get; set; }
        public int? Iema { get; set; }
        public int? ValveQut { get; set; }
        public int? Fan { get; set; }
        public bool IsCounterOn { get; set; }

        public bool IsCounterReadingFromSimCard { get; set; }
        public DateOnly? ReadingDate { get; set; }
        public string? Lat { get; set; }
        public string? Long { get; set; }
        public bool IsScheduleOn { get; set; }
        public string? BigBattery { get; set; }
        public string? SmallBattery { get; set; }
        public string? FileDate { get; set; }
        public bool IsThereEmergency { get; set; }
        public bool IsNew { get; set; }
        public string? LastLat { get; set; }
        public string? LastLong { get; set; }


        // Navigation Props
        public IEnumerable<UserTraps> UserTraps { get; set; }
        public IEnumerable<TrapRead> trapReads { get; set; }

        public ICollection<TrapCounterSchedule> TrapCounterSchedules { get; set; }
        public ICollection<TrapFanSchedule> TrapFanSchedules { get; set; }
        public ICollection<TrapValveQutSchedule> TrapValveQutSchedules { get; set; }
        public virtual IEnumerable<TrapEmergency> TrapEmergencies { get; set; }

        public Category Category { get; set; }
        public int? CategoryId { get; set; }

        public Country Country { get; set; }
        public int? CountryId { get; set; }

        public State State { get; set; }
        public int? StateId { get; set; }

    }
}
