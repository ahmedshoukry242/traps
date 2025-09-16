using AutoMapper;
using Core.Constants;
using Core.DTOs;
using Core.DTOs.Trap.Statistic;
using Core.DTOs.Trap.TrapRead;
using Core.Entities;
using Core.Interfaces.IRepositories;
using Core.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TrapReadService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
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
                join traps in _unitOfWork.TrapRepository.GetAllQueryableAsNoTracking() on trapReadings.TrapId equals traps.Id   into joinnedTrapRead
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
                var userRole = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value ?? "User";
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

        public async Task<MonthlyMosquitoCountResponseDto> GetCountOfMosuqitoesToLast12Months()
        {
            try
            {
                // Get user role and ID from HTTP context
                var userRole = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value ?? "User";
                var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                
                if (!Guid.TryParse(userIdClaim, out Guid userId))
                {
                    return new MonthlyMosquitoCountResponseDto
                    {
                        isSuccess = false,
                        message = "Invalid user ID",
                        error = "User authentication failed",
                        data = new List<MonthlyMosquitoCountDto>()
                    };
                }

                // Calculate date range for last 12 months
                var currentDate = DateTime.Now;
                var startDate = new DateTime(currentDate.Year - 1, currentDate.Month, 1);
                var endDate = new DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month));

                IQueryable<ReadDetails> readDetailsQuery;

                if (userRole == RoleName.Superadmin)
                {
                    // SuperAdmin gets all trap read data
                    readDetailsQuery = _unitOfWork.ReadDetailsRepository.GetAllQueryableAsNoTracking()
                        .Include(rd => rd.TrapRead)
                        .Where(rd => rd.TrapRead.Date >= DateOnly.FromDateTime(startDate) && 
                                   rd.TrapRead.Date <= DateOnly.FromDateTime(endDate));
                }
                else
                {
                    // Regular user gets only their trap data
                    readDetailsQuery = _unitOfWork.ReadDetailsRepository.GetAllQueryableAsNoTracking()
                        .Include(rd => rd.TrapRead)
                        .ThenInclude(tr => tr.Trap)
                        .ThenInclude(t => t.UserTraps)
                        .Where(rd => rd.TrapRead.Date >= DateOnly.FromDateTime(startDate) && 
                                   rd.TrapRead.Date <= DateOnly.FromDateTime(endDate) &&
                                   rd.TrapRead.Trap.UserTraps.Any(ut => ut.UserId == userId));
                }

                var readDetailsData = await readDetailsQuery.ToListAsync();

                // Group data by month and calculate totals
                var monthlyData = new List<MonthlyMosquitoCountDto>();
                var monthNames = new string[] 
                {
                    "يناير", "فبراير", "مارس", "أبريل", "مايو", "يونيو",
                    "يوليو", "أغسطس", "سبتمبر", "أكتوبر", "نوفمبر", "ديسمبر"
                };

                for (int month = 1; month <= 12; month++)
                {
                    var monthData = readDetailsData
                        .Where(rd => rd.TrapRead.Date.Month == month)
                        .ToList();

                    var smallCount = monthData.Sum(rd => rd.ReadingSmall);
                    var largeCount = monthData.Sum(rd => rd.ReadingLarg);
                    var mosquitoesCount = monthData.Sum(rd => rd.ReadingMosuqitoes);
                    var flyesCount = monthData.Sum(rd => rd.ReadingFly);

                    monthlyData.Add(new MonthlyMosquitoCountDto
                    {
                        dateInNumber = month,
                        date = monthNames[month - 1],
                        smallCount = smallCount,
                        largeCount = largeCount,
                        mosuqitoesCount = mosquitoesCount,
                        flyesCount = flyesCount
                    });
                }

                return new MonthlyMosquitoCountResponseDto
                {
                    message = "Data retrieved successfully",
                    isSuccess = true,
                    isActive = false,
                    data = monthlyData,
                    error = "",
                    count = null
                };
            }
            catch (Exception ex)
            {
                return new MonthlyMosquitoCountResponseDto
                {
                    isSuccess = false,
                    message = "Error retrieving mosquito count data",
                    error = ex.Message,
                    data = new List<MonthlyMosquitoCountDto>()
                };
            }
        }

        public async Task<GlobalResponse<List<MonthlyMosquitoCountPer6MonthDto>>> GetCountOfMosuqitoesPer6Month()
        {
            try
            {
                // Get user role and ID from HTTP context
                var userRole = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value ?? "User";
                var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                
                if (!Guid.TryParse(userIdClaim, out Guid userId))
                {
                    return new GlobalResponse<List<MonthlyMosquitoCountPer6MonthDto>>
                    {
                        IsSuccess = false,
                        Message = "Invalid user ID",
                        StatusCode = HttpStatusCode.Unauthorized,
                        Data = new List<MonthlyMosquitoCountPer6MonthDto>()
                    };
                }

                // Calculate date range for last 6 months starting from current month
                var currentDate = DateTime.Now;
                var startDate = new DateTime(currentDate.AddMonths(-5).Year, currentDate.AddMonths(-5).Month, 1);
                var endDate = new DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month));

                IQueryable<ReadDetails> readDetailsQuery;

                if (userRole == RoleName.Superadmin)
                {
                    // SuperAdmin gets all trap read data
                    readDetailsQuery = _unitOfWork.ReadDetailsRepository.GetAllQueryableAsNoTracking()
                        .Include(rd => rd.TrapRead)
                        .Where(rd => rd.TrapRead.Date >= DateOnly.FromDateTime(startDate) && 
                                   rd.TrapRead.Date <= DateOnly.FromDateTime(endDate));
                }
                else
                {
                    // Regular user gets only their trap data
                    readDetailsQuery = _unitOfWork.ReadDetailsRepository.GetAllQueryableAsNoTracking()
                        .Include(rd => rd.TrapRead)
                        .ThenInclude(tr => tr.Trap)
                        .ThenInclude(t => t.UserTraps)
                        .Where(rd => rd.TrapRead.Date >= DateOnly.FromDateTime(startDate) && 
                                   rd.TrapRead.Date <= DateOnly.FromDateTime(endDate) &&
                                   rd.TrapRead.Trap.UserTraps.Any(ut => ut.UserId == userId));
                }

                var readDetailsData = await readDetailsQuery.ToListAsync();

                // Arabic month names mapping
                var arabicMonths = new Dictionary<int, string>
                {
                    { 1, "يناير" }, { 2, "فبراير" }, { 3, "مارس" }, { 4, "أبريل" },
                    { 5, "مايو" }, { 6, "يونيو" }, { 7, "يوليو" }, { 8, "أغسطس" },
                    { 9, "سبتمبر" }, { 10, "أكتوبر" }, { 11, "نوفمبر" }, { 12, "ديسمبر" }
                };

                // Create a list of all months in the range to ensure all months are included
                var allMonths = new List<MonthlyMosquitoCountPer6MonthDto>();
                for (int i = 0; i < 6; i++)
                {
                    var monthDate = currentDate.AddMonths(-5 + i);
                    allMonths.Add(new MonthlyMosquitoCountPer6MonthDto
                    {
                        DateInNumber = monthDate.Month,
                        DateOfMonth = $"{monthDate.Year}-{monthDate.Month:D2}-01",
                        Date = arabicMonths[monthDate.Month],
                        InsectsCount = 0
                    });
                }

                // Group actual data by month and calculate monthly statistics
                var actualStats = readDetailsData
                    .GroupBy(rd => new { 
                        Year = rd.TrapRead.Date.Year, 
                        Month = rd.TrapRead.Date.Month 
                    })
                    .ToDictionary(g => g.Key.Month, g => g.Sum(rd => rd.ReadingMosuqitoes));

                // Update the counts for months that have data
                foreach (var month in allMonths)
                {
                    if (actualStats.ContainsKey(month.DateInNumber))
                    {
                        month.InsectsCount = actualStats[month.DateInNumber];
                    }
                }

                var monthlyStats = allMonths.ToList();

                return new GlobalResponse<List<MonthlyMosquitoCountPer6MonthDto>>
                {
                    IsSuccess = true,
                    Message = "Monthly mosquito statistics for last 6 months retrieved successfully",
                    StatusCode = HttpStatusCode.OK,
                    Data = monthlyStats
                };
            }
            catch (Exception ex)
            {
                return new GlobalResponse<List<MonthlyMosquitoCountPer6MonthDto>>
                {
                    IsSuccess = false,
                    Message = "Error retrieving monthly mosquito statistics",
                    StatusCode = HttpStatusCode.InternalServerError,
                    Data = new List<MonthlyMosquitoCountPer6MonthDto>()
                };
            }
        }

        public async Task<Response<IEnumerable<GetCountOfMosuqitoesPer6MonthResponse>>> GetMosquitoStatisticsLast6Months()
        {
            try
            {
                // Get user role and ID from HTTP context
                var userRole = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value ?? "User";
                var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                
                if (!Guid.TryParse(userIdClaim, out Guid userId))
                {
                    return new Response<IEnumerable<GetCountOfMosuqitoesPer6MonthResponse>>
                    {
                        IsSuccess = false,
                        Message = "Invalid user ID",
                        Data = new List<GetCountOfMosuqitoesPer6MonthResponse>()
                    };
                }

                // Call the repository method with userId parameter for role-based filtering
                var statistics = await _unitOfWork.TrapReadRepository.GetMosquitoStatisticsLast6Months(userId, userRole);

                return new Response<IEnumerable<GetCountOfMosuqitoesPer6MonthResponse>>
                {
                    IsSuccess = true,
                    Message = "Mosquito statistics for last 6 months retrieved successfully",
                    Data = statistics
                };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<GetCountOfMosuqitoesPer6MonthResponse>>
                {
                    IsSuccess = false,
                    Message = "Error retrieving mosquito statistics",
                    Data = new List<GetCountOfMosuqitoesPer6MonthResponse>()
                };
            }
        }

        
        
        #region Helpers
        private Guid GetUserId() =>
            Guid.Parse(_httpContextAccessor!.HttpContext == null ? string.Empty : _httpContextAccessor!.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier));
        #endregion

    }
}
