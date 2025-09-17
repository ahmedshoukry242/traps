using Core.DTOs;
using Core.DTOs.Trap.Statistic;
using Core.DTOs.Trap.TrapRead;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.IServices
{
    public interface ITrapReadService
    {
        Task<GlobalResponse> CreateTrapReading(ReadDetailsCreateDto dto);
        Task<GlobalResponse> GetAllTrapReadingsAsync(ReadRequestDto model);
<<<<<<< HEAD
        Task<GlobalResponse> GetTrapsLastRead(int? trapId);
        Task<GlobalResponse> GetAllTrapReadingsPerDayAsync(ReadRequestDto model);
        Task<GlobalResponse> GetAllTrapReadsChart(ReadRequestChartDto model);
=======
>>>>>>> 6dc54f52fc3abb17fb486d0ee41845f0bfc02dbb
        Task<GlobalResponse<StatisticsDto>> GetUserTrapStatistics(Guid userId);
        Task<MonthlyMosquitoCountResponseDto> GetCountOfMosuqitoesToLast12Months();
        Task<GlobalResponse<List<MonthlyMosquitoCountPer6MonthDto>>> GetCountOfMosuqitoesPer6Month();
        Task<Response<IEnumerable<GetCountOfMosuqitoesPer6MonthResponse>>> GetMosquitoStatisticsLast6Months();
    }
}
