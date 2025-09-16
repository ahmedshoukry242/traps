using AutoMapper;
using Core.Constants;
using Core.DTOs;
using Core.DTOs.Trap.Statistic;
using Core.DTOs.Trap.TrapRead;
using Core.Entities;
using Core.Entities.Auth;
using Core.Entities.Lookups;
using Core.Interfaces.IRepositories;
using Core.Interfaces.IServices;
using Core.Interfaces.ISystemServices;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Core.DTOs.Trap.TrapRead.ReadResponsesDTOs;


namespace Service.Services
{
    public class TrapReadService : ITrapReadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserBasicData _userBasicData;
        public TrapReadService(IUnitOfWork unitOfWork, IMapper mapper, IUserBasicData userBasicData)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userBasicData = userBasicData;
        }

        public async Task<GlobalResponse> CreateTrapReading(ReadDetailsCreateDto dto)
        {
            // Getting the Trap
            Trap trap = await _unitOfWork.TrapRepository.GetFirstOrDefaultAsync(x => x.SerialNumber == dto.SerlNum);

            if (trap == null)
                return new GlobalResponse { IsSuccess = false, StatusCode = HttpStatusCode.NotFound, Message = "Trap Not Found!" };

            // Read Details 
            ReadDetails readDetails = _mapper.Map<ReadDetails>(dto);
            DateOnly trapReadDate = DateOnly.Parse(dto.ReadingDate);

            // Check Trap Read
            TrapRead? trapRead = await _unitOfWork.TrapReadRepository
                .GetAllQueryable()
                .Where(x => x.TrapId == trap.Id && x.Date == trapReadDate)
                .FirstOrDefaultAsync();

            if (trapRead is null)
            {
                // Adding [read] for the day
                await _unitOfWork.TrapReadRepository
                    .AddAsync(new TrapRead
                    {
                        TrapId = trap.Id,
                        Date = trapReadDate,
                        ServerCreationDate = DateOnly.FromDateTime(DateTime.Now),
                        readDetails = new List<ReadDetails>() { readDetails }
                    });
            }
            else
            {
                // Adding [read details] if [read] exists
                readDetails.TrapReadId = trapRead.Id;
                await _unitOfWork.ReadDetailsRepository.AddAsync(readDetails);
            }

            if (!await _unitOfWork.SaveChangesAsync())
                return new GlobalResponse { IsSuccess = false, Message = "Failed to add read details!", StatusCode = HttpStatusCode.BadRequest };
            return new GlobalResponse { IsSuccess = true, StatusCode = HttpStatusCode.OK, Message = "Added!" };
        }

        public async Task<GlobalResponse> GetAllTrapReadingsAsync(ReadRequestDto model)
        {

            // Retrieve time zone information for the specific trap
            var trap = await _unitOfWork.TrapRepository.GetFirstOrDefaultAsync(x => x.Id == model.TrapId);

            if (trap is null)
                return new GlobalResponse { IsSuccess = false, Message = "Trap Not found, please provide a valid trap id", StatusCode = HttpStatusCode.NotFound };

            DateTime currentTimeInTrapTimeZone = DateTime.Now;
            if (trap.CountryId != null)
            {
                var trapCountry = await _unitOfWork.CountryRepository.GetFirstOrDefaultAsync(x => x.Id == trap.CountryId);
                var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(trapCountry.TimeZoneName);
                currentTimeInTrapTimeZone = trapCountry != null ? TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo) : DateTime.Now;
            }

            var usingDate = DateOnly.FromDateTime(currentTimeInTrapTimeZone);

            var readsQuery =
                from trapReadings in _unitOfWork.TrapReadRepository.GetAllQueryableAsNoTracking()
                join traps in _unitOfWork.TrapRepository.GetAllQueryableAsNoTracking() on trapReadings.TrapId equals traps.Id into joinnedTrapRead
                from traps in joinnedTrapRead.DefaultIfEmpty()

                    //from traps in _unitOfWork.TrapRepository.GetAllQueryableAsNoTracking()
                    //             join trapReadings in _unitOfWork.TrapReadRepository.GetAllQueryableAsNoTracking() on traps.Id equals trapReadings.TrapId into joinnedTrapRead
                    //             from trapReadings in joinnedTrapRead.DefaultIfEmpty()

                join readDetails in _unitOfWork.ReadDetailsRepository.GetAllQueryableAsNoTracking() on trapReadings.Id equals readDetails.TrapReadId into joinnedDetails
                from readDetails in joinnedDetails.DefaultIfEmpty()

                where traps.Id == trap.Id
                //&&
                //   (trapReadings.Date >= usingDate)
                //   &&
                //   (trapReadings.Date < usingDate.AddDays(1))
                select new ReadProjectionDto
                {
                    Id = readDetails.Id,
                    TrapId = traps.Id,
                    TrapName = traps.Name,
                    SerialNumber = traps.SerialNumber,
                    TrapReadId = trapReadings.Id,
                    ReadingDate = trapReadings.Date,
                    ReadingTime = readDetails.Time,
                    Lat = readDetails.ReadingLat,
                    Long = readDetails.ReadingLng,
                    Fan = readDetails.Fan,
                    Co2 = readDetails.Co2,
                    Counter = readDetails.Counter,
                    Co2Val = readDetails.Co2Val,
                    Readingsmall = readDetails.ReadingSmall,
                    ReadingLarg = readDetails.ReadingLarg,
                    ReadingMosuqitoes = readDetails.ReadingMosuqitoes,
                    ReadingTempIn = readDetails.ReadingTempIn,
                    ReadingTempOut = readDetails.ReadingTempOut,
                    ReadingWindSpeed = readDetails.ReadingWindSpeed,
                    ReadingHumidty = readDetails.ReadingHumidty,
                    ReadingFly = readDetails.ReadingFly,
                    BigBattery = readDetails.BigBattery,
                    SmallBattery = readDetails.SmallBattery,
                };


            if (model.StartDate != null && model.EndDate != null)
            {
                readsQuery = readsQuery.Where(x =>
                (model.StartDate == null || x.ReadingDate >= model.StartDate)
                &&
                (model.EndDate == null || x.ReadingDate <= model.EndDate)
                );
            }
            else
            {
                readsQuery = readsQuery.Where(x =>
                (x.ReadingDate >= usingDate)
                &&
                (x.ReadingDate < usingDate.AddDays(1))
                );
            }

            //var qs = readsQuery.ToQueryString();

            int count = await readsQuery.CountAsync();
            if (count <= 0)
                return new GlobalResponse<List<ReadResponseDto>> { IsSuccess = true, Message = "No data!", StatusCode = HttpStatusCode.OK, Data = new() };

            //readsQuery = readsQuery.OrderByDescending(x => x.ReadingDate).ThenByDescending(x => x.ReadingTime)
            //    .Skip(model.PageSize * (model.PageNumber -1))
            //    .Take(model.PageSize);

            var finalResult = await readsQuery.ToListAsync();

            var mappedData = _mapper.Map<List<ReadResponseDto>>(finalResult);

            return new GlobalResponse<List<ReadResponseDto>> { Data = mappedData, /*Count = count,*/ IsSuccess = true, Message = "Data retrieved!", StatusCode = HttpStatusCode.OK };

        }

        public async Task<GlobalResponse<StatisticsDto>> GetUserTrapStatistics(Guid userId)
        {
            try
            {
                // Get user role from HTTP context
                var userRole = _userBasicData.GetRoleName();
                StatisticsDto statistics;

                if (userRole == RoleName.Superadmin)
                {
                    // SuperAdmin gets statistics for all users and traps
                    var allUsers = await _unitOfWork.UserTrapsRepository
                        .GetAllQueryableAsNoTracking()
                        .Select(x => x.UserId)
                        .Distinct()
                        .CountAsync();

                    var allTraps = await _unitOfWork.TrapRepository
                        .GetAllQueryableAsNoTracking()
                        .Include(x => x.trapReads)
                        .ToListAsync();

                    var totalTraps = allTraps.Count;
                    var notWorkingTraps = allTraps.Count(x => !x.trapReads.Any(tr => tr.Date >= DateOnly.FromDateTime(DateTime.Now.AddDays(-7))));
                    var workingTraps = totalTraps - notWorkingTraps;

                    statistics = new StatisticsDto
                    {
                        usersCount = allUsers,
                        trapsCount = totalTraps,
                        workingCount = workingTraps,
                        notWorkingCount = notWorkingTraps
                    };
                }
                else
                {
                    // Regular user gets only their own trap statistics with usersCount = 0
                    var userTraps = await _unitOfWork.UserTrapsRepository
                        .GetAllQueryableAsNoTracking()
                        .Where(x => x.UserId == userId)
                        .Include(x => x.Trap)
                        .ThenInclude(t => t.trapReads)
                        .ToListAsync();

                    var totalTraps = userTraps.Count;
                    var notWorkingTraps = userTraps.Count(ut => !ut.Trap.trapReads.Any(tr => tr.Date >= DateOnly.FromDateTime(DateTime.Now.AddDays(-7))));
                    var workingTraps = totalTraps - notWorkingTraps;

                    statistics = new StatisticsDto
                    {
                        usersCount = 0, // For regular users, set to 0
                        trapsCount = totalTraps,
                        workingCount = workingTraps,
                        notWorkingCount = notWorkingTraps
                    };
                }

                return new GlobalResponse<StatisticsDto>
                {
                    IsSuccess = true,
                    Message = "Statistics retrieved successfully",
                    StatusCode = HttpStatusCode.OK,
                    Data = statistics
                };
            }
            catch (Exception ex)
            {
                return new GlobalResponse<StatisticsDto>
                {
                    IsSuccess = false,
                    Message = $"Error retrieving statistics: {ex.Message}",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        public async Task<GlobalResponse> GetLastReadingToCurrentUserTrapsAsync()
        {

            var userRole = _userBasicData.GetRoleName();
            var userId = _userBasicData.GetUserId();

            var trapsLastReadQuery = from traps in _unitOfWork.TrapRepository.GetAllQueryableAsNoTracking()

                                     join countries in _unitOfWork.CountryRepository.GetAllQueryableAsNoTracking()
                                     on traps.CountryId equals countries.Id into trapCountry
                                     from countries in trapCountry.DefaultIfEmpty()

                                     let trapReads = traps.trapReads.OrderByDescending(b => b.Date).FirstOrDefault()

                                     let userTraps = traps.UserTraps.Select(x => x.UserId)

                                     let readDetails = trapReads != null ? trapReads.readDetails.OrderByDescending(d => d.Time).FirstOrDefault() : null
                                     select new
                                     {
                                         traps,
                                         trapReads,
                                         userTraps,
                                         readDetails,
                                         countries,
                                     };


            if (userRole != RoleName.Superadmin)
                trapsLastReadQuery = trapsLastReadQuery.Where(x => x.userTraps.Contains(userId));

            //var sql = trapsLastReadQuery.ToQueryString();

            var result = await trapsLastReadQuery.ToListAsync();

            var finalResult = result.Select(x =>
            {
                var rd = x.readDetails;
                var tr = x.traps;
                var trRead = x.trapReads;

                var country = x.countries;

                // Default: if missing, show empty
                string readingDate = string.Empty;
                string readingTime = string.Empty;

                var readingDateTime = DateTime.UtcNow;

                if (trRead != null && rd != null)
                {
                    // 1. Combine DateOnly + TimeOnly into a DateTime
                    readingDateTime = trRead.Date.ToDateTime(rd.Time);

                    // 2. Apply offset (convert from UTC to local time)
                    var localDateTime = readingDateTime.AddMinutes(country != null ? country.UtcOffsetMinutes : 0);

                    // 3. Format as strings
                    readingDate = localDateTime.ToString("yyyy-MM-dd");
                    readingTime = localDateTime.ToString("HH:mm");
                }

                return new LastReadingResponseDto
                {
                    Id = rd?.Id,//x.readDetails != null ? x.readDetails.Id : null,
                    TrapId = tr.Id,
                    TrapName = tr.Name ?? string.Empty,
                    SerialNumber = tr.SerialNumber ?? string.Empty,
                    Lat = rd?.ReadingLat ?? string.Empty,
                    Long = rd?.ReadingLng ?? string.Empty,
                    Fan = rd?.Fan ?? 0,
                    Counter = rd?.Counter ?? 0,

                    ReadingDate = readingDate,
                    ReadingTime = readingTime,

                    IsThereEmergency = tr.IsThereEmergency,
                    ValveQut = tr.ValveQut,
                    HasReads = rd != null,
                    ReadingLarg = rd?.ReadingLarg,
                    ReadingSmall = rd?.ReadingSmall,
                    ReadingMosuqitoes = rd?.ReadingMosuqitoes
                };
            }).ToList();


            return new GlobalResponse<List<LastReadingResponseDto>> { Data = finalResult, IsSuccess = true, StatusCode = HttpStatusCode.OK };
        }

        public async Task<GlobalResponse> GetStatisticsForTrapReadingsAsInsectsAsync()
        {
            var currentDate = DateOnly.FromDateTime(DateTime.UtcNow);

            Expression<Func<UserTraps, bool>> filter = x => true;

            if (_userBasicData.GetRoleName() != RoleName.Superadmin)
                filter = x => x.UserId == _userBasicData.GetUserId();


            var trapsForUser = await _unitOfWork.UserTrapsRepository.GetAllQueryableAsNoTracking()
                .Where(filter)
                .Select(u => u.Trap)
                .Distinct()
                .Select(trap => new StatisticsForTrapReadingsAsInsectsDto
                {
                    SmallCount = trap.trapReads
                        .Where(tr => tr.Date == currentDate)
                        .SelectMany(tr => tr.readDetails)
                        .Sum(rd => rd.ReadingSmall),

                    LargeCount = trap.trapReads
                        .Where(tr => tr.Date == currentDate)
                        .SelectMany(tr => tr.readDetails)
                        .Sum(rd => rd.ReadingLarg),

                    FlyesCount = trap.trapReads
                        .Where(tr => tr.Date == currentDate)
                        .SelectMany(tr => tr.readDetails)
                        .Sum(rd => rd.ReadingFly),

                    MosuqitoesCount = trap.trapReads
                        .Where(tr => tr.Date == currentDate)
                        .SelectMany(tr => tr.readDetails)
                        .Sum(rd => rd.ReadingMosuqitoes),
                })
                .AsNoTracking()
                .ToListAsync();

            var sumOfAllElements = new StatisticsForTrapReadingsAsInsectsDto
            {
                SmallCount = trapsForUser.Sum(t => t.SmallCount),
                LargeCount = trapsForUser.Sum(t => t.LargeCount),
                FlyesCount = trapsForUser.Sum(t => t.FlyesCount),
                MosuqitoesCount = trapsForUser.Sum(t => t.MosuqitoesCount),
                TotalInsects = trapsForUser.Sum(t => t.SmallCount + t.LargeCount + t.FlyesCount + t.MosuqitoesCount),
            };

            // Percentages (safe handling: avoid divide by zero)
            if (sumOfAllElements.TotalInsects > 0)
            {
                sumOfAllElements.FlyesPercentage = sumOfAllElements.FlyesCount / sumOfAllElements.TotalInsects * 100;
                sumOfAllElements.SmallPercentage = sumOfAllElements.SmallCount / sumOfAllElements.TotalInsects * 100;
                sumOfAllElements.LargePercentage = sumOfAllElements.LargeCount / sumOfAllElements.TotalInsects * 100;
                sumOfAllElements.MosuqitoesPercentage = sumOfAllElements.MosuqitoesCount / sumOfAllElements.TotalInsects * 100;
            }

            return new GlobalResponse<StatisticsForTrapReadingsAsInsectsDto> { Data = sumOfAllElements, IsSuccess = true, StatusCode = HttpStatusCode.OK };

        }

        public async Task<GlobalResponse> GetCountOfMosuqitoesToLastSixDaysAsync(bool isMosquito)
        {

            var userId = _userBasicData.GetUserId();

            var endDate = DateOnly.FromDateTime(DateTime.Now);
            var startDate = endDate.AddDays(-6);

            var list = await _unitOfWork.UserTrapsRepository.GetAllQueryableAsNoTracking()
                .Where(ut => ut.UserId == userId)
                .SelectMany(ut => ut.Trap.trapReads) // get trapReads for the user’s traps
                .Where(tr => tr.Date >= startDate && tr.Date <= endDate)
                .SelectMany(tr => tr.readDetails.Select(rd => new
                {
                    tr.Date,
                    rd.ReadingMosuqitoes,
                    rd.ReadingFly
                })) // flatten trapReads + readDetails
                .GroupBy(x => x.Date.Day)
                .Select(group => new MosuqitoesCountDto
                {
                    DateInNumber = group.Key,
                    Date = new DateOnly(startDate.Year, startDate.Month, group.Key).ToString("dddd"),
                    InsectsCount = isMosquito
                        ? group.Sum(x => x.ReadingMosuqitoes)
                        : group.Sum(x => x.ReadingFly)
                })
                .ToListAsync();

            // Create a list of days within the range
            var allDaysInRange = Enumerable.Range(0, 7).Select(i => startDate.AddDays(i).Day).ToList();

            // Add missing days with default values
            List<MosuqitoesCountDto> listOfObj = new();
            listOfObj.AddRange(allDaysInRange.Except(list.Select(x => x.DateInNumber)).Select(day =>
                new MosuqitoesCountDto
                {
                    DateInNumber = day,
                    Date = new DateOnly(startDate.Year, startDate.Month, day).ToString("dddd"),
                    InsectsCount = 0 // Default value for missing days
                }));

            listOfObj.AddRange(list);

            return new GlobalResponse<List<MosuqitoesCountDto>> { Data = listOfObj.OrderBy(v => v.DateInNumber).ToList(),IsSuccess = true,StatusCode = HttpStatusCode.OK };
        }



    }
}
