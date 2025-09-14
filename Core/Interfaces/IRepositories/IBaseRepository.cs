using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRangeAsync(IEnumerable<T> entities);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetAllQueryable();
        IQueryable<T> GetAllQueryableAsNoTracking();
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
    }
}
