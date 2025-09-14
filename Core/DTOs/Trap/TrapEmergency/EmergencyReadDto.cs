using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Trap.TrapEmergency
{
    public class EmergencyReadDto
    {
        public class EmergencyProjectionDto
        {
            public int Id { get; set; }
            public string SerialNumber { get; set; }
            public string? Lat { get; set; }
            public string? Long { get; set; }
            public DateTime DateTime { get; set; }

        }
        public class EmergencyDto : EmergencyProjectionDto
        {
            //public int Id { get; set; }
            //public string SerialNumber { get; set; }
            //public string? Lat { get; set; }
            //public string? Long { get; set; }

            private DateTime _dateTime;
            public new DateTime DateTime
            {
                set
                {
                    _dateTime = value;
                    Year = value.Year;
                    Month = value.Month;
                    Date = DateOnly.FromDateTime(value);
                    Time = value.ToShortTimeString();
                }
                private get => _dateTime;
            }



            public int Year { get; private set; }
            public int Month { get; private set; }
            public string Time { get; private set; }
            public DateOnly Date { get; private set; }
        }
        public class GrouppedEmergency
        {
            public int Year { get; set; }
            //public int Month { get; set; }
            public List<EmergencyDto> Emergencies { get; set; }
        }

        public class GetTrapEmergency
        {
            public int Id { get; set; }
            public string Lat { get; set; } = string.Empty;
            public string Long { get; set; } = string.Empty;
            public DateTime Date { get; set; }
            public int TrapId { get; set; }
        }
    }

}
