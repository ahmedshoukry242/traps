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
        Task<GlobalResponse<StatisticsDto>> GetUserTrapStatistics(Guid userId);
        Task<MonthlyMosquitoCountResponseDto> GetCountOfMosuqitoesToLast12Months();
        Task<GlobalResponse<List<MonthlyMosquitoCountPer6MonthDto>>> GetCountOfMosuqitoesPer6Month();
        Task<Response<IEnumerable<GetCountOfMosuqitoesPer6MonthResponse>>> GetMosquitoStatisticsLast6Months();
    }
}
