using Core.Constants;
using Core.DTOs.Trap.TrapRead;
using Core.Entities;
using Core.Interfaces.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TrapReadRepository : BaseRepository<TrapRead>, ITrapReadRepository
    {
        private readonly TrapDbContext _context;

        public TrapReadRepository(TrapDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetCountOfMosuqitoesPer6MonthResponse>> GetMosquitoStatisticsLast6Months(Guid userId, string userRole)
        {
            try
            {
                var endDate = DateTime.Now;
                var startDate = endDate.AddMonths(-6);

                // Arabic month names
                var arabicMonths = new Dictionary<int, string>
                {
                    { 1, "يناير" }, { 2, "فبراير" }, { 3, "مارس" }, { 4, "أبريل" },
                    { 5, "مايو" }, { 6, "يونيو" }, { 7, "يوليو" }, { 8, "أغسطس" },
                    { 9, "سبتمبر" }, { 10, "أكتوبر" }, { 11, "نوفمبر" }, { 12, "ديسمبر" }
                };

                IQueryable<ReadDetails> readDetailsQuery;

                if (userRole == RoleName.Superadmin)
                {
                    // SuperAdmin gets all trap read data
                    readDetailsQuery = _context.ReadDetails
                        .Include(rd => rd.TrapRead)
                        .ThenInclude(tr => tr.Trap)
                        .Where(rd => rd.TrapRead.Date >= DateOnly.FromDateTime(startDate) && 
                                    rd.TrapRead.Date <= DateOnly.FromDateTime(endDate));
                }
                else
                {
                    // Regular user gets only their trap data
                    readDetailsQuery = _context.ReadDetails
                        .Include(rd => rd.TrapRead)
                        .ThenInclude(tr => tr.Trap)
                        .ThenInclude(t => t.UserTraps)
                        .Where(rd => rd.TrapRead.Date >= DateOnly.FromDateTime(startDate) && 
                                    rd.TrapRead.Date <= DateOnly.FromDateTime(endDate) &&
                                    rd.TrapRead.Trap.UserTraps.Any(ut => ut.UserId == userId));
                }

                var readDetailsData = await readDetailsQuery.ToListAsync();

                // Create list for all 6 months (initialize with zeros)
                var allMonths = new List<GetCountOfMosuqitoesPer6MonthResponse>();
                for (int i = 0; i < 6; i++)
                {
                    var monthDate = endDate.AddMonths(-5 + i);
                    allMonths.Add(new GetCountOfMosuqitoesPer6MonthResponse
                    {
                        DateInNumber = monthDate.Month,
                        DateOfMonth = new DateOnly(monthDate.Year, monthDate.Month, 1).ToString("yyyy-MM-dd"),
                        Date = GetArabicMonthName(monthDate.Month),
                        InsectsCount = 0
                    });
                }

                // Group actual data by month and calculate monthly statistics
                var actualStats = readDetailsData
                    .GroupBy(rd => new { 
                        Year = rd.TrapRead.Date.Year, 
                        Month = rd.TrapRead.Date.Month 
                    })
                    .ToDictionary(g => g.Key.Month, g => new {
                        InsectsCount = g.Sum(rd => rd.ReadingMosuqitoes)
                    });

                // Update the counts for months that have data
                foreach (var month in allMonths)
                {
                    if (actualStats.ContainsKey(month.DateInNumber))
                    {
                        var stats = actualStats[month.DateInNumber];
                        month.InsectsCount = stats.InsectsCount;
                    }
                }

                return allMonths;
            }
            catch (Exception)
            {
                return new List<GetCountOfMosuqitoesPer6MonthResponse>();
            }
        }

        private string GetArabicMonthName(int monthNumber)
        {
            var arabicMonths = new Dictionary<int, string>
            {
                { 1, "يناير" },
                { 2, "فبراير" },
                { 3, "مارس" },
                { 4, "أبريل" },
                { 5, "مايو" },
                { 6, "يونيو" },
                { 7, "يوليو" },
                { 8, "أغسطس" },
                { 9, "سبتمبر" },
                { 10, "أكتوبر" },
                { 11, "نوفمبر" },
                { 12, "ديسمبر" }
            };

            return arabicMonths.ContainsKey(monthNumber) ? arabicMonths[monthNumber] : monthNumber.ToString();
        }
    }
}