using Core.Entities;
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
                new Category { Id = 2, Name = "Afaq" },
                new Category { Id = 3, Name = "Industrial" },
                new Category { Id = 4, Name = "Agricultural" },
                new Category { Id = 5, Name = "Residential" },
                new Category { Id = 6, Name = "Commercial" }
                );

            // Company seeding data
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "TechCorp Solutions" },
                new Company { Id = 2, Name = "Green Valley Industries" },
                new Company { Id = 3, Name = "Desert Shield Technologies" },
                new Company { Id = 4, Name = "Oasis Environmental Systems" },
                new Company { Id = 5, Name = "Gulf Monitoring Services" },
                new Company { Id = 6, Name = "Smart Trap Solutions" },
                new Company { Id = 7, Name = "EcoGuard Systems" },
                new Company { Id = 8, Name = "Advanced Pest Control" },
                new Company { Id = 9, Name = "Regional Safety Corp" },
                new Company { Id = 10, Name = "Innovation Labs Ltd" }
                );

            // Trap seeding data
            modelBuilder.Entity<Trap>().HasData(
                new Trap { Id = 1, Name = "Cairo Central Trap", SerialNumber = "TRP001", CategoryId = 2, StateId = 1, IsNew = true, TrapStatus = 1, IsCounterOn = true, IsScheduleOn = false, IsThereEmergency = false, IsCounterReadingFromSimCard = true, Lat = "30.0444", Long = "31.2357" },
                new Trap { Id = 2, Name = "Alexandria Port Trap", SerialNumber = "TRP002", CategoryId = 3, StateId = 2, IsNew = false, TrapStatus = 1, IsCounterOn = true, IsScheduleOn = true, IsThereEmergency = false, IsCounterReadingFromSimCard = true, Lat = "31.2001", Long = "29.9187" },
                new Trap { Id = 3, Name = "Giza Industrial Trap", SerialNumber = "TRP003", CategoryId = 4, StateId = 3, IsNew = false, TrapStatus = 1, IsCounterOn = true, IsScheduleOn = false, IsThereEmergency = false, IsCounterReadingFromSimCard = false, Lat = "30.0131", Long = "31.2089" },
                new Trap { Id = 4, Name = "Riyadh Smart Trap", SerialNumber = "TRP004", CategoryId = 2, StateId = 26, IsNew = true, TrapStatus = 1, IsCounterOn = true, IsScheduleOn = true, IsThereEmergency = false, IsCounterReadingFromSimCard = true, Lat = "24.7136", Long = "46.6753" },
                new Trap { Id = 5, Name = "Dubai Advanced Trap", SerialNumber = "TRP005", CategoryId = 5, StateId = 41, IsNew = false, TrapStatus = 1, IsCounterOn = true, IsScheduleOn = false, IsThereEmergency = false, IsCounterReadingFromSimCard = true, Lat = "25.2048", Long = "55.2708" },
                new Trap { Id = 6, Name = "Doha Monitoring Trap", SerialNumber = "TRP006", CategoryId = 6, StateId = 48, IsNew = true, TrapStatus = 1, IsCounterOn = true, IsScheduleOn = true, IsThereEmergency = false, IsCounterReadingFromSimCard = false, Lat = "25.2854", Long = "51.5310" },
                new Trap { Id = 7, Name = "Jeddah Coastal Trap", SerialNumber = "TRP007", CategoryId = 3, StateId = 27, IsNew = false, TrapStatus = 1, IsCounterOn = true, IsScheduleOn = false, IsThereEmergency = false, IsCounterReadingFromSimCard = true, Lat = "21.4858", Long = "39.1925" },
                new Trap { Id = 8, Name = "Abu Dhabi Control Trap", SerialNumber = "TRP008", CategoryId = 4, StateId = 42, IsNew = true, TrapStatus = 1, IsCounterOn = true, IsScheduleOn = true, IsThereEmergency = false, IsCounterReadingFromSimCard = true, Lat = "24.4539", Long = "54.3773" },
                new Trap { Id = 9, Name = "Aswan Desert Trap", SerialNumber = "TRP009", CategoryId = 2, StateId = 7, IsNew = false, TrapStatus = 1, IsCounterOn = true, IsScheduleOn = false, IsThereEmergency = false, IsCounterReadingFromSimCard = false, Lat = "24.0889", Long = "32.8998" },
                new Trap { Id = 10, Name = "Sharjah Tech Trap", SerialNumber = "TRP010", CategoryId = 5, StateId = 43, IsNew = true, TrapStatus = 1, IsCounterOn = true, IsScheduleOn = true, IsThereEmergency = false, IsCounterReadingFromSimCard = true, Lat = "25.3463", Long = "55.4209" }
                );

            // TrapRead seeding data (150 records across 10 traps for past 6 months)
            var trapReads = new List<object>();
            var readDetails = new List<object>();
            int trapReadId = 1;
            int readDetailId = 1;
            // Static arrays to replace random values
             var dayIntervals = new int[] { 2, 1, 3, 2, 1, 2, 3, 1, 2, 1 };
             var serverDelays = new int[] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 };
             var detailsCounts = new int[] { 5, 6, 4, 7, 5, 6, 4, 5, 6, 7 };
             var timeHours = new int[] { 8, 12, 16, 20, 6, 10, 14, 18, 22, 2 };
             var timeMinutes = new int[] { 15, 30, 45, 0, 20, 35, 50, 5, 25, 40 };
             var counters = new int[] { 450, 320, 780, 650, 290, 540, 870, 410, 690, 520 };
             var fans = new int[] { 1, 0, 1, 1, 0, 1, 0, 1, 0, 1 };
             var co2Values = new int[] { 450, 520, 380, 620, 340, 580, 490, 430, 560, 410 };
             var smallReadings = new int[] { 25, 35, 18, 42, 28, 31, 22, 38, 26, 33 };
             var largReadings = new int[] { 12, 18, 8, 22, 15, 19, 10, 16, 13, 20 };
             var mosquitoes = new int[] { 55, 72, 38, 84, 46, 68, 51, 79, 42, 63 };
             var tempIns = new int[] { 28, 32, 25, 30, 27, 31, 26, 29, 33, 24 };
             var tempOuts = new int[] { 22, 35, 18, 38, 20, 33, 25, 36, 19, 31 };
             var windSpeeds = new int[] { 8, 12, 5, 15, 7, 10, 6, 14, 9, 11 };
             var humidities = new int[] { 65, 45, 72, 38, 58, 51, 69, 42, 61, 48 };
             var flies = new int[] { 18, 25, 12, 28, 15, 22, 19, 26, 14, 21 };
             var bigBatteries = new int[] { 92, 85, 96, 88, 91, 87, 94, 89, 93, 86 };
             var smallBatteries = new int[] { 78, 85, 72, 88, 75, 82, 79, 86, 74, 81 };
             var isDoneValues = new bool[] { true, false, true, true, false, true, false, true, false, true };
             var isCleanValues = new bool[] { false, true, false, true, true, false, true, false, true, false };
             
             // Static dates - each trap gets 15 unique dates
             var baseDates = new DateOnly[] {
                 new DateOnly(2024, 1, 1), new DateOnly(2024, 1, 3), new DateOnly(2024, 1, 5), new DateOnly(2024, 1, 7),
                 new DateOnly(2024, 1, 9), new DateOnly(2024, 1, 11), new DateOnly(2024, 1, 13), new DateOnly(2024, 1, 15),
                 new DateOnly(2024, 1, 17), new DateOnly(2024, 1, 19), new DateOnly(2024, 1, 21), new DateOnly(2024, 1, 23),
                 new DateOnly(2024, 1, 25), new DateOnly(2024, 1, 27), new DateOnly(2024, 1, 29)
             };
             var baseServerDates = new DateOnly[] {
                 new DateOnly(2024, 1, 1), new DateOnly(2024, 1, 4), new DateOnly(2024, 1, 5), new DateOnly(2024, 1, 8),
                 new DateOnly(2024, 1, 9), new DateOnly(2024, 1, 12), new DateOnly(2024, 1, 13), new DateOnly(2024, 1, 16),
                 new DateOnly(2024, 1, 17), new DateOnly(2024, 1, 20), new DateOnly(2024, 1, 21), new DateOnly(2024, 1, 24),
                 new DateOnly(2024, 1, 25), new DateOnly(2024, 1, 28), new DateOnly(2024, 1, 29)
             };

            // Generate completely unique dates for each TrapRead
            var startDate = new DateOnly(2024, 1, 1);
            for (int trapId = 1; trapId <= 10; trapId++)
             {
                 for (int dateIndex = 0; dateIndex < baseDates.Length && trapReadId <= 150; dateIndex++)
                 {
                     // Each TrapRead gets a unique sequential date
                     var readDate = startDate.AddDays((trapReadId - 1) * 2); // 2 days apart
                     var serverDate = readDate.AddDays(1); // Server date is 1 day after read date
                     
                     trapReads.Add(new { Id = trapReadId, Date = readDate, ServerCreationDate = serverDate, TrapId = trapId });
                    
                    // Add static number of ReadDetails per TrapRead
                    int detailsCount = detailsCounts[(trapReadId - 1) % detailsCounts.Length];
                    for (int detail = 0; detail < detailsCount; detail++)
                    {
                        var timeHour = timeHours[(readDetailId - 1) % timeHours.Length];
                        var timeMinute = timeMinutes[(readDetailId - 1) % timeMinutes.Length];
                        var time = new TimeOnly(timeHour, timeMinute);
                        readDetails.Add(new {
                            Id = readDetailId,
                            Time = time,
                            SerialNumber = $"SN{trapId:D3}{readDetailId:D6}",
                            ReadingLat = "0.0",
                            ReadingLng = "0.0",
                            Counter = counters[(readDetailId - 1) % counters.Length],
                            Fan = fans[(readDetailId - 1) % fans.Length],
                            Co2 = co2Values[(readDetailId - 1) % co2Values.Length],
                            Co2Val = co2Values[(readDetailId - 1) % co2Values.Length].ToString(),
                            ReadingSmall = smallReadings[(readDetailId - 1) % smallReadings.Length],
                            ReadingLarg = largReadings[(readDetailId - 1) % largReadings.Length],
                            ReadingMosuqitoes = mosquitoes[(readDetailId - 1) % mosquitoes.Length],
                            ReadingTempIn = tempIns[(readDetailId - 1) % tempIns.Length].ToString(),
                            ReadingTempOut = tempOuts[(readDetailId - 1) % tempOuts.Length].ToString(),
                            ReadingWindSpeed = windSpeeds[(readDetailId - 1) % windSpeeds.Length].ToString(),
                            ReadingHumidty = humidities[(readDetailId - 1) % humidities.Length].ToString(),
                            ReadingFly = flies[(readDetailId - 1) % flies.Length],
                            BigBattery = bigBatteries[(readDetailId - 1) % bigBatteries.Length].ToString(),
                            SmallBattery = smallBatteries[(readDetailId - 1) % smallBatteries.Length].ToString(),
                            IsDone = isDoneValues[(readDetailId - 1) % isDoneValues.Length],
                            IsClean = isCleanValues[(readDetailId - 1) % isCleanValues.Length],
                            TrapReadId = trapReadId
                        });
                        readDetailId++;
                    }
                     trapReadId++;
                     
                     if (trapReadId > 150) break; // Limit to 150 TrapReads total
                }
                if (trapReadId > 150) break;
            }

            modelBuilder.Entity<TrapRead>().HasData(trapReads.ToArray());
            modelBuilder.Entity<ReadDetails>().HasData(readDetails.ToArray());

            // User seeding data
            var users = new List<User>();
            var userTraps = new List<object>();
            var userIds = new Guid[]
            {
                new Guid("11111111-1111-1111-1111-111111111111"),
                new Guid("22222222-2222-2222-2222-222222222222"),
                new Guid("33333333-3333-3333-3333-333333333333"),
                new Guid("44444444-4444-4444-4444-444444444444"),
                new Guid("55555555-5555-5555-5555-555555555555")
            };

            for (int i = 0; i < 5; i++)
            {
                users.Add(new User
                {
                    Id = userIds[i],
                    UserName = $"user{i + 1}@example.com",
                    NormalizedUserName = $"USER{i + 1}@EXAMPLE.COM",
                    Email = $"user{i + 1}@example.com",
                    NormalizedEmail = $"USER{i + 1}@EXAMPLE.COM",
                    Name = $"User {i + 1}",
                    EmailConfirmed = true,
                    IsLocked = false,
                    LockReason = null,
                    ParentUserId = i > 0 ? userIds[0] : null, // First user is parent, others are children
                    PasswordHash = "AQAAAAEAACcQAAAAEJ7t2Kd8Qz9QzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQ=" // Static hash for Pass123!
                });
            }

            modelBuilder.Entity<User>().HasData(users.ToArray());

            // UserTraps relationships - assign traps to users
            int userTrapId = 1;
            for (int trapId = 1; trapId <= 10; trapId++)
            {
                int assignedUserId = (trapId - 1) % 5; // Distribute traps among 5 users
                userTraps.Add(new { Id = userTrapId++, UserId = userIds[assignedUserId], TrapId = trapId });
            }

            modelBuilder.Entity<UserTraps>().HasData(userTraps.ToArray());

            // Schedule data for traps that have IsScheduleOn = true
            var counterSchedules = new List<object>();
            var fanSchedules = new List<object>();
            var valveSchedules = new List<object>();
            int scheduleId = 1;

            var scheduledTraps = new int[] { 2, 4, 6, 8, 10 }; // Traps with IsScheduleOn = true
            foreach (var trapId in scheduledTraps)
            {
                // Counter schedules (every 6 hours)
                for (int hour = 0; hour < 24; hour += 6)
                {
                    counterSchedules.Add(new { Id = scheduleId++, ScdTime = hour, Status = true, TrapId = trapId });
                }
                
                // Fan schedules (every 8 hours)
                for (int hour = 2; hour < 24; hour += 8)
                {
                    fanSchedules.Add(new { Id = scheduleId++, ScdTime = hour, Status = true, TrapId = trapId });
                }
                
                // Valve schedules (every 12 hours)
                for (int hour = 4; hour < 24; hour += 12)
                {
                    valveSchedules.Add(new { Id = scheduleId++, ScdTime = hour, Status = true, TrapId = trapId });
                }
            }

            modelBuilder.Entity<TrapCounterSchedule>().HasData(counterSchedules.ToArray());
            modelBuilder.Entity<TrapFanSchedule>().HasData(fanSchedules.ToArray());
            modelBuilder.Entity<TrapValveQutSchedule>().HasData(valveSchedules.ToArray());
            #endregion


        }
    }
}
