using AutoMapper;
using Core.DTOs.Company;
using Core.DTOs.Trap;
using Core.DTOs.Trap.TrapRead;
using Core.DTOs.Trap.TrapSchedule;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.DTOs.Trap.TrapRead.ReadResponsesDTOs;

namespace Core.Helpers.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CompanyCreateDto, Company>();
            CreateMap<Company, CompanyReadDto>();

            #region Trap

            CreateMap<TrapCreateDto, Trap>()
                .ForMember(x=>x.SerialNumber,x=>x.MapFrom(f=> !string.IsNullOrEmpty(f.SerialNumber) ? f.SerialNumber.Trim() : ""));
            //CreateMap<TrapCounterScheduleDto, TrapCounterSchedule>();
            //CreateMap<TrapFanScheduleDto, TrapFanSchedule>();
            //CreateMap<TrapValveQutSchedulsDto, TrapValveQutSchedule>();
            CreateMap<TrapScheduleDto, TrapCounterSchedule>();
            CreateMap<TrapScheduleDto, TrapFanSchedule>();
            CreateMap<TrapScheduleDto, TrapValveQutSchedule>();

            // Map to ReadDetails
            CreateMap<ReadDetailsCreateDto, ReadDetails>()
                .ForMember(d => d.SerialNumber, s => s.MapFrom(m => m.SerlNum))
                .ForMember(d => d.Time, s => s.MapFrom(m => m.ReadingTime));


            CreateMap<Trap, ConfigurationsRead>()
                .ForMember(des => des.Status, src => src.MapFrom(src => src.IsCounterOn ? "on" : "Off"))
                .ForMember(des => des.Read, src => src.MapFrom(src => src.IsCounterReadingFromSimCard))
                .ForMember(des => des.File, src => src.MapFrom(src => src.ReadingDate== DateOnly.MinValue ? "" : src.ReadingDate.ToString()))
                .ForMember(des => des.FileDate, src => src.MapFrom(src => src.FileDate))
                .ForMember(des => des.Serial, src => src.MapFrom(src => src.SerialNumber))
                .ForMember(des => des.Co2, src => src.MapFrom(src => src.ValveQut ?? 0))
                .ReverseMap();
            #endregion


            #region Trap Read
            CreateMap<ReadProjectionDto, ReadResponseDto>()
                .ForMember(x=>x.ReadingTime,m=>m.MapFrom(f=>f.ReadingTime.ToString("HH:mm")));
            #endregion

        }
    }
}
