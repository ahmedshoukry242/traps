using Core.Entities;
using Core.Entities.Auth;
using Core.Entities.Lookups;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {

        IBaseRepository<User> Users { get; }
        IBaseRepository<IdentityRole<Guid>> RoleRepository { get; }
        IBaseRepository<IdentityUserRole<Guid>> UserRolesrepository { get;}
        IBaseRepository<Company> CompanyRepository { get; }
        IBaseRepository<Trap> TrapRepository { get; }
        IBaseRepository<UserTraps> UserTrapsRepository { get; }
        ITrapReadRepository TrapReadRepository { get; }
        IBaseRepository<ReadDetails> ReadDetailsRepository { get; }
        IBaseRepository<TrapValveQutSchedule> TrapValveQutScheduleRepository { get; }
        IBaseRepository<TrapFanSchedule> TrapFanScheduleRepository { get; }
        IBaseRepository<TrapCounterSchedule> TrapCounterScheduleRepository { get; }
        IBaseRepository<Country> CountryRepository { get; }
        IBaseRepository<State> StateRepository { get; }
        IBaseRepository<Category> CategoryRepository { get; }
        IBaseRepository<TrapEmergency> TrapEmergencyRepository { get; }


        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        Task DisposeTransactionAsync();

        Task<bool> SaveChangesAsync();

    }
}
