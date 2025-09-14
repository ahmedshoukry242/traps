using Core.DTOs.Trap.TrapEmergency;
using Core.DTOs.Trap.TrapSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Trap
{
    public class TrapReadDTOs
    {
        public class ReadListResponse
        {
            public int TotalRecords { get; set; }
            public List<ReadListDto> Data { get; set; }
        }
        public class ReadListDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class GetTrapresponse
        {
            //public Guid UserId { get; set; }
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string SerialNumber { get; set; } = string.Empty;
            
            public int Status { get; set; }
            public int? Iema { get; set; } = 0;
            public int? ValveQut { get; set; } = 0;
            public int? Fan { get; set; } = 0;
            public bool IsCounterOn { get; set; }
            public bool IsCounterReadingFromSimCard { get; set; }
            public DateOnly? ReadingDate { get; set; }
            public string Lat { get; set; }
            public string Long { get; set; }
            public bool IsScheduleOn { get; set; }
            public string? BigBattery { get; set; }
            public string? SmallBattery { get; set; }
            public string? FileDate { get; set; }
            
            public bool IsThereEmergency { get; set; }

            public int? categoryId { get; set; }
            public int? CountryId { get; set; }
            public int? StateId { get; set; }

            public IEnumerable<EmergencyReadDto.GetTrapEmergency> TrapEmergencies { get; set; }  
            //public SharGetTrapReading LastRead { get; set; }  
            public IEnumerable<TrapScheduleDto> TrapCounterSchedules { get; set; }  
            public IEnumerable<TrapScheduleDto> TrapFanSchedules { get; set; }  
            public IEnumerable<TrapScheduleDto> TrapValveQutSchedules { get; set; }  
        }

    }
}
