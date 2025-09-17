using Core.Entities;
using Core.Entities.Auth;
using Core.Entities.Lookups;
using Core.Interfaces.IRepositories;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private TrapDbContext _context;
        private IDbContextTransaction _transaction;

        public IBaseRepository<User> Users { get; private set; }
        public IBaseRepository<IdentityRole<Guid>> RoleRepository { get; private set; }
        public IBaseRepository<IdentityUserRole<Guid>> UserRolesrepository { get; private set; }
        public IBaseRepository<Company> CompanyRepository { get; private set; }
        public IBaseRepository<Trap> TrapRepository { get; private set; }
        public IBaseRepository<UserTraps> UserTrapsRepository { get; private set; }
        public ITrapReadRepository TrapReadRepository { get; private set; }
        public IBaseRepository<ReadDetails> ReadDetailsRepository { get; private set; }
        public IBaseRepository<TrapValveQutSchedule> TrapValveQutScheduleRepository { get; private set; }
        public IBaseRepository<TrapFanSchedule> TrapFanScheduleRepository { get; private set; }
        public IBaseRepository<TrapCounterSchedule> TrapCounterScheduleRepository { get; private set; }
        public IBaseRepository<Country> CountryRepository { get; private set; }
        public IBaseRepository<State> StateRepository { get; private set; }
        public IBaseRepository<Category> CategoryRepository { get; private set; }
        public IBaseRepository<TrapEmergency> TrapEmergencyRepository { get; private set; }


        public UnitOfWork(TrapDbContext context)
        {
            _context = context;
            Users = new BaseRepository<User>(_context);
            RoleRepository = new BaseRepository<IdentityRole<Guid>>(_context);
            UserRolesrepository = new BaseRepository<IdentityUserRole<Guid>>(_context);
            CompanyRepository = new BaseRepository<Company>(_context);
            TrapRepository = new BaseRepository<Trap>(_context);
            UserTrapsRepository = new BaseRepository<UserTraps>(_context);
            TrapReadRepository = new TrapReadRepository(_context);
            ReadDetailsRepository = new BaseRepository<ReadDetails>(_context);
            TrapValveQutScheduleRepository = new BaseRepository<TrapValveQutSchedule>(_context);
            TrapFanScheduleRepository = new BaseRepository<TrapFanSchedule>(_context);
            TrapCounterScheduleRepository = new BaseRepository<TrapCounterSchedule>(_context);
            CountryRepository = new BaseRepository<Country>(_context);
            StateRepository = new BaseRepository<State>(_context);
            CategoryRepository = new BaseRepository<Category>(_context);
            TrapEmergencyRepository = new BaseRepository<TrapEmergency>(_context);

        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }
        public async Task CommitTransactionAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                if (_transaction != null)
                    await DisposeTransactionAsync();
            }
        }
        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
                await _transaction.RollbackAsync();
        }
        public async Task DisposeTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();

                _transaction = null;
            }
        }
        public async Task<bool> SaveChangesAsync()
        {
            var res = await _context.SaveChangesAsync();
            return res > 0;
        }
        public void Dispose() => _context.Dispose();
    }
}
