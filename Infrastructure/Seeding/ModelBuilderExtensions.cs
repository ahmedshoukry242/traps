using Core.Entities.Auth;
using Core.Entities.Lookups;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seeding
{
    public static class ModelBuilderExtensions
    {

        public static readonly Guid SuperAdminRole = new Guid("fab4fac1-c546-41de-aebc-a14da6895711");
        public static readonly Guid SubAdminRole = new Guid("fab4fac1-c546-41de-aebc-a14da6895712");
        public static readonly Guid SuperVisorRole = new Guid("fab4fac1-c546-41de-aebc-a14da6895713");
        public static readonly Guid UserRole = new Guid("fab4fac1-c546-41de-aebc-a14da6895716");
        public static readonly Guid UserChildRole = new Guid("fab4fac1-c546-41de-aebc-a14da6895717");


        public static readonly Guid SuperAdminUser = new Guid("fab4fac1-c546-41de-aebc-a14da6895714");

        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region Seed SuperAdmin Account
           
            //modelBuilder.Entity<IdentityRole<Guid>>().HasData(
            //    new IdentityRole<Guid>() { Id = SuperAdminRole, Name = "SuperAdmin", ConcurrencyStamp = "1", NormalizedName = "SUPERADMIN" }
            //);

            //modelBuilder.Entity<IdentityRole<Guid>>().HasData(
            //    new IdentityRole<Guid>() { Id = SubAdminRole, Name = "SubAdmin", ConcurrencyStamp = "1", NormalizedName = "SUBADMIN" }
            //);

            //modelBuilder.Entity<IdentityRole<Guid>>().HasData(
            //    new IdentityRole<Guid>() { Id = SuperVisorRole, Name = "SuperVisor", ConcurrencyStamp = "1", NormalizedName = "SUPERVISOR" }
            //);

            //User admin = new()
            //{
            //    Id = SuperAdminUser,
            //    UserName = "SuperAdmin",
            //    NormalizedUserName = "SUPERADMIN",
            //    Email = "Admin@gmail.com",
            //    NormalizedEmail = "ADMIN@GMAIL.COM",
            //    Name = "SuperAdmin",
            //    LockoutEnabled = false,
            //    EmailConfirmed = true,
            //    PasswordHash = new PasswordHasher<User>().HashPassword(null!, "Admin1234")
            //};
            //modelBuilder.Entity<User>().HasData(admin);
            //modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
            //   new IdentityUserRole<Guid>() { RoleId = SuperAdminRole, UserId = SuperAdminUser }
            //);

            #endregion

            #region Seed User Role

            //modelBuilder.Entity<IdentityRole<Guid>>().HasData(
            //    new IdentityRole<Guid>() { Id = UserRole, Name = "User", ConcurrencyStamp = "1", NormalizedName = "USER" }
            //);

            //modelBuilder.Entity<IdentityRole<Guid>>().HasData(
            //    new IdentityRole<Guid>() { Id = UserChildRole, Name = "UserChild", ConcurrencyStamp = "1", NormalizedName = "USERCHILD" }
            //);

            #endregion

            #region Lookups

            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Egypt", TimeZoneName = "Africa/Cairo", UtcOffsetMinutes = 120 },
                new Country { Id = 2, Name = "Saudi Arabia", TimeZoneName = "Asia/Riyadh", UtcOffsetMinutes = 180 },
                new Country { Id = 3, Name = "United Arab Emirates", TimeZoneName = "Asia/Dubai", UtcOffsetMinutes = 240 },
                new Country { Id = 4, Name = "Qatar", TimeZoneName = "Asia/Qatar", UtcOffsetMinutes = 180 }
                );


            modelBuilder.Entity<State>().HasData(

                new State { Id = 1, Name = "Cairo", CountryId = 1 },
                new State { Id = 2, Name = "Alexandria", CountryId = 1 },
                new State { Id = 3, Name = "Giza", CountryId = 1 },
                new State { Id = 4, Name = "Damietta", CountryId = 1 },
                new State { Id = 5, Name = "Port Said", CountryId = 1 },
                new State { Id = 6, Name = "Suez", CountryId = 1 },
                new State { Id = 7, Name = "Aswan", CountryId = 1 },
                new State { Id = 8, Name = "Luxor", CountryId = 1 },
                new State { Id = 9, Name = "Qena", CountryId = 1 },
                new State { Id = 10, Name = "Sohag", CountryId = 1 },
                new State { Id = 11, Name = "Ismailia", CountryId = 1 },
                new State { Id = 12, Name = "Menofia", CountryId = 1 },
                new State { Id = 13, Name = "Qalyubia", CountryId = 1 },
                new State { Id = 14, Name = "Sharqia", CountryId = 1 },
                new State { Id = 15, Name = "Beheira", CountryId = 1 },
                new State { Id = 16, Name = "Fayoum", CountryId = 1 },
                new State { Id = 17, Name = "Minya", CountryId = 1 },
                new State { Id = 18, Name = "Asyut", CountryId = 1 },
                new State { Id = 19, Name = "Dakahlia", CountryId = 1 },
                new State { Id = 20, Name = "Matruh", CountryId = 1 },
                new State { Id = 21, Name = "Beni Suef", CountryId = 1 },
                new State { Id = 22, Name = "Red Sea", CountryId = 1 },
                new State { Id = 23, Name = "North Sinai", CountryId = 1 },
                new State { Id = 24, Name = "South Sinai", CountryId = 1 },

                //---------------------Saudi Arabia--------------------------
                new State { Id = 26, Name = "Riyadh", CountryId = 2 },
                new State { Id = 27, Name = "Jeddah", CountryId = 2 },
                new State { Id = 28, Name = "Mecca", CountryId = 2 },
                new State { Id = 29, Name = "Medina", CountryId = 2 },
                new State { Id = 30, Name = "Dammam", CountryId = 2 },
                new State { Id = 31, Name = "Khobar", CountryId = 2 },
                new State { Id = 32, Name = "Tabuk", CountryId = 2 },
                new State { Id = 33, Name = "Hail", CountryId = 2 },
                new State { Id = 34, Name = "Qassim", CountryId = 2 },
                new State { Id = 35, Name = "Najran", CountryId = 2 },
                new State { Id = 36, Name = "Jizan", CountryId = 2 },
                new State { Id = 37, Name = "Asir", CountryId = 2 },
                new State { Id = 38, Name = "Al Bahah", CountryId = 2 },
                new State { Id = 39, Name = "Northern Borders", CountryId = 2 },
                new State { Id = 40, Name = "Jouf", CountryId = 2 },


                //---------------------United Arab Emirates--------------------------
                new State { Id = 41, Name = "Dubai", CountryId = 3 },
                new State { Id = 42, Name = "Abu Dhabi", CountryId = 3 },
                new State { Id = 43, Name = "Sharjah", CountryId = 3 },
                new State { Id = 44, Name = "Ajman", CountryId = 3 },
                new State { Id = 45, Name = "Umm Al-Quwain", CountryId = 3 },
                new State { Id = 46, Name = "Fujairah", CountryId = 3 },
                new State { Id = 47, Name = "Ras Al Khaimah", CountryId = 3 },


                //---------------------Qatar--------------------------
                new State { Id = 48, Name = "Doha", CountryId = 4 },
                new State { Id = 49, Name = "Al Wakrah", CountryId = 4 },
                new State { Id = 50, Name = "Al Khor", CountryId = 4 },
                new State { Id = 51, Name = "Mesaieed", CountryId = 4 },
                new State { Id = 52, Name = "Al Rayyan", CountryId = 4 },
                new State { Id = 53, Name = "Al Daayen", CountryId = 4 },
                new State { Id = 54, Name = "Umm Salal", CountryId = 4 }

                );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "None" },
                new Category { Id = 2, Name = "Afaq" }

                );
            #endregion


        }
    }
}
