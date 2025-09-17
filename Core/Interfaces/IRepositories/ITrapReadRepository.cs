using Core.DTOs.Trap.TrapRead;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.IRepositories
{
    public interface ITrapReadRepository : IBaseRepository<TrapRead>
    {
        Task<IEnumerable<GetCountOfMosuqitoesPer6MonthResponse>> GetMosquitoStatisticsLast6Months(Guid userId, string userRole);
    }
}