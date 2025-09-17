using Core.Entities;
using Core.Entities.Auth;
using Core.Entities.Lookups;
using Infrastructure.Seeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class TrapDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid,IdentityUserClaim<Guid>,IdentityUserRole<Guid>,IdentityUserLogin<Guid>,IdentityRoleClaim<Guid>,IdentityUserToken<Guid>>
    {
        public TrapDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");

            modelBuilder.SeedData();
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Trap> Traps { get; set; }
        public DbSet<UserTraps> UserTraps { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<ReadDetails> ReadDetails { get; set; }

    }
}
