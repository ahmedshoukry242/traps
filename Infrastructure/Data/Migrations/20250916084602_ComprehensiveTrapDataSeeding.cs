using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ComprehensiveTrapDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrapReads_TrapId_Date",
                table: "TrapReads");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Industrial" },
                    { 4, "Agricultural" },
                    { 5, "Residential" },
                    { 6, "Commercial" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "TechCorp Solutions" },
                    { 2, "Green Valley Industries" },
                    { 3, "Desert Shield Technologies" },
                    { 4, "Oasis Environmental Systems" },
                    { 5, "Gulf Monitoring Services" },
                    { 6, "Smart Trap Solutions" },
                    { 7, "EcoGuard Systems" },
                    { 8, "Advanced Pest Control" },
                    { 9, "Regional Safety Corp" },
                    { 10, "Innovation Labs Ltd" }
                });

            migrationBuilder.InsertData(
                table: "Traps",
                columns: new[] { "Id", "BigBattery", "CategoryId", "CountryId", "Fan", "FileDate", "Iema", "IsCounterOn", "IsCounterReadingFromSimCard", "IsNew", "IsScheduleOn", "IsThereEmergency", "LastLat", "LastLong", "Lat", "Long", "Name", "ReadingDate", "SerialNumber", "SmallBattery", "StateId", "TrapStatus", "ValveQut" },
                values: new object[,]
                {
                    { 1, null, 2, null, null, null, null, true, true, true, false, false, null, null, "30.0444", "31.2357", "Cairo Central Trap", null, "TRP001", null, 1, 1, null },
                    { 4, null, 2, null, null, null, null, true, true, true, true, false, null, null, "24.7136", "46.6753", "Riyadh Smart Trap", null, "TRP004", null, 26, 1, null },
                    { 9, null, 2, null, null, null, null, true, false, false, false, false, null, null, "24.0889", "32.8998", "Aswan Desert Trap", null, "TRP009", null, 7, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsLocked", "LockReason", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "ParentUserId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), 0, "7237ba19-3191-4ea5-8dc7-9c365a81dc7c", "user1@example.com", true, false, null, false, null, "User 1", "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", null, "AQAAAAEAACcQAAAAEJ7t2Kd8Qz9QzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQ=", null, false, null, false, "user1@example.com" });

            migrationBuilder.InsertData(
                table: "TrapCounterSchedules",
                columns: new[] { "Id", "ScdTime", "Status", "TrapId" },
                values: new object[,]
                {
                    { 10, 0, true, 4 },
                    { 11, 6, true, 4 },
                    { 12, 12, true, 4 },
                    { 13, 18, true, 4 }
                });

            migrationBuilder.InsertData(
                table: "TrapFanSchedules",
                columns: new[] { "Id", "ScdTime", "Status", "TrapId" },
                values: new object[,]
                {
                    { 14, 2, true, 4 },
                    { 15, 10, true, 4 },
                    { 16, 18, true, 4 }
                });

            migrationBuilder.InsertData(
                table: "TrapReads",
                columns: new[] { "Id", "Date", "ServerCreationDate", "TrapId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 1, 1), new DateOnly(2024, 1, 2), 1 },
                    { 2, new DateOnly(2024, 1, 3), new DateOnly(2024, 1, 4), 1 },
                    { 3, new DateOnly(2024, 1, 5), new DateOnly(2024, 1, 6), 1 },
                    { 4, new DateOnly(2024, 1, 7), new DateOnly(2024, 1, 8), 1 },
                    { 5, new DateOnly(2024, 1, 9), new DateOnly(2024, 1, 10), 1 },
                    { 6, new DateOnly(2024, 1, 11), new DateOnly(2024, 1, 12), 1 },
                    { 7, new DateOnly(2024, 1, 13), new DateOnly(2024, 1, 14), 1 },
                    { 8, new DateOnly(2024, 1, 15), new DateOnly(2024, 1, 16), 1 },
                    { 9, new DateOnly(2024, 1, 17), new DateOnly(2024, 1, 18), 1 },
                    { 10, new DateOnly(2024, 1, 19), new DateOnly(2024, 1, 20), 1 },
                    { 11, new DateOnly(2024, 1, 21), new DateOnly(2024, 1, 22), 1 },
                    { 12, new DateOnly(2024, 1, 23), new DateOnly(2024, 1, 24), 1 },
                    { 13, new DateOnly(2024, 1, 25), new DateOnly(2024, 1, 26), 1 },
                    { 14, new DateOnly(2024, 1, 27), new DateOnly(2024, 1, 28), 1 },
                    { 15, new DateOnly(2024, 1, 29), new DateOnly(2024, 1, 30), 1 },
                    { 46, new DateOnly(2024, 3, 31), new DateOnly(2024, 4, 1), 4 },
                    { 47, new DateOnly(2024, 4, 2), new DateOnly(2024, 4, 3), 4 },
                    { 48, new DateOnly(2024, 4, 4), new DateOnly(2024, 4, 5), 4 },
                    { 49, new DateOnly(2024, 4, 6), new DateOnly(2024, 4, 7), 4 },
                    { 50, new DateOnly(2024, 4, 8), new DateOnly(2024, 4, 9), 4 },
                    { 51, new DateOnly(2024, 4, 10), new DateOnly(2024, 4, 11), 4 },
                    { 52, new DateOnly(2024, 4, 12), new DateOnly(2024, 4, 13), 4 },
                    { 53, new DateOnly(2024, 4, 14), new DateOnly(2024, 4, 15), 4 },
                    { 54, new DateOnly(2024, 4, 16), new DateOnly(2024, 4, 17), 4 },
                    { 55, new DateOnly(2024, 4, 18), new DateOnly(2024, 4, 19), 4 },
                    { 56, new DateOnly(2024, 4, 20), new DateOnly(2024, 4, 21), 4 },
                    { 57, new DateOnly(2024, 4, 22), new DateOnly(2024, 4, 23), 4 },
                    { 58, new DateOnly(2024, 4, 24), new DateOnly(2024, 4, 25), 4 },
                    { 59, new DateOnly(2024, 4, 26), new DateOnly(2024, 4, 27), 4 },
                    { 60, new DateOnly(2024, 4, 28), new DateOnly(2024, 4, 29), 4 },
                    { 121, new DateOnly(2024, 8, 28), new DateOnly(2024, 8, 29), 9 },
                    { 122, new DateOnly(2024, 8, 30), new DateOnly(2024, 8, 31), 9 },
                    { 123, new DateOnly(2024, 9, 1), new DateOnly(2024, 9, 2), 9 },
                    { 124, new DateOnly(2024, 9, 3), new DateOnly(2024, 9, 4), 9 },
                    { 125, new DateOnly(2024, 9, 5), new DateOnly(2024, 9, 6), 9 },
                    { 126, new DateOnly(2024, 9, 7), new DateOnly(2024, 9, 8), 9 },
                    { 127, new DateOnly(2024, 9, 9), new DateOnly(2024, 9, 10), 9 },
                    { 128, new DateOnly(2024, 9, 11), new DateOnly(2024, 9, 12), 9 },
                    { 129, new DateOnly(2024, 9, 13), new DateOnly(2024, 9, 14), 9 },
                    { 130, new DateOnly(2024, 9, 15), new DateOnly(2024, 9, 16), 9 },
                    { 131, new DateOnly(2024, 9, 17), new DateOnly(2024, 9, 18), 9 },
                    { 132, new DateOnly(2024, 9, 19), new DateOnly(2024, 9, 20), 9 },
                    { 133, new DateOnly(2024, 9, 21), new DateOnly(2024, 9, 22), 9 },
                    { 134, new DateOnly(2024, 9, 23), new DateOnly(2024, 9, 24), 9 },
                    { 135, new DateOnly(2024, 9, 25), new DateOnly(2024, 9, 26), 9 }
                });

            migrationBuilder.InsertData(
                table: "TrapValveQutSchedules",
                columns: new[] { "Id", "ScdTime", "Status", "TrapId" },
                values: new object[,]
                {
                    { 17, 4, true, 4 },
                    { 18, 16, true, 4 }
                });

            migrationBuilder.InsertData(
                table: "Traps",
                columns: new[] { "Id", "BigBattery", "CategoryId", "CountryId", "Fan", "FileDate", "Iema", "IsCounterOn", "IsCounterReadingFromSimCard", "IsNew", "IsScheduleOn", "IsThereEmergency", "LastLat", "LastLong", "Lat", "Long", "Name", "ReadingDate", "SerialNumber", "SmallBattery", "StateId", "TrapStatus", "ValveQut" },
                values: new object[,]
                {
                    { 2, null, 3, null, null, null, null, true, true, false, true, false, null, null, "31.2001", "29.9187", "Alexandria Port Trap", null, "TRP002", null, 2, 1, null },
                    { 3, null, 4, null, null, null, null, true, false, false, false, false, null, null, "30.0131", "31.2089", "Giza Industrial Trap", null, "TRP003", null, 3, 1, null },
                    { 5, null, 5, null, null, null, null, true, true, false, false, false, null, null, "25.2048", "55.2708", "Dubai Advanced Trap", null, "TRP005", null, 41, 1, null },
                    { 6, null, 6, null, null, null, null, true, false, true, true, false, null, null, "25.2854", "51.5310", "Doha Monitoring Trap", null, "TRP006", null, 48, 1, null },
                    { 7, null, 3, null, null, null, null, true, true, false, false, false, null, null, "21.4858", "39.1925", "Jeddah Coastal Trap", null, "TRP007", null, 27, 1, null },
                    { 8, null, 4, null, null, null, null, true, true, true, true, false, null, null, "24.4539", "54.3773", "Abu Dhabi Control Trap", null, "TRP008", null, 42, 1, null },
                    { 10, null, 5, null, null, null, null, true, true, true, true, false, null, null, "25.3463", "55.4209", "Sharjah Tech Trap", null, "TRP010", null, 43, 1, null }
                });

            migrationBuilder.InsertData(
                table: "UserTraps",
                columns: new[] { "Id", "TrapId", "UserId" },
                values: new object[] { 1, 1, new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsLocked", "LockReason", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "ParentUserId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222222"), 0, "b2f04e23-0bcc-493c-83eb-398fa9eb893d", "user2@example.com", true, false, null, false, null, "User 2", "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", new Guid("11111111-1111-1111-1111-111111111111"), "AQAAAAEAACcQAAAAEJ7t2Kd8Qz9QzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQ=", null, false, null, false, "user2@example.com" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 0, "8768756b-2278-441f-a3b2-73dbb5f47b9d", "user3@example.com", true, false, null, false, null, "User 3", "USER3@EXAMPLE.COM", "USER3@EXAMPLE.COM", new Guid("11111111-1111-1111-1111-111111111111"), "AQAAAAEAACcQAAAAEJ7t2Kd8Qz9QzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQ=", null, false, null, false, "user3@example.com" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), 0, "5b21d9fc-4309-4fee-8731-32853af27441", "user4@example.com", true, false, null, false, null, "User 4", "USER4@EXAMPLE.COM", "USER4@EXAMPLE.COM", new Guid("11111111-1111-1111-1111-111111111111"), "AQAAAAEAACcQAAAAEJ7t2Kd8Qz9QzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQ=", null, false, null, false, "user4@example.com" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), 0, "15f4aaa5-8c8a-4eee-945b-b4b813b3d97a", "user5@example.com", true, false, null, false, null, "User 5", "USER5@EXAMPLE.COM", "USER5@EXAMPLE.COM", new Guid("11111111-1111-1111-1111-111111111111"), "AQAAAAEAACcQAAAAEJ7t2Kd8Qz9QzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQ=", null, false, null, false, "user5@example.com" }
                });

            migrationBuilder.InsertData(
                table: "ReadDetails",
                columns: new[] { "Id", "BigBattery", "Co2", "Co2Val", "Counter", "Fan", "IsClean", "IsDone", "ReadingFly", "ReadingHumidty", "ReadingLarg", "ReadingLat", "ReadingLng", "ReadingMosuqitoes", "ReadingSmall", "ReadingTempIn", "ReadingTempOut", "ReadingWindSpeed", "SerialNumber", "SmallBattery", "Time", "TrapReadId" },
                values: new object[,]
                {
                    { 1, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN001000001", "78", new TimeSpan(0, 8, 15, 0, 0), 1 },
                    { 2, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN001000002", "85", new TimeSpan(0, 12, 30, 0, 0), 1 },
                    { 3, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN001000003", "72", new TimeSpan(0, 16, 45, 0, 0), 1 },
                    { 4, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN001000004", "88", new TimeSpan(0, 20, 0, 0, 0), 1 },
                    { 5, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN001000005", "75", new TimeSpan(0, 6, 20, 0, 0), 1 },
                    { 6, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN001000006", "82", new TimeSpan(0, 10, 35, 0, 0), 2 },
                    { 7, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN001000007", "79", new TimeSpan(0, 14, 50, 0, 0), 2 },
                    { 8, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN001000008", "86", new TimeSpan(0, 18, 5, 0, 0), 2 },
                    { 9, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN001000009", "74", new TimeSpan(0, 22, 25, 0, 0), 2 },
                    { 10, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN001000010", "81", new TimeSpan(0, 2, 40, 0, 0), 2 },
                    { 11, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN001000011", "78", new TimeSpan(0, 8, 15, 0, 0), 2 },
                    { 12, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN001000012", "85", new TimeSpan(0, 12, 30, 0, 0), 3 },
                    { 13, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN001000013", "72", new TimeSpan(0, 16, 45, 0, 0), 3 },
                    { 14, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN001000014", "88", new TimeSpan(0, 20, 0, 0, 0), 3 },
                    { 15, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN001000015", "75", new TimeSpan(0, 6, 20, 0, 0), 3 },
                    { 16, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN001000016", "82", new TimeSpan(0, 10, 35, 0, 0), 4 },
                    { 17, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN001000017", "79", new TimeSpan(0, 14, 50, 0, 0), 4 },
                    { 18, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN001000018", "86", new TimeSpan(0, 18, 5, 0, 0), 4 },
                    { 19, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN001000019", "74", new TimeSpan(0, 22, 25, 0, 0), 4 },
                    { 20, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN001000020", "81", new TimeSpan(0, 2, 40, 0, 0), 4 },
                    { 21, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN001000021", "78", new TimeSpan(0, 8, 15, 0, 0), 4 },
                    { 22, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN001000022", "85", new TimeSpan(0, 12, 30, 0, 0), 4 },
                    { 23, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN001000023", "72", new TimeSpan(0, 16, 45, 0, 0), 5 },
                    { 24, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN001000024", "88", new TimeSpan(0, 20, 0, 0, 0), 5 },
                    { 25, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN001000025", "75", new TimeSpan(0, 6, 20, 0, 0), 5 },
                    { 26, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN001000026", "82", new TimeSpan(0, 10, 35, 0, 0), 5 },
                    { 27, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN001000027", "79", new TimeSpan(0, 14, 50, 0, 0), 5 },
                    { 28, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN001000028", "86", new TimeSpan(0, 18, 5, 0, 0), 6 },
                    { 29, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN001000029", "74", new TimeSpan(0, 22, 25, 0, 0), 6 },
                    { 30, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN001000030", "81", new TimeSpan(0, 2, 40, 0, 0), 6 },
                    { 31, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN001000031", "78", new TimeSpan(0, 8, 15, 0, 0), 6 },
                    { 32, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN001000032", "85", new TimeSpan(0, 12, 30, 0, 0), 6 },
                    { 33, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN001000033", "72", new TimeSpan(0, 16, 45, 0, 0), 6 },
                    { 34, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN001000034", "88", new TimeSpan(0, 20, 0, 0, 0), 7 },
                    { 35, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN001000035", "75", new TimeSpan(0, 6, 20, 0, 0), 7 },
                    { 36, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN001000036", "82", new TimeSpan(0, 10, 35, 0, 0), 7 },
                    { 37, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN001000037", "79", new TimeSpan(0, 14, 50, 0, 0), 7 },
                    { 38, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN001000038", "86", new TimeSpan(0, 18, 5, 0, 0), 8 },
                    { 39, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN001000039", "74", new TimeSpan(0, 22, 25, 0, 0), 8 },
                    { 40, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN001000040", "81", new TimeSpan(0, 2, 40, 0, 0), 8 },
                    { 41, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN001000041", "78", new TimeSpan(0, 8, 15, 0, 0), 8 },
                    { 42, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN001000042", "85", new TimeSpan(0, 12, 30, 0, 0), 8 },
                    { 43, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN001000043", "72", new TimeSpan(0, 16, 45, 0, 0), 9 },
                    { 44, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN001000044", "88", new TimeSpan(0, 20, 0, 0, 0), 9 },
                    { 45, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN001000045", "75", new TimeSpan(0, 6, 20, 0, 0), 9 },
                    { 46, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN001000046", "82", new TimeSpan(0, 10, 35, 0, 0), 9 },
                    { 47, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN001000047", "79", new TimeSpan(0, 14, 50, 0, 0), 9 },
                    { 48, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN001000048", "86", new TimeSpan(0, 18, 5, 0, 0), 9 },
                    { 49, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN001000049", "74", new TimeSpan(0, 22, 25, 0, 0), 10 },
                    { 50, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN001000050", "81", new TimeSpan(0, 2, 40, 0, 0), 10 },
                    { 51, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN001000051", "78", new TimeSpan(0, 8, 15, 0, 0), 10 },
                    { 52, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN001000052", "85", new TimeSpan(0, 12, 30, 0, 0), 10 },
                    { 53, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN001000053", "72", new TimeSpan(0, 16, 45, 0, 0), 10 },
                    { 54, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN001000054", "88", new TimeSpan(0, 20, 0, 0, 0), 10 },
                    { 55, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN001000055", "75", new TimeSpan(0, 6, 20, 0, 0), 10 },
                    { 56, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN001000056", "82", new TimeSpan(0, 10, 35, 0, 0), 11 },
                    { 57, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN001000057", "79", new TimeSpan(0, 14, 50, 0, 0), 11 },
                    { 58, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN001000058", "86", new TimeSpan(0, 18, 5, 0, 0), 11 },
                    { 59, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN001000059", "74", new TimeSpan(0, 22, 25, 0, 0), 11 },
                    { 60, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN001000060", "81", new TimeSpan(0, 2, 40, 0, 0), 11 },
                    { 61, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN001000061", "78", new TimeSpan(0, 8, 15, 0, 0), 12 },
                    { 62, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN001000062", "85", new TimeSpan(0, 12, 30, 0, 0), 12 },
                    { 63, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN001000063", "72", new TimeSpan(0, 16, 45, 0, 0), 12 },
                    { 64, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN001000064", "88", new TimeSpan(0, 20, 0, 0, 0), 12 },
                    { 65, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN001000065", "75", new TimeSpan(0, 6, 20, 0, 0), 12 },
                    { 66, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN001000066", "82", new TimeSpan(0, 10, 35, 0, 0), 12 },
                    { 67, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN001000067", "79", new TimeSpan(0, 14, 50, 0, 0), 13 },
                    { 68, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN001000068", "86", new TimeSpan(0, 18, 5, 0, 0), 13 },
                    { 69, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN001000069", "74", new TimeSpan(0, 22, 25, 0, 0), 13 },
                    { 70, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN001000070", "81", new TimeSpan(0, 2, 40, 0, 0), 13 },
                    { 71, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN001000071", "78", new TimeSpan(0, 8, 15, 0, 0), 14 },
                    { 72, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN001000072", "85", new TimeSpan(0, 12, 30, 0, 0), 14 },
                    { 73, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN001000073", "72", new TimeSpan(0, 16, 45, 0, 0), 14 },
                    { 74, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN001000074", "88", new TimeSpan(0, 20, 0, 0, 0), 14 },
                    { 75, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN001000075", "75", new TimeSpan(0, 6, 20, 0, 0), 14 },
                    { 76, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN001000076", "82", new TimeSpan(0, 10, 35, 0, 0), 14 },
                    { 77, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN001000077", "79", new TimeSpan(0, 14, 50, 0, 0), 14 },
                    { 78, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN001000078", "86", new TimeSpan(0, 18, 5, 0, 0), 15 },
                    { 79, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN001000079", "74", new TimeSpan(0, 22, 25, 0, 0), 15 },
                    { 80, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN001000080", "81", new TimeSpan(0, 2, 40, 0, 0), 15 },
                    { 81, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN001000081", "78", new TimeSpan(0, 8, 15, 0, 0), 15 },
                    { 82, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN001000082", "85", new TimeSpan(0, 12, 30, 0, 0), 15 },
                    { 248, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN004000248", "86", new TimeSpan(0, 18, 5, 0, 0), 46 },
                    { 249, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN004000249", "74", new TimeSpan(0, 22, 25, 0, 0), 46 },
                    { 250, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN004000250", "81", new TimeSpan(0, 2, 40, 0, 0), 46 },
                    { 251, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN004000251", "78", new TimeSpan(0, 8, 15, 0, 0), 46 },
                    { 252, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN004000252", "85", new TimeSpan(0, 12, 30, 0, 0), 46 },
                    { 253, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN004000253", "72", new TimeSpan(0, 16, 45, 0, 0), 46 },
                    { 254, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN004000254", "88", new TimeSpan(0, 20, 0, 0, 0), 47 },
                    { 255, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN004000255", "75", new TimeSpan(0, 6, 20, 0, 0), 47 },
                    { 256, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN004000256", "82", new TimeSpan(0, 10, 35, 0, 0), 47 },
                    { 257, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN004000257", "79", new TimeSpan(0, 14, 50, 0, 0), 47 },
                    { 258, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN004000258", "86", new TimeSpan(0, 18, 5, 0, 0), 48 },
                    { 259, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN004000259", "74", new TimeSpan(0, 22, 25, 0, 0), 48 },
                    { 260, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN004000260", "81", new TimeSpan(0, 2, 40, 0, 0), 48 },
                    { 261, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN004000261", "78", new TimeSpan(0, 8, 15, 0, 0), 48 },
                    { 262, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN004000262", "85", new TimeSpan(0, 12, 30, 0, 0), 48 },
                    { 263, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN004000263", "72", new TimeSpan(0, 16, 45, 0, 0), 49 },
                    { 264, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN004000264", "88", new TimeSpan(0, 20, 0, 0, 0), 49 },
                    { 265, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN004000265", "75", new TimeSpan(0, 6, 20, 0, 0), 49 },
                    { 266, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN004000266", "82", new TimeSpan(0, 10, 35, 0, 0), 49 },
                    { 267, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN004000267", "79", new TimeSpan(0, 14, 50, 0, 0), 49 },
                    { 268, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN004000268", "86", new TimeSpan(0, 18, 5, 0, 0), 49 },
                    { 269, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN004000269", "74", new TimeSpan(0, 22, 25, 0, 0), 50 },
                    { 270, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN004000270", "81", new TimeSpan(0, 2, 40, 0, 0), 50 },
                    { 271, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN004000271", "78", new TimeSpan(0, 8, 15, 0, 0), 50 },
                    { 272, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN004000272", "85", new TimeSpan(0, 12, 30, 0, 0), 50 },
                    { 273, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN004000273", "72", new TimeSpan(0, 16, 45, 0, 0), 50 },
                    { 274, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN004000274", "88", new TimeSpan(0, 20, 0, 0, 0), 50 },
                    { 275, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN004000275", "75", new TimeSpan(0, 6, 20, 0, 0), 50 },
                    { 276, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN004000276", "82", new TimeSpan(0, 10, 35, 0, 0), 51 },
                    { 277, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN004000277", "79", new TimeSpan(0, 14, 50, 0, 0), 51 },
                    { 278, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN004000278", "86", new TimeSpan(0, 18, 5, 0, 0), 51 },
                    { 279, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN004000279", "74", new TimeSpan(0, 22, 25, 0, 0), 51 },
                    { 280, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN004000280", "81", new TimeSpan(0, 2, 40, 0, 0), 51 },
                    { 281, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN004000281", "78", new TimeSpan(0, 8, 15, 0, 0), 52 },
                    { 282, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN004000282", "85", new TimeSpan(0, 12, 30, 0, 0), 52 },
                    { 283, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN004000283", "72", new TimeSpan(0, 16, 45, 0, 0), 52 },
                    { 284, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN004000284", "88", new TimeSpan(0, 20, 0, 0, 0), 52 },
                    { 285, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN004000285", "75", new TimeSpan(0, 6, 20, 0, 0), 52 },
                    { 286, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN004000286", "82", new TimeSpan(0, 10, 35, 0, 0), 52 },
                    { 287, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN004000287", "79", new TimeSpan(0, 14, 50, 0, 0), 53 },
                    { 288, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN004000288", "86", new TimeSpan(0, 18, 5, 0, 0), 53 },
                    { 289, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN004000289", "74", new TimeSpan(0, 22, 25, 0, 0), 53 },
                    { 290, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN004000290", "81", new TimeSpan(0, 2, 40, 0, 0), 53 },
                    { 291, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN004000291", "78", new TimeSpan(0, 8, 15, 0, 0), 54 },
                    { 292, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN004000292", "85", new TimeSpan(0, 12, 30, 0, 0), 54 },
                    { 293, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN004000293", "72", new TimeSpan(0, 16, 45, 0, 0), 54 },
                    { 294, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN004000294", "88", new TimeSpan(0, 20, 0, 0, 0), 54 },
                    { 295, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN004000295", "75", new TimeSpan(0, 6, 20, 0, 0), 54 },
                    { 296, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN004000296", "82", new TimeSpan(0, 10, 35, 0, 0), 54 },
                    { 297, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN004000297", "79", new TimeSpan(0, 14, 50, 0, 0), 54 },
                    { 298, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN004000298", "86", new TimeSpan(0, 18, 5, 0, 0), 55 },
                    { 299, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN004000299", "74", new TimeSpan(0, 22, 25, 0, 0), 55 },
                    { 300, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN004000300", "81", new TimeSpan(0, 2, 40, 0, 0), 55 },
                    { 301, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN004000301", "78", new TimeSpan(0, 8, 15, 0, 0), 55 },
                    { 302, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN004000302", "85", new TimeSpan(0, 12, 30, 0, 0), 55 },
                    { 303, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN004000303", "72", new TimeSpan(0, 16, 45, 0, 0), 56 },
                    { 304, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN004000304", "88", new TimeSpan(0, 20, 0, 0, 0), 56 },
                    { 305, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN004000305", "75", new TimeSpan(0, 6, 20, 0, 0), 56 },
                    { 306, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN004000306", "82", new TimeSpan(0, 10, 35, 0, 0), 56 },
                    { 307, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN004000307", "79", new TimeSpan(0, 14, 50, 0, 0), 56 },
                    { 308, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN004000308", "86", new TimeSpan(0, 18, 5, 0, 0), 56 },
                    { 309, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN004000309", "74", new TimeSpan(0, 22, 25, 0, 0), 57 },
                    { 310, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN004000310", "81", new TimeSpan(0, 2, 40, 0, 0), 57 },
                    { 311, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN004000311", "78", new TimeSpan(0, 8, 15, 0, 0), 57 },
                    { 312, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN004000312", "85", new TimeSpan(0, 12, 30, 0, 0), 57 },
                    { 313, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN004000313", "72", new TimeSpan(0, 16, 45, 0, 0), 58 },
                    { 314, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN004000314", "88", new TimeSpan(0, 20, 0, 0, 0), 58 },
                    { 315, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN004000315", "75", new TimeSpan(0, 6, 20, 0, 0), 58 },
                    { 316, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN004000316", "82", new TimeSpan(0, 10, 35, 0, 0), 58 },
                    { 317, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN004000317", "79", new TimeSpan(0, 14, 50, 0, 0), 58 },
                    { 318, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN004000318", "86", new TimeSpan(0, 18, 5, 0, 0), 59 },
                    { 319, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN004000319", "74", new TimeSpan(0, 22, 25, 0, 0), 59 },
                    { 320, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN004000320", "81", new TimeSpan(0, 2, 40, 0, 0), 59 },
                    { 321, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN004000321", "78", new TimeSpan(0, 8, 15, 0, 0), 59 },
                    { 322, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN004000322", "85", new TimeSpan(0, 12, 30, 0, 0), 59 },
                    { 323, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN004000323", "72", new TimeSpan(0, 16, 45, 0, 0), 59 },
                    { 324, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN004000324", "88", new TimeSpan(0, 20, 0, 0, 0), 60 },
                    { 325, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN004000325", "75", new TimeSpan(0, 6, 20, 0, 0), 60 },
                    { 326, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN004000326", "82", new TimeSpan(0, 10, 35, 0, 0), 60 },
                    { 327, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN004000327", "79", new TimeSpan(0, 14, 50, 0, 0), 60 },
                    { 328, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN004000328", "86", new TimeSpan(0, 18, 5, 0, 0), 60 },
                    { 329, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN004000329", "74", new TimeSpan(0, 22, 25, 0, 0), 60 },
                    { 330, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN004000330", "81", new TimeSpan(0, 2, 40, 0, 0), 60 },
                    { 661, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN009000661", "78", new TimeSpan(0, 8, 15, 0, 0), 121 },
                    { 662, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN009000662", "85", new TimeSpan(0, 12, 30, 0, 0), 121 },
                    { 663, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN009000663", "72", new TimeSpan(0, 16, 45, 0, 0), 121 },
                    { 664, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN009000664", "88", new TimeSpan(0, 20, 0, 0, 0), 121 },
                    { 665, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN009000665", "75", new TimeSpan(0, 6, 20, 0, 0), 121 },
                    { 666, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN009000666", "82", new TimeSpan(0, 10, 35, 0, 0), 122 },
                    { 667, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN009000667", "79", new TimeSpan(0, 14, 50, 0, 0), 122 },
                    { 668, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN009000668", "86", new TimeSpan(0, 18, 5, 0, 0), 122 },
                    { 669, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN009000669", "74", new TimeSpan(0, 22, 25, 0, 0), 122 },
                    { 670, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN009000670", "81", new TimeSpan(0, 2, 40, 0, 0), 122 },
                    { 671, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN009000671", "78", new TimeSpan(0, 8, 15, 0, 0), 122 },
                    { 672, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN009000672", "85", new TimeSpan(0, 12, 30, 0, 0), 123 },
                    { 673, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN009000673", "72", new TimeSpan(0, 16, 45, 0, 0), 123 },
                    { 674, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN009000674", "88", new TimeSpan(0, 20, 0, 0, 0), 123 },
                    { 675, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN009000675", "75", new TimeSpan(0, 6, 20, 0, 0), 123 },
                    { 676, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN009000676", "82", new TimeSpan(0, 10, 35, 0, 0), 124 },
                    { 677, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN009000677", "79", new TimeSpan(0, 14, 50, 0, 0), 124 },
                    { 678, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN009000678", "86", new TimeSpan(0, 18, 5, 0, 0), 124 },
                    { 679, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN009000679", "74", new TimeSpan(0, 22, 25, 0, 0), 124 },
                    { 680, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN009000680", "81", new TimeSpan(0, 2, 40, 0, 0), 124 },
                    { 681, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN009000681", "78", new TimeSpan(0, 8, 15, 0, 0), 124 },
                    { 682, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN009000682", "85", new TimeSpan(0, 12, 30, 0, 0), 124 },
                    { 683, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN009000683", "72", new TimeSpan(0, 16, 45, 0, 0), 125 },
                    { 684, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN009000684", "88", new TimeSpan(0, 20, 0, 0, 0), 125 },
                    { 685, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN009000685", "75", new TimeSpan(0, 6, 20, 0, 0), 125 },
                    { 686, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN009000686", "82", new TimeSpan(0, 10, 35, 0, 0), 125 },
                    { 687, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN009000687", "79", new TimeSpan(0, 14, 50, 0, 0), 125 },
                    { 688, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN009000688", "86", new TimeSpan(0, 18, 5, 0, 0), 126 },
                    { 689, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN009000689", "74", new TimeSpan(0, 22, 25, 0, 0), 126 },
                    { 690, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN009000690", "81", new TimeSpan(0, 2, 40, 0, 0), 126 },
                    { 691, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN009000691", "78", new TimeSpan(0, 8, 15, 0, 0), 126 },
                    { 692, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN009000692", "85", new TimeSpan(0, 12, 30, 0, 0), 126 },
                    { 693, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN009000693", "72", new TimeSpan(0, 16, 45, 0, 0), 126 },
                    { 694, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN009000694", "88", new TimeSpan(0, 20, 0, 0, 0), 127 },
                    { 695, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN009000695", "75", new TimeSpan(0, 6, 20, 0, 0), 127 },
                    { 696, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN009000696", "82", new TimeSpan(0, 10, 35, 0, 0), 127 },
                    { 697, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN009000697", "79", new TimeSpan(0, 14, 50, 0, 0), 127 },
                    { 698, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN009000698", "86", new TimeSpan(0, 18, 5, 0, 0), 128 },
                    { 699, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN009000699", "74", new TimeSpan(0, 22, 25, 0, 0), 128 },
                    { 700, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN009000700", "81", new TimeSpan(0, 2, 40, 0, 0), 128 },
                    { 701, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN009000701", "78", new TimeSpan(0, 8, 15, 0, 0), 128 },
                    { 702, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN009000702", "85", new TimeSpan(0, 12, 30, 0, 0), 128 },
                    { 703, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN009000703", "72", new TimeSpan(0, 16, 45, 0, 0), 129 },
                    { 704, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN009000704", "88", new TimeSpan(0, 20, 0, 0, 0), 129 },
                    { 705, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN009000705", "75", new TimeSpan(0, 6, 20, 0, 0), 129 },
                    { 706, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN009000706", "82", new TimeSpan(0, 10, 35, 0, 0), 129 },
                    { 707, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN009000707", "79", new TimeSpan(0, 14, 50, 0, 0), 129 },
                    { 708, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN009000708", "86", new TimeSpan(0, 18, 5, 0, 0), 129 },
                    { 709, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN009000709", "74", new TimeSpan(0, 22, 25, 0, 0), 130 },
                    { 710, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN009000710", "81", new TimeSpan(0, 2, 40, 0, 0), 130 },
                    { 711, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN009000711", "78", new TimeSpan(0, 8, 15, 0, 0), 130 },
                    { 712, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN009000712", "85", new TimeSpan(0, 12, 30, 0, 0), 130 },
                    { 713, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN009000713", "72", new TimeSpan(0, 16, 45, 0, 0), 130 },
                    { 714, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN009000714", "88", new TimeSpan(0, 20, 0, 0, 0), 130 },
                    { 715, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN009000715", "75", new TimeSpan(0, 6, 20, 0, 0), 130 },
                    { 716, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN009000716", "82", new TimeSpan(0, 10, 35, 0, 0), 131 },
                    { 717, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN009000717", "79", new TimeSpan(0, 14, 50, 0, 0), 131 },
                    { 718, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN009000718", "86", new TimeSpan(0, 18, 5, 0, 0), 131 },
                    { 719, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN009000719", "74", new TimeSpan(0, 22, 25, 0, 0), 131 },
                    { 720, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN009000720", "81", new TimeSpan(0, 2, 40, 0, 0), 131 },
                    { 721, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN009000721", "78", new TimeSpan(0, 8, 15, 0, 0), 132 },
                    { 722, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN009000722", "85", new TimeSpan(0, 12, 30, 0, 0), 132 },
                    { 723, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN009000723", "72", new TimeSpan(0, 16, 45, 0, 0), 132 },
                    { 724, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN009000724", "88", new TimeSpan(0, 20, 0, 0, 0), 132 },
                    { 725, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN009000725", "75", new TimeSpan(0, 6, 20, 0, 0), 132 },
                    { 726, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN009000726", "82", new TimeSpan(0, 10, 35, 0, 0), 132 },
                    { 727, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN009000727", "79", new TimeSpan(0, 14, 50, 0, 0), 133 },
                    { 728, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN009000728", "86", new TimeSpan(0, 18, 5, 0, 0), 133 },
                    { 729, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN009000729", "74", new TimeSpan(0, 22, 25, 0, 0), 133 },
                    { 730, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN009000730", "81", new TimeSpan(0, 2, 40, 0, 0), 133 },
                    { 731, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN009000731", "78", new TimeSpan(0, 8, 15, 0, 0), 134 },
                    { 732, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN009000732", "85", new TimeSpan(0, 12, 30, 0, 0), 134 },
                    { 733, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN009000733", "72", new TimeSpan(0, 16, 45, 0, 0), 134 },
                    { 734, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN009000734", "88", new TimeSpan(0, 20, 0, 0, 0), 134 },
                    { 735, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN009000735", "75", new TimeSpan(0, 6, 20, 0, 0), 134 },
                    { 736, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN009000736", "82", new TimeSpan(0, 10, 35, 0, 0), 134 },
                    { 737, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN009000737", "79", new TimeSpan(0, 14, 50, 0, 0), 134 },
                    { 738, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN009000738", "86", new TimeSpan(0, 18, 5, 0, 0), 135 },
                    { 739, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN009000739", "74", new TimeSpan(0, 22, 25, 0, 0), 135 },
                    { 740, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN009000740", "81", new TimeSpan(0, 2, 40, 0, 0), 135 },
                    { 741, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN009000741", "78", new TimeSpan(0, 8, 15, 0, 0), 135 },
                    { 742, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN009000742", "85", new TimeSpan(0, 12, 30, 0, 0), 135 }
                });

            migrationBuilder.InsertData(
                table: "TrapCounterSchedules",
                columns: new[] { "Id", "ScdTime", "Status", "TrapId" },
                values: new object[,]
                {
                    { 1, 0, true, 2 },
                    { 2, 6, true, 2 },
                    { 3, 12, true, 2 },
                    { 4, 18, true, 2 },
                    { 19, 0, true, 6 },
                    { 20, 6, true, 6 },
                    { 21, 12, true, 6 },
                    { 22, 18, true, 6 },
                    { 28, 0, true, 8 },
                    { 29, 6, true, 8 },
                    { 30, 12, true, 8 },
                    { 31, 18, true, 8 },
                    { 37, 0, true, 10 },
                    { 38, 6, true, 10 },
                    { 39, 12, true, 10 },
                    { 40, 18, true, 10 }
                });

            migrationBuilder.InsertData(
                table: "TrapFanSchedules",
                columns: new[] { "Id", "ScdTime", "Status", "TrapId" },
                values: new object[,]
                {
                    { 5, 2, true, 2 },
                    { 6, 10, true, 2 },
                    { 7, 18, true, 2 },
                    { 23, 2, true, 6 },
                    { 24, 10, true, 6 },
                    { 25, 18, true, 6 },
                    { 32, 2, true, 8 },
                    { 33, 10, true, 8 },
                    { 34, 18, true, 8 },
                    { 41, 2, true, 10 },
                    { 42, 10, true, 10 },
                    { 43, 18, true, 10 }
                });

            migrationBuilder.InsertData(
                table: "TrapReads",
                columns: new[] { "Id", "Date", "ServerCreationDate", "TrapId" },
                values: new object[,]
                {
                    { 16, new DateOnly(2024, 1, 31), new DateOnly(2024, 2, 1), 2 },
                    { 17, new DateOnly(2024, 2, 2), new DateOnly(2024, 2, 3), 2 },
                    { 18, new DateOnly(2024, 2, 4), new DateOnly(2024, 2, 5), 2 },
                    { 19, new DateOnly(2024, 2, 6), new DateOnly(2024, 2, 7), 2 },
                    { 20, new DateOnly(2024, 2, 8), new DateOnly(2024, 2, 9), 2 },
                    { 21, new DateOnly(2024, 2, 10), new DateOnly(2024, 2, 11), 2 },
                    { 22, new DateOnly(2024, 2, 12), new DateOnly(2024, 2, 13), 2 },
                    { 23, new DateOnly(2024, 2, 14), new DateOnly(2024, 2, 15), 2 },
                    { 24, new DateOnly(2024, 2, 16), new DateOnly(2024, 2, 17), 2 },
                    { 25, new DateOnly(2024, 2, 18), new DateOnly(2024, 2, 19), 2 },
                    { 26, new DateOnly(2024, 2, 20), new DateOnly(2024, 2, 21), 2 },
                    { 27, new DateOnly(2024, 2, 22), new DateOnly(2024, 2, 23), 2 },
                    { 28, new DateOnly(2024, 2, 24), new DateOnly(2024, 2, 25), 2 },
                    { 29, new DateOnly(2024, 2, 26), new DateOnly(2024, 2, 27), 2 },
                    { 30, new DateOnly(2024, 2, 28), new DateOnly(2024, 2, 29), 2 },
                    { 31, new DateOnly(2024, 3, 1), new DateOnly(2024, 3, 2), 3 },
                    { 32, new DateOnly(2024, 3, 3), new DateOnly(2024, 3, 4), 3 },
                    { 33, new DateOnly(2024, 3, 5), new DateOnly(2024, 3, 6), 3 },
                    { 34, new DateOnly(2024, 3, 7), new DateOnly(2024, 3, 8), 3 },
                    { 35, new DateOnly(2024, 3, 9), new DateOnly(2024, 3, 10), 3 },
                    { 36, new DateOnly(2024, 3, 11), new DateOnly(2024, 3, 12), 3 },
                    { 37, new DateOnly(2024, 3, 13), new DateOnly(2024, 3, 14), 3 },
                    { 38, new DateOnly(2024, 3, 15), new DateOnly(2024, 3, 16), 3 },
                    { 39, new DateOnly(2024, 3, 17), new DateOnly(2024, 3, 18), 3 },
                    { 40, new DateOnly(2024, 3, 19), new DateOnly(2024, 3, 20), 3 },
                    { 41, new DateOnly(2024, 3, 21), new DateOnly(2024, 3, 22), 3 },
                    { 42, new DateOnly(2024, 3, 23), new DateOnly(2024, 3, 24), 3 },
                    { 43, new DateOnly(2024, 3, 25), new DateOnly(2024, 3, 26), 3 },
                    { 44, new DateOnly(2024, 3, 27), new DateOnly(2024, 3, 28), 3 },
                    { 45, new DateOnly(2024, 3, 29), new DateOnly(2024, 3, 30), 3 },
                    { 61, new DateOnly(2024, 4, 30), new DateOnly(2024, 5, 1), 5 },
                    { 62, new DateOnly(2024, 5, 2), new DateOnly(2024, 5, 3), 5 },
                    { 63, new DateOnly(2024, 5, 4), new DateOnly(2024, 5, 5), 5 },
                    { 64, new DateOnly(2024, 5, 6), new DateOnly(2024, 5, 7), 5 },
                    { 65, new DateOnly(2024, 5, 8), new DateOnly(2024, 5, 9), 5 },
                    { 66, new DateOnly(2024, 5, 10), new DateOnly(2024, 5, 11), 5 },
                    { 67, new DateOnly(2024, 5, 12), new DateOnly(2024, 5, 13), 5 },
                    { 68, new DateOnly(2024, 5, 14), new DateOnly(2024, 5, 15), 5 },
                    { 69, new DateOnly(2024, 5, 16), new DateOnly(2024, 5, 17), 5 },
                    { 70, new DateOnly(2024, 5, 18), new DateOnly(2024, 5, 19), 5 },
                    { 71, new DateOnly(2024, 5, 20), new DateOnly(2024, 5, 21), 5 },
                    { 72, new DateOnly(2024, 5, 22), new DateOnly(2024, 5, 23), 5 },
                    { 73, new DateOnly(2024, 5, 24), new DateOnly(2024, 5, 25), 5 },
                    { 74, new DateOnly(2024, 5, 26), new DateOnly(2024, 5, 27), 5 },
                    { 75, new DateOnly(2024, 5, 28), new DateOnly(2024, 5, 29), 5 },
                    { 76, new DateOnly(2024, 5, 30), new DateOnly(2024, 5, 31), 6 },
                    { 77, new DateOnly(2024, 6, 1), new DateOnly(2024, 6, 2), 6 },
                    { 78, new DateOnly(2024, 6, 3), new DateOnly(2024, 6, 4), 6 },
                    { 79, new DateOnly(2024, 6, 5), new DateOnly(2024, 6, 6), 6 },
                    { 80, new DateOnly(2024, 6, 7), new DateOnly(2024, 6, 8), 6 },
                    { 81, new DateOnly(2024, 6, 9), new DateOnly(2024, 6, 10), 6 },
                    { 82, new DateOnly(2024, 6, 11), new DateOnly(2024, 6, 12), 6 },
                    { 83, new DateOnly(2024, 6, 13), new DateOnly(2024, 6, 14), 6 },
                    { 84, new DateOnly(2024, 6, 15), new DateOnly(2024, 6, 16), 6 },
                    { 85, new DateOnly(2024, 6, 17), new DateOnly(2024, 6, 18), 6 },
                    { 86, new DateOnly(2024, 6, 19), new DateOnly(2024, 6, 20), 6 },
                    { 87, new DateOnly(2024, 6, 21), new DateOnly(2024, 6, 22), 6 },
                    { 88, new DateOnly(2024, 6, 23), new DateOnly(2024, 6, 24), 6 },
                    { 89, new DateOnly(2024, 6, 25), new DateOnly(2024, 6, 26), 6 },
                    { 90, new DateOnly(2024, 6, 27), new DateOnly(2024, 6, 28), 6 },
                    { 91, new DateOnly(2024, 6, 29), new DateOnly(2024, 6, 30), 7 },
                    { 92, new DateOnly(2024, 7, 1), new DateOnly(2024, 7, 2), 7 },
                    { 93, new DateOnly(2024, 7, 3), new DateOnly(2024, 7, 4), 7 },
                    { 94, new DateOnly(2024, 7, 5), new DateOnly(2024, 7, 6), 7 },
                    { 95, new DateOnly(2024, 7, 7), new DateOnly(2024, 7, 8), 7 },
                    { 96, new DateOnly(2024, 7, 9), new DateOnly(2024, 7, 10), 7 },
                    { 97, new DateOnly(2024, 7, 11), new DateOnly(2024, 7, 12), 7 },
                    { 98, new DateOnly(2024, 7, 13), new DateOnly(2024, 7, 14), 7 },
                    { 99, new DateOnly(2024, 7, 15), new DateOnly(2024, 7, 16), 7 },
                    { 100, new DateOnly(2024, 7, 17), new DateOnly(2024, 7, 18), 7 },
                    { 101, new DateOnly(2024, 7, 19), new DateOnly(2024, 7, 20), 7 },
                    { 102, new DateOnly(2024, 7, 21), new DateOnly(2024, 7, 22), 7 },
                    { 103, new DateOnly(2024, 7, 23), new DateOnly(2024, 7, 24), 7 },
                    { 104, new DateOnly(2024, 7, 25), new DateOnly(2024, 7, 26), 7 },
                    { 105, new DateOnly(2024, 7, 27), new DateOnly(2024, 7, 28), 7 },
                    { 106, new DateOnly(2024, 7, 29), new DateOnly(2024, 7, 30), 8 },
                    { 107, new DateOnly(2024, 7, 31), new DateOnly(2024, 8, 1), 8 },
                    { 108, new DateOnly(2024, 8, 2), new DateOnly(2024, 8, 3), 8 },
                    { 109, new DateOnly(2024, 8, 4), new DateOnly(2024, 8, 5), 8 },
                    { 110, new DateOnly(2024, 8, 6), new DateOnly(2024, 8, 7), 8 },
                    { 111, new DateOnly(2024, 8, 8), new DateOnly(2024, 8, 9), 8 },
                    { 112, new DateOnly(2024, 8, 10), new DateOnly(2024, 8, 11), 8 },
                    { 113, new DateOnly(2024, 8, 12), new DateOnly(2024, 8, 13), 8 },
                    { 114, new DateOnly(2024, 8, 14), new DateOnly(2024, 8, 15), 8 },
                    { 115, new DateOnly(2024, 8, 16), new DateOnly(2024, 8, 17), 8 },
                    { 116, new DateOnly(2024, 8, 18), new DateOnly(2024, 8, 19), 8 },
                    { 117, new DateOnly(2024, 8, 20), new DateOnly(2024, 8, 21), 8 },
                    { 118, new DateOnly(2024, 8, 22), new DateOnly(2024, 8, 23), 8 },
                    { 119, new DateOnly(2024, 8, 24), new DateOnly(2024, 8, 25), 8 },
                    { 120, new DateOnly(2024, 8, 26), new DateOnly(2024, 8, 27), 8 },
                    { 136, new DateOnly(2024, 9, 27), new DateOnly(2024, 9, 28), 10 },
                    { 137, new DateOnly(2024, 9, 29), new DateOnly(2024, 9, 30), 10 },
                    { 138, new DateOnly(2024, 10, 1), new DateOnly(2024, 10, 2), 10 },
                    { 139, new DateOnly(2024, 10, 3), new DateOnly(2024, 10, 4), 10 },
                    { 140, new DateOnly(2024, 10, 5), new DateOnly(2024, 10, 6), 10 },
                    { 141, new DateOnly(2024, 10, 7), new DateOnly(2024, 10, 8), 10 },
                    { 142, new DateOnly(2024, 10, 9), new DateOnly(2024, 10, 10), 10 },
                    { 143, new DateOnly(2024, 10, 11), new DateOnly(2024, 10, 12), 10 },
                    { 144, new DateOnly(2024, 10, 13), new DateOnly(2024, 10, 14), 10 },
                    { 145, new DateOnly(2024, 10, 15), new DateOnly(2024, 10, 16), 10 },
                    { 146, new DateOnly(2024, 10, 17), new DateOnly(2024, 10, 18), 10 },
                    { 147, new DateOnly(2024, 10, 19), new DateOnly(2024, 10, 20), 10 },
                    { 148, new DateOnly(2024, 10, 21), new DateOnly(2024, 10, 22), 10 },
                    { 149, new DateOnly(2024, 10, 23), new DateOnly(2024, 10, 24), 10 },
                    { 150, new DateOnly(2024, 10, 25), new DateOnly(2024, 10, 26), 10 }
                });

            migrationBuilder.InsertData(
                table: "TrapValveQutSchedules",
                columns: new[] { "Id", "ScdTime", "Status", "TrapId" },
                values: new object[,]
                {
                    { 8, 4, true, 2 },
                    { 9, 16, true, 2 },
                    { 26, 4, true, 6 },
                    { 27, 16, true, 6 },
                    { 35, 4, true, 8 },
                    { 36, 16, true, 8 },
                    { 44, 4, true, 10 },
                    { 45, 16, true, 10 }
                });

            migrationBuilder.InsertData(
                table: "UserTraps",
                columns: new[] { "Id", "TrapId", "UserId" },
                values: new object[,]
                {
                    { 2, 2, new Guid("22222222-2222-2222-2222-222222222222") },
                    { 3, 3, new Guid("33333333-3333-3333-3333-333333333333") },
                    { 4, 4, new Guid("44444444-4444-4444-4444-444444444444") },
                    { 5, 5, new Guid("55555555-5555-5555-5555-555555555555") },
                    { 6, 6, new Guid("11111111-1111-1111-1111-111111111111") },
                    { 7, 7, new Guid("22222222-2222-2222-2222-222222222222") },
                    { 8, 8, new Guid("33333333-3333-3333-3333-333333333333") },
                    { 9, 9, new Guid("44444444-4444-4444-4444-444444444444") },
                    { 10, 10, new Guid("55555555-5555-5555-5555-555555555555") }
                });

            migrationBuilder.InsertData(
                table: "ReadDetails",
                columns: new[] { "Id", "BigBattery", "Co2", "Co2Val", "Counter", "Fan", "IsClean", "IsDone", "ReadingFly", "ReadingHumidty", "ReadingLarg", "ReadingLat", "ReadingLng", "ReadingMosuqitoes", "ReadingSmall", "ReadingTempIn", "ReadingTempOut", "ReadingWindSpeed", "SerialNumber", "SmallBattery", "Time", "TrapReadId" },
                values: new object[,]
                {
                    { 83, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN002000083", "72", new TimeSpan(0, 16, 45, 0, 0), 16 },
                    { 84, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN002000084", "88", new TimeSpan(0, 20, 0, 0, 0), 16 },
                    { 85, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN002000085", "75", new TimeSpan(0, 6, 20, 0, 0), 16 },
                    { 86, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN002000086", "82", new TimeSpan(0, 10, 35, 0, 0), 16 },
                    { 87, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN002000087", "79", new TimeSpan(0, 14, 50, 0, 0), 16 },
                    { 88, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN002000088", "86", new TimeSpan(0, 18, 5, 0, 0), 16 },
                    { 89, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN002000089", "74", new TimeSpan(0, 22, 25, 0, 0), 17 },
                    { 90, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN002000090", "81", new TimeSpan(0, 2, 40, 0, 0), 17 },
                    { 91, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN002000091", "78", new TimeSpan(0, 8, 15, 0, 0), 17 },
                    { 92, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN002000092", "85", new TimeSpan(0, 12, 30, 0, 0), 17 },
                    { 93, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN002000093", "72", new TimeSpan(0, 16, 45, 0, 0), 18 },
                    { 94, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN002000094", "88", new TimeSpan(0, 20, 0, 0, 0), 18 },
                    { 95, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN002000095", "75", new TimeSpan(0, 6, 20, 0, 0), 18 },
                    { 96, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN002000096", "82", new TimeSpan(0, 10, 35, 0, 0), 18 },
                    { 97, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN002000097", "79", new TimeSpan(0, 14, 50, 0, 0), 18 },
                    { 98, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN002000098", "86", new TimeSpan(0, 18, 5, 0, 0), 19 },
                    { 99, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN002000099", "74", new TimeSpan(0, 22, 25, 0, 0), 19 },
                    { 100, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN002000100", "81", new TimeSpan(0, 2, 40, 0, 0), 19 },
                    { 101, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN002000101", "78", new TimeSpan(0, 8, 15, 0, 0), 19 },
                    { 102, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN002000102", "85", new TimeSpan(0, 12, 30, 0, 0), 19 },
                    { 103, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN002000103", "72", new TimeSpan(0, 16, 45, 0, 0), 19 },
                    { 104, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN002000104", "88", new TimeSpan(0, 20, 0, 0, 0), 20 },
                    { 105, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN002000105", "75", new TimeSpan(0, 6, 20, 0, 0), 20 },
                    { 106, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN002000106", "82", new TimeSpan(0, 10, 35, 0, 0), 20 },
                    { 107, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN002000107", "79", new TimeSpan(0, 14, 50, 0, 0), 20 },
                    { 108, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN002000108", "86", new TimeSpan(0, 18, 5, 0, 0), 20 },
                    { 109, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN002000109", "74", new TimeSpan(0, 22, 25, 0, 0), 20 },
                    { 110, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN002000110", "81", new TimeSpan(0, 2, 40, 0, 0), 20 },
                    { 111, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN002000111", "78", new TimeSpan(0, 8, 15, 0, 0), 21 },
                    { 112, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN002000112", "85", new TimeSpan(0, 12, 30, 0, 0), 21 },
                    { 113, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN002000113", "72", new TimeSpan(0, 16, 45, 0, 0), 21 },
                    { 114, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN002000114", "88", new TimeSpan(0, 20, 0, 0, 0), 21 },
                    { 115, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN002000115", "75", new TimeSpan(0, 6, 20, 0, 0), 21 },
                    { 116, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN002000116", "82", new TimeSpan(0, 10, 35, 0, 0), 22 },
                    { 117, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN002000117", "79", new TimeSpan(0, 14, 50, 0, 0), 22 },
                    { 118, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN002000118", "86", new TimeSpan(0, 18, 5, 0, 0), 22 },
                    { 119, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN002000119", "74", new TimeSpan(0, 22, 25, 0, 0), 22 },
                    { 120, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN002000120", "81", new TimeSpan(0, 2, 40, 0, 0), 22 },
                    { 121, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN002000121", "78", new TimeSpan(0, 8, 15, 0, 0), 22 },
                    { 122, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN002000122", "85", new TimeSpan(0, 12, 30, 0, 0), 23 },
                    { 123, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN002000123", "72", new TimeSpan(0, 16, 45, 0, 0), 23 },
                    { 124, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN002000124", "88", new TimeSpan(0, 20, 0, 0, 0), 23 },
                    { 125, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN002000125", "75", new TimeSpan(0, 6, 20, 0, 0), 23 },
                    { 126, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN002000126", "82", new TimeSpan(0, 10, 35, 0, 0), 24 },
                    { 127, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN002000127", "79", new TimeSpan(0, 14, 50, 0, 0), 24 },
                    { 128, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN002000128", "86", new TimeSpan(0, 18, 5, 0, 0), 24 },
                    { 129, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN002000129", "74", new TimeSpan(0, 22, 25, 0, 0), 24 },
                    { 130, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN002000130", "81", new TimeSpan(0, 2, 40, 0, 0), 24 },
                    { 131, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN002000131", "78", new TimeSpan(0, 8, 15, 0, 0), 24 },
                    { 132, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN002000132", "85", new TimeSpan(0, 12, 30, 0, 0), 24 },
                    { 133, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN002000133", "72", new TimeSpan(0, 16, 45, 0, 0), 25 },
                    { 134, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN002000134", "88", new TimeSpan(0, 20, 0, 0, 0), 25 },
                    { 135, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN002000135", "75", new TimeSpan(0, 6, 20, 0, 0), 25 },
                    { 136, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN002000136", "82", new TimeSpan(0, 10, 35, 0, 0), 25 },
                    { 137, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN002000137", "79", new TimeSpan(0, 14, 50, 0, 0), 25 },
                    { 138, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN002000138", "86", new TimeSpan(0, 18, 5, 0, 0), 26 },
                    { 139, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN002000139", "74", new TimeSpan(0, 22, 25, 0, 0), 26 },
                    { 140, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN002000140", "81", new TimeSpan(0, 2, 40, 0, 0), 26 },
                    { 141, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN002000141", "78", new TimeSpan(0, 8, 15, 0, 0), 26 },
                    { 142, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN002000142", "85", new TimeSpan(0, 12, 30, 0, 0), 26 },
                    { 143, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN002000143", "72", new TimeSpan(0, 16, 45, 0, 0), 26 },
                    { 144, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN002000144", "88", new TimeSpan(0, 20, 0, 0, 0), 27 },
                    { 145, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN002000145", "75", new TimeSpan(0, 6, 20, 0, 0), 27 },
                    { 146, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN002000146", "82", new TimeSpan(0, 10, 35, 0, 0), 27 },
                    { 147, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN002000147", "79", new TimeSpan(0, 14, 50, 0, 0), 27 },
                    { 148, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN002000148", "86", new TimeSpan(0, 18, 5, 0, 0), 28 },
                    { 149, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN002000149", "74", new TimeSpan(0, 22, 25, 0, 0), 28 },
                    { 150, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN002000150", "81", new TimeSpan(0, 2, 40, 0, 0), 28 },
                    { 151, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN002000151", "78", new TimeSpan(0, 8, 15, 0, 0), 28 },
                    { 152, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN002000152", "85", new TimeSpan(0, 12, 30, 0, 0), 28 },
                    { 153, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN002000153", "72", new TimeSpan(0, 16, 45, 0, 0), 29 },
                    { 154, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN002000154", "88", new TimeSpan(0, 20, 0, 0, 0), 29 },
                    { 155, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN002000155", "75", new TimeSpan(0, 6, 20, 0, 0), 29 },
                    { 156, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN002000156", "82", new TimeSpan(0, 10, 35, 0, 0), 29 },
                    { 157, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN002000157", "79", new TimeSpan(0, 14, 50, 0, 0), 29 },
                    { 158, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN002000158", "86", new TimeSpan(0, 18, 5, 0, 0), 29 },
                    { 159, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN002000159", "74", new TimeSpan(0, 22, 25, 0, 0), 30 },
                    { 160, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN002000160", "81", new TimeSpan(0, 2, 40, 0, 0), 30 },
                    { 161, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN002000161", "78", new TimeSpan(0, 8, 15, 0, 0), 30 },
                    { 162, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN002000162", "85", new TimeSpan(0, 12, 30, 0, 0), 30 },
                    { 163, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN002000163", "72", new TimeSpan(0, 16, 45, 0, 0), 30 },
                    { 164, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN002000164", "88", new TimeSpan(0, 20, 0, 0, 0), 30 },
                    { 165, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN002000165", "75", new TimeSpan(0, 6, 20, 0, 0), 30 },
                    { 166, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN003000166", "82", new TimeSpan(0, 10, 35, 0, 0), 31 },
                    { 167, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN003000167", "79", new TimeSpan(0, 14, 50, 0, 0), 31 },
                    { 168, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN003000168", "86", new TimeSpan(0, 18, 5, 0, 0), 31 },
                    { 169, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN003000169", "74", new TimeSpan(0, 22, 25, 0, 0), 31 },
                    { 170, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN003000170", "81", new TimeSpan(0, 2, 40, 0, 0), 31 },
                    { 171, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN003000171", "78", new TimeSpan(0, 8, 15, 0, 0), 32 },
                    { 172, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN003000172", "85", new TimeSpan(0, 12, 30, 0, 0), 32 },
                    { 173, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN003000173", "72", new TimeSpan(0, 16, 45, 0, 0), 32 },
                    { 174, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN003000174", "88", new TimeSpan(0, 20, 0, 0, 0), 32 },
                    { 175, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN003000175", "75", new TimeSpan(0, 6, 20, 0, 0), 32 },
                    { 176, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN003000176", "82", new TimeSpan(0, 10, 35, 0, 0), 32 },
                    { 177, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN003000177", "79", new TimeSpan(0, 14, 50, 0, 0), 33 },
                    { 178, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN003000178", "86", new TimeSpan(0, 18, 5, 0, 0), 33 },
                    { 179, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN003000179", "74", new TimeSpan(0, 22, 25, 0, 0), 33 },
                    { 180, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN003000180", "81", new TimeSpan(0, 2, 40, 0, 0), 33 },
                    { 181, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN003000181", "78", new TimeSpan(0, 8, 15, 0, 0), 34 },
                    { 182, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN003000182", "85", new TimeSpan(0, 12, 30, 0, 0), 34 },
                    { 183, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN003000183", "72", new TimeSpan(0, 16, 45, 0, 0), 34 },
                    { 184, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN003000184", "88", new TimeSpan(0, 20, 0, 0, 0), 34 },
                    { 185, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN003000185", "75", new TimeSpan(0, 6, 20, 0, 0), 34 },
                    { 186, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN003000186", "82", new TimeSpan(0, 10, 35, 0, 0), 34 },
                    { 187, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN003000187", "79", new TimeSpan(0, 14, 50, 0, 0), 34 },
                    { 188, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN003000188", "86", new TimeSpan(0, 18, 5, 0, 0), 35 },
                    { 189, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN003000189", "74", new TimeSpan(0, 22, 25, 0, 0), 35 },
                    { 190, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN003000190", "81", new TimeSpan(0, 2, 40, 0, 0), 35 },
                    { 191, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN003000191", "78", new TimeSpan(0, 8, 15, 0, 0), 35 },
                    { 192, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN003000192", "85", new TimeSpan(0, 12, 30, 0, 0), 35 },
                    { 193, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN003000193", "72", new TimeSpan(0, 16, 45, 0, 0), 36 },
                    { 194, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN003000194", "88", new TimeSpan(0, 20, 0, 0, 0), 36 },
                    { 195, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN003000195", "75", new TimeSpan(0, 6, 20, 0, 0), 36 },
                    { 196, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN003000196", "82", new TimeSpan(0, 10, 35, 0, 0), 36 },
                    { 197, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN003000197", "79", new TimeSpan(0, 14, 50, 0, 0), 36 },
                    { 198, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN003000198", "86", new TimeSpan(0, 18, 5, 0, 0), 36 },
                    { 199, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN003000199", "74", new TimeSpan(0, 22, 25, 0, 0), 37 },
                    { 200, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN003000200", "81", new TimeSpan(0, 2, 40, 0, 0), 37 },
                    { 201, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN003000201", "78", new TimeSpan(0, 8, 15, 0, 0), 37 },
                    { 202, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN003000202", "85", new TimeSpan(0, 12, 30, 0, 0), 37 },
                    { 203, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN003000203", "72", new TimeSpan(0, 16, 45, 0, 0), 38 },
                    { 204, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN003000204", "88", new TimeSpan(0, 20, 0, 0, 0), 38 },
                    { 205, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN003000205", "75", new TimeSpan(0, 6, 20, 0, 0), 38 },
                    { 206, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN003000206", "82", new TimeSpan(0, 10, 35, 0, 0), 38 },
                    { 207, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN003000207", "79", new TimeSpan(0, 14, 50, 0, 0), 38 },
                    { 208, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN003000208", "86", new TimeSpan(0, 18, 5, 0, 0), 39 },
                    { 209, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN003000209", "74", new TimeSpan(0, 22, 25, 0, 0), 39 },
                    { 210, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN003000210", "81", new TimeSpan(0, 2, 40, 0, 0), 39 },
                    { 211, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN003000211", "78", new TimeSpan(0, 8, 15, 0, 0), 39 },
                    { 212, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN003000212", "85", new TimeSpan(0, 12, 30, 0, 0), 39 },
                    { 213, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN003000213", "72", new TimeSpan(0, 16, 45, 0, 0), 39 },
                    { 214, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN003000214", "88", new TimeSpan(0, 20, 0, 0, 0), 40 },
                    { 215, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN003000215", "75", new TimeSpan(0, 6, 20, 0, 0), 40 },
                    { 216, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN003000216", "82", new TimeSpan(0, 10, 35, 0, 0), 40 },
                    { 217, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN003000217", "79", new TimeSpan(0, 14, 50, 0, 0), 40 },
                    { 218, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN003000218", "86", new TimeSpan(0, 18, 5, 0, 0), 40 },
                    { 219, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN003000219", "74", new TimeSpan(0, 22, 25, 0, 0), 40 },
                    { 220, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN003000220", "81", new TimeSpan(0, 2, 40, 0, 0), 40 },
                    { 221, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN003000221", "78", new TimeSpan(0, 8, 15, 0, 0), 41 },
                    { 222, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN003000222", "85", new TimeSpan(0, 12, 30, 0, 0), 41 },
                    { 223, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN003000223", "72", new TimeSpan(0, 16, 45, 0, 0), 41 },
                    { 224, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN003000224", "88", new TimeSpan(0, 20, 0, 0, 0), 41 },
                    { 225, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN003000225", "75", new TimeSpan(0, 6, 20, 0, 0), 41 },
                    { 226, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN003000226", "82", new TimeSpan(0, 10, 35, 0, 0), 42 },
                    { 227, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN003000227", "79", new TimeSpan(0, 14, 50, 0, 0), 42 },
                    { 228, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN003000228", "86", new TimeSpan(0, 18, 5, 0, 0), 42 },
                    { 229, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN003000229", "74", new TimeSpan(0, 22, 25, 0, 0), 42 },
                    { 230, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN003000230", "81", new TimeSpan(0, 2, 40, 0, 0), 42 },
                    { 231, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN003000231", "78", new TimeSpan(0, 8, 15, 0, 0), 42 },
                    { 232, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN003000232", "85", new TimeSpan(0, 12, 30, 0, 0), 43 },
                    { 233, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN003000233", "72", new TimeSpan(0, 16, 45, 0, 0), 43 },
                    { 234, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN003000234", "88", new TimeSpan(0, 20, 0, 0, 0), 43 },
                    { 235, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN003000235", "75", new TimeSpan(0, 6, 20, 0, 0), 43 },
                    { 236, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN003000236", "82", new TimeSpan(0, 10, 35, 0, 0), 44 },
                    { 237, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN003000237", "79", new TimeSpan(0, 14, 50, 0, 0), 44 },
                    { 238, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN003000238", "86", new TimeSpan(0, 18, 5, 0, 0), 44 },
                    { 239, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN003000239", "74", new TimeSpan(0, 22, 25, 0, 0), 44 },
                    { 240, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN003000240", "81", new TimeSpan(0, 2, 40, 0, 0), 44 },
                    { 241, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN003000241", "78", new TimeSpan(0, 8, 15, 0, 0), 44 },
                    { 242, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN003000242", "85", new TimeSpan(0, 12, 30, 0, 0), 44 },
                    { 243, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN003000243", "72", new TimeSpan(0, 16, 45, 0, 0), 45 },
                    { 244, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN003000244", "88", new TimeSpan(0, 20, 0, 0, 0), 45 },
                    { 245, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN003000245", "75", new TimeSpan(0, 6, 20, 0, 0), 45 },
                    { 246, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN003000246", "82", new TimeSpan(0, 10, 35, 0, 0), 45 },
                    { 247, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN003000247", "79", new TimeSpan(0, 14, 50, 0, 0), 45 },
                    { 331, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN005000331", "78", new TimeSpan(0, 8, 15, 0, 0), 61 },
                    { 332, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN005000332", "85", new TimeSpan(0, 12, 30, 0, 0), 61 },
                    { 333, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN005000333", "72", new TimeSpan(0, 16, 45, 0, 0), 61 },
                    { 334, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN005000334", "88", new TimeSpan(0, 20, 0, 0, 0), 61 },
                    { 335, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN005000335", "75", new TimeSpan(0, 6, 20, 0, 0), 61 },
                    { 336, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN005000336", "82", new TimeSpan(0, 10, 35, 0, 0), 62 },
                    { 337, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN005000337", "79", new TimeSpan(0, 14, 50, 0, 0), 62 },
                    { 338, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN005000338", "86", new TimeSpan(0, 18, 5, 0, 0), 62 },
                    { 339, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN005000339", "74", new TimeSpan(0, 22, 25, 0, 0), 62 },
                    { 340, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN005000340", "81", new TimeSpan(0, 2, 40, 0, 0), 62 },
                    { 341, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN005000341", "78", new TimeSpan(0, 8, 15, 0, 0), 62 },
                    { 342, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN005000342", "85", new TimeSpan(0, 12, 30, 0, 0), 63 },
                    { 343, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN005000343", "72", new TimeSpan(0, 16, 45, 0, 0), 63 },
                    { 344, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN005000344", "88", new TimeSpan(0, 20, 0, 0, 0), 63 },
                    { 345, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN005000345", "75", new TimeSpan(0, 6, 20, 0, 0), 63 },
                    { 346, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN005000346", "82", new TimeSpan(0, 10, 35, 0, 0), 64 },
                    { 347, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN005000347", "79", new TimeSpan(0, 14, 50, 0, 0), 64 },
                    { 348, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN005000348", "86", new TimeSpan(0, 18, 5, 0, 0), 64 },
                    { 349, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN005000349", "74", new TimeSpan(0, 22, 25, 0, 0), 64 },
                    { 350, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN005000350", "81", new TimeSpan(0, 2, 40, 0, 0), 64 },
                    { 351, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN005000351", "78", new TimeSpan(0, 8, 15, 0, 0), 64 },
                    { 352, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN005000352", "85", new TimeSpan(0, 12, 30, 0, 0), 64 },
                    { 353, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN005000353", "72", new TimeSpan(0, 16, 45, 0, 0), 65 },
                    { 354, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN005000354", "88", new TimeSpan(0, 20, 0, 0, 0), 65 },
                    { 355, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN005000355", "75", new TimeSpan(0, 6, 20, 0, 0), 65 },
                    { 356, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN005000356", "82", new TimeSpan(0, 10, 35, 0, 0), 65 },
                    { 357, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN005000357", "79", new TimeSpan(0, 14, 50, 0, 0), 65 },
                    { 358, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN005000358", "86", new TimeSpan(0, 18, 5, 0, 0), 66 },
                    { 359, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN005000359", "74", new TimeSpan(0, 22, 25, 0, 0), 66 },
                    { 360, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN005000360", "81", new TimeSpan(0, 2, 40, 0, 0), 66 },
                    { 361, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN005000361", "78", new TimeSpan(0, 8, 15, 0, 0), 66 },
                    { 362, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN005000362", "85", new TimeSpan(0, 12, 30, 0, 0), 66 },
                    { 363, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN005000363", "72", new TimeSpan(0, 16, 45, 0, 0), 66 },
                    { 364, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN005000364", "88", new TimeSpan(0, 20, 0, 0, 0), 67 },
                    { 365, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN005000365", "75", new TimeSpan(0, 6, 20, 0, 0), 67 },
                    { 366, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN005000366", "82", new TimeSpan(0, 10, 35, 0, 0), 67 },
                    { 367, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN005000367", "79", new TimeSpan(0, 14, 50, 0, 0), 67 },
                    { 368, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN005000368", "86", new TimeSpan(0, 18, 5, 0, 0), 68 },
                    { 369, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN005000369", "74", new TimeSpan(0, 22, 25, 0, 0), 68 },
                    { 370, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN005000370", "81", new TimeSpan(0, 2, 40, 0, 0), 68 },
                    { 371, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN005000371", "78", new TimeSpan(0, 8, 15, 0, 0), 68 },
                    { 372, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN005000372", "85", new TimeSpan(0, 12, 30, 0, 0), 68 },
                    { 373, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN005000373", "72", new TimeSpan(0, 16, 45, 0, 0), 69 },
                    { 374, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN005000374", "88", new TimeSpan(0, 20, 0, 0, 0), 69 },
                    { 375, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN005000375", "75", new TimeSpan(0, 6, 20, 0, 0), 69 },
                    { 376, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN005000376", "82", new TimeSpan(0, 10, 35, 0, 0), 69 },
                    { 377, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN005000377", "79", new TimeSpan(0, 14, 50, 0, 0), 69 },
                    { 378, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN005000378", "86", new TimeSpan(0, 18, 5, 0, 0), 69 },
                    { 379, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN005000379", "74", new TimeSpan(0, 22, 25, 0, 0), 70 },
                    { 380, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN005000380", "81", new TimeSpan(0, 2, 40, 0, 0), 70 },
                    { 381, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN005000381", "78", new TimeSpan(0, 8, 15, 0, 0), 70 },
                    { 382, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN005000382", "85", new TimeSpan(0, 12, 30, 0, 0), 70 },
                    { 383, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN005000383", "72", new TimeSpan(0, 16, 45, 0, 0), 70 },
                    { 384, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN005000384", "88", new TimeSpan(0, 20, 0, 0, 0), 70 },
                    { 385, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN005000385", "75", new TimeSpan(0, 6, 20, 0, 0), 70 },
                    { 386, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN005000386", "82", new TimeSpan(0, 10, 35, 0, 0), 71 },
                    { 387, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN005000387", "79", new TimeSpan(0, 14, 50, 0, 0), 71 },
                    { 388, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN005000388", "86", new TimeSpan(0, 18, 5, 0, 0), 71 },
                    { 389, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN005000389", "74", new TimeSpan(0, 22, 25, 0, 0), 71 },
                    { 390, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN005000390", "81", new TimeSpan(0, 2, 40, 0, 0), 71 },
                    { 391, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN005000391", "78", new TimeSpan(0, 8, 15, 0, 0), 72 },
                    { 392, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN005000392", "85", new TimeSpan(0, 12, 30, 0, 0), 72 },
                    { 393, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN005000393", "72", new TimeSpan(0, 16, 45, 0, 0), 72 },
                    { 394, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN005000394", "88", new TimeSpan(0, 20, 0, 0, 0), 72 },
                    { 395, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN005000395", "75", new TimeSpan(0, 6, 20, 0, 0), 72 },
                    { 396, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN005000396", "82", new TimeSpan(0, 10, 35, 0, 0), 72 },
                    { 397, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN005000397", "79", new TimeSpan(0, 14, 50, 0, 0), 73 },
                    { 398, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN005000398", "86", new TimeSpan(0, 18, 5, 0, 0), 73 },
                    { 399, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN005000399", "74", new TimeSpan(0, 22, 25, 0, 0), 73 },
                    { 400, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN005000400", "81", new TimeSpan(0, 2, 40, 0, 0), 73 },
                    { 401, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN005000401", "78", new TimeSpan(0, 8, 15, 0, 0), 74 },
                    { 402, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN005000402", "85", new TimeSpan(0, 12, 30, 0, 0), 74 },
                    { 403, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN005000403", "72", new TimeSpan(0, 16, 45, 0, 0), 74 },
                    { 404, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN005000404", "88", new TimeSpan(0, 20, 0, 0, 0), 74 },
                    { 405, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN005000405", "75", new TimeSpan(0, 6, 20, 0, 0), 74 },
                    { 406, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN005000406", "82", new TimeSpan(0, 10, 35, 0, 0), 74 },
                    { 407, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN005000407", "79", new TimeSpan(0, 14, 50, 0, 0), 74 },
                    { 408, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN005000408", "86", new TimeSpan(0, 18, 5, 0, 0), 75 },
                    { 409, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN005000409", "74", new TimeSpan(0, 22, 25, 0, 0), 75 },
                    { 410, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN005000410", "81", new TimeSpan(0, 2, 40, 0, 0), 75 },
                    { 411, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN005000411", "78", new TimeSpan(0, 8, 15, 0, 0), 75 },
                    { 412, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN005000412", "85", new TimeSpan(0, 12, 30, 0, 0), 75 },
                    { 413, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN006000413", "72", new TimeSpan(0, 16, 45, 0, 0), 76 },
                    { 414, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN006000414", "88", new TimeSpan(0, 20, 0, 0, 0), 76 },
                    { 415, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN006000415", "75", new TimeSpan(0, 6, 20, 0, 0), 76 },
                    { 416, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN006000416", "82", new TimeSpan(0, 10, 35, 0, 0), 76 },
                    { 417, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN006000417", "79", new TimeSpan(0, 14, 50, 0, 0), 76 },
                    { 418, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN006000418", "86", new TimeSpan(0, 18, 5, 0, 0), 76 },
                    { 419, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN006000419", "74", new TimeSpan(0, 22, 25, 0, 0), 77 },
                    { 420, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN006000420", "81", new TimeSpan(0, 2, 40, 0, 0), 77 },
                    { 421, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN006000421", "78", new TimeSpan(0, 8, 15, 0, 0), 77 },
                    { 422, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN006000422", "85", new TimeSpan(0, 12, 30, 0, 0), 77 },
                    { 423, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN006000423", "72", new TimeSpan(0, 16, 45, 0, 0), 78 },
                    { 424, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN006000424", "88", new TimeSpan(0, 20, 0, 0, 0), 78 },
                    { 425, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN006000425", "75", new TimeSpan(0, 6, 20, 0, 0), 78 },
                    { 426, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN006000426", "82", new TimeSpan(0, 10, 35, 0, 0), 78 },
                    { 427, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN006000427", "79", new TimeSpan(0, 14, 50, 0, 0), 78 },
                    { 428, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN006000428", "86", new TimeSpan(0, 18, 5, 0, 0), 79 },
                    { 429, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN006000429", "74", new TimeSpan(0, 22, 25, 0, 0), 79 },
                    { 430, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN006000430", "81", new TimeSpan(0, 2, 40, 0, 0), 79 },
                    { 431, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN006000431", "78", new TimeSpan(0, 8, 15, 0, 0), 79 },
                    { 432, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN006000432", "85", new TimeSpan(0, 12, 30, 0, 0), 79 },
                    { 433, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN006000433", "72", new TimeSpan(0, 16, 45, 0, 0), 79 },
                    { 434, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN006000434", "88", new TimeSpan(0, 20, 0, 0, 0), 80 },
                    { 435, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN006000435", "75", new TimeSpan(0, 6, 20, 0, 0), 80 },
                    { 436, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN006000436", "82", new TimeSpan(0, 10, 35, 0, 0), 80 },
                    { 437, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN006000437", "79", new TimeSpan(0, 14, 50, 0, 0), 80 },
                    { 438, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN006000438", "86", new TimeSpan(0, 18, 5, 0, 0), 80 },
                    { 439, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN006000439", "74", new TimeSpan(0, 22, 25, 0, 0), 80 },
                    { 440, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN006000440", "81", new TimeSpan(0, 2, 40, 0, 0), 80 },
                    { 441, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN006000441", "78", new TimeSpan(0, 8, 15, 0, 0), 81 },
                    { 442, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN006000442", "85", new TimeSpan(0, 12, 30, 0, 0), 81 },
                    { 443, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN006000443", "72", new TimeSpan(0, 16, 45, 0, 0), 81 },
                    { 444, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN006000444", "88", new TimeSpan(0, 20, 0, 0, 0), 81 },
                    { 445, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN006000445", "75", new TimeSpan(0, 6, 20, 0, 0), 81 },
                    { 446, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN006000446", "82", new TimeSpan(0, 10, 35, 0, 0), 82 },
                    { 447, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN006000447", "79", new TimeSpan(0, 14, 50, 0, 0), 82 },
                    { 448, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN006000448", "86", new TimeSpan(0, 18, 5, 0, 0), 82 },
                    { 449, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN006000449", "74", new TimeSpan(0, 22, 25, 0, 0), 82 },
                    { 450, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN006000450", "81", new TimeSpan(0, 2, 40, 0, 0), 82 },
                    { 451, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN006000451", "78", new TimeSpan(0, 8, 15, 0, 0), 82 },
                    { 452, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN006000452", "85", new TimeSpan(0, 12, 30, 0, 0), 83 },
                    { 453, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN006000453", "72", new TimeSpan(0, 16, 45, 0, 0), 83 },
                    { 454, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN006000454", "88", new TimeSpan(0, 20, 0, 0, 0), 83 },
                    { 455, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN006000455", "75", new TimeSpan(0, 6, 20, 0, 0), 83 },
                    { 456, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN006000456", "82", new TimeSpan(0, 10, 35, 0, 0), 84 },
                    { 457, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN006000457", "79", new TimeSpan(0, 14, 50, 0, 0), 84 },
                    { 458, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN006000458", "86", new TimeSpan(0, 18, 5, 0, 0), 84 },
                    { 459, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN006000459", "74", new TimeSpan(0, 22, 25, 0, 0), 84 },
                    { 460, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN006000460", "81", new TimeSpan(0, 2, 40, 0, 0), 84 },
                    { 461, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN006000461", "78", new TimeSpan(0, 8, 15, 0, 0), 84 },
                    { 462, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN006000462", "85", new TimeSpan(0, 12, 30, 0, 0), 84 },
                    { 463, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN006000463", "72", new TimeSpan(0, 16, 45, 0, 0), 85 },
                    { 464, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN006000464", "88", new TimeSpan(0, 20, 0, 0, 0), 85 },
                    { 465, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN006000465", "75", new TimeSpan(0, 6, 20, 0, 0), 85 },
                    { 466, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN006000466", "82", new TimeSpan(0, 10, 35, 0, 0), 85 },
                    { 467, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN006000467", "79", new TimeSpan(0, 14, 50, 0, 0), 85 },
                    { 468, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN006000468", "86", new TimeSpan(0, 18, 5, 0, 0), 86 },
                    { 469, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN006000469", "74", new TimeSpan(0, 22, 25, 0, 0), 86 },
                    { 470, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN006000470", "81", new TimeSpan(0, 2, 40, 0, 0), 86 },
                    { 471, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN006000471", "78", new TimeSpan(0, 8, 15, 0, 0), 86 },
                    { 472, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN006000472", "85", new TimeSpan(0, 12, 30, 0, 0), 86 },
                    { 473, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN006000473", "72", new TimeSpan(0, 16, 45, 0, 0), 86 },
                    { 474, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN006000474", "88", new TimeSpan(0, 20, 0, 0, 0), 87 },
                    { 475, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN006000475", "75", new TimeSpan(0, 6, 20, 0, 0), 87 },
                    { 476, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN006000476", "82", new TimeSpan(0, 10, 35, 0, 0), 87 },
                    { 477, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN006000477", "79", new TimeSpan(0, 14, 50, 0, 0), 87 },
                    { 478, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN006000478", "86", new TimeSpan(0, 18, 5, 0, 0), 88 },
                    { 479, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN006000479", "74", new TimeSpan(0, 22, 25, 0, 0), 88 },
                    { 480, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN006000480", "81", new TimeSpan(0, 2, 40, 0, 0), 88 },
                    { 481, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN006000481", "78", new TimeSpan(0, 8, 15, 0, 0), 88 },
                    { 482, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN006000482", "85", new TimeSpan(0, 12, 30, 0, 0), 88 },
                    { 483, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN006000483", "72", new TimeSpan(0, 16, 45, 0, 0), 89 },
                    { 484, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN006000484", "88", new TimeSpan(0, 20, 0, 0, 0), 89 },
                    { 485, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN006000485", "75", new TimeSpan(0, 6, 20, 0, 0), 89 },
                    { 486, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN006000486", "82", new TimeSpan(0, 10, 35, 0, 0), 89 },
                    { 487, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN006000487", "79", new TimeSpan(0, 14, 50, 0, 0), 89 },
                    { 488, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN006000488", "86", new TimeSpan(0, 18, 5, 0, 0), 89 },
                    { 489, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN006000489", "74", new TimeSpan(0, 22, 25, 0, 0), 90 },
                    { 490, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN006000490", "81", new TimeSpan(0, 2, 40, 0, 0), 90 },
                    { 491, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN006000491", "78", new TimeSpan(0, 8, 15, 0, 0), 90 },
                    { 492, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN006000492", "85", new TimeSpan(0, 12, 30, 0, 0), 90 },
                    { 493, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN006000493", "72", new TimeSpan(0, 16, 45, 0, 0), 90 },
                    { 494, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN006000494", "88", new TimeSpan(0, 20, 0, 0, 0), 90 },
                    { 495, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN006000495", "75", new TimeSpan(0, 6, 20, 0, 0), 90 },
                    { 496, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN007000496", "82", new TimeSpan(0, 10, 35, 0, 0), 91 },
                    { 497, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN007000497", "79", new TimeSpan(0, 14, 50, 0, 0), 91 },
                    { 498, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN007000498", "86", new TimeSpan(0, 18, 5, 0, 0), 91 },
                    { 499, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN007000499", "74", new TimeSpan(0, 22, 25, 0, 0), 91 },
                    { 500, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN007000500", "81", new TimeSpan(0, 2, 40, 0, 0), 91 },
                    { 501, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN007000501", "78", new TimeSpan(0, 8, 15, 0, 0), 92 },
                    { 502, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN007000502", "85", new TimeSpan(0, 12, 30, 0, 0), 92 },
                    { 503, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN007000503", "72", new TimeSpan(0, 16, 45, 0, 0), 92 },
                    { 504, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN007000504", "88", new TimeSpan(0, 20, 0, 0, 0), 92 },
                    { 505, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN007000505", "75", new TimeSpan(0, 6, 20, 0, 0), 92 },
                    { 506, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN007000506", "82", new TimeSpan(0, 10, 35, 0, 0), 92 },
                    { 507, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN007000507", "79", new TimeSpan(0, 14, 50, 0, 0), 93 },
                    { 508, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN007000508", "86", new TimeSpan(0, 18, 5, 0, 0), 93 },
                    { 509, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN007000509", "74", new TimeSpan(0, 22, 25, 0, 0), 93 },
                    { 510, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN007000510", "81", new TimeSpan(0, 2, 40, 0, 0), 93 },
                    { 511, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN007000511", "78", new TimeSpan(0, 8, 15, 0, 0), 94 },
                    { 512, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN007000512", "85", new TimeSpan(0, 12, 30, 0, 0), 94 },
                    { 513, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN007000513", "72", new TimeSpan(0, 16, 45, 0, 0), 94 },
                    { 514, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN007000514", "88", new TimeSpan(0, 20, 0, 0, 0), 94 },
                    { 515, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN007000515", "75", new TimeSpan(0, 6, 20, 0, 0), 94 },
                    { 516, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN007000516", "82", new TimeSpan(0, 10, 35, 0, 0), 94 },
                    { 517, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN007000517", "79", new TimeSpan(0, 14, 50, 0, 0), 94 },
                    { 518, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN007000518", "86", new TimeSpan(0, 18, 5, 0, 0), 95 },
                    { 519, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN007000519", "74", new TimeSpan(0, 22, 25, 0, 0), 95 },
                    { 520, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN007000520", "81", new TimeSpan(0, 2, 40, 0, 0), 95 },
                    { 521, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN007000521", "78", new TimeSpan(0, 8, 15, 0, 0), 95 },
                    { 522, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN007000522", "85", new TimeSpan(0, 12, 30, 0, 0), 95 },
                    { 523, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN007000523", "72", new TimeSpan(0, 16, 45, 0, 0), 96 },
                    { 524, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN007000524", "88", new TimeSpan(0, 20, 0, 0, 0), 96 },
                    { 525, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN007000525", "75", new TimeSpan(0, 6, 20, 0, 0), 96 },
                    { 526, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN007000526", "82", new TimeSpan(0, 10, 35, 0, 0), 96 },
                    { 527, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN007000527", "79", new TimeSpan(0, 14, 50, 0, 0), 96 },
                    { 528, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN007000528", "86", new TimeSpan(0, 18, 5, 0, 0), 96 },
                    { 529, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN007000529", "74", new TimeSpan(0, 22, 25, 0, 0), 97 },
                    { 530, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN007000530", "81", new TimeSpan(0, 2, 40, 0, 0), 97 },
                    { 531, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN007000531", "78", new TimeSpan(0, 8, 15, 0, 0), 97 },
                    { 532, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN007000532", "85", new TimeSpan(0, 12, 30, 0, 0), 97 },
                    { 533, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN007000533", "72", new TimeSpan(0, 16, 45, 0, 0), 98 },
                    { 534, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN007000534", "88", new TimeSpan(0, 20, 0, 0, 0), 98 },
                    { 535, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN007000535", "75", new TimeSpan(0, 6, 20, 0, 0), 98 },
                    { 536, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN007000536", "82", new TimeSpan(0, 10, 35, 0, 0), 98 },
                    { 537, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN007000537", "79", new TimeSpan(0, 14, 50, 0, 0), 98 },
                    { 538, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN007000538", "86", new TimeSpan(0, 18, 5, 0, 0), 99 },
                    { 539, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN007000539", "74", new TimeSpan(0, 22, 25, 0, 0), 99 },
                    { 540, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN007000540", "81", new TimeSpan(0, 2, 40, 0, 0), 99 },
                    { 541, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN007000541", "78", new TimeSpan(0, 8, 15, 0, 0), 99 },
                    { 542, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN007000542", "85", new TimeSpan(0, 12, 30, 0, 0), 99 },
                    { 543, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN007000543", "72", new TimeSpan(0, 16, 45, 0, 0), 99 },
                    { 544, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN007000544", "88", new TimeSpan(0, 20, 0, 0, 0), 100 },
                    { 545, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN007000545", "75", new TimeSpan(0, 6, 20, 0, 0), 100 },
                    { 546, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN007000546", "82", new TimeSpan(0, 10, 35, 0, 0), 100 },
                    { 547, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN007000547", "79", new TimeSpan(0, 14, 50, 0, 0), 100 },
                    { 548, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN007000548", "86", new TimeSpan(0, 18, 5, 0, 0), 100 },
                    { 549, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN007000549", "74", new TimeSpan(0, 22, 25, 0, 0), 100 },
                    { 550, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN007000550", "81", new TimeSpan(0, 2, 40, 0, 0), 100 },
                    { 551, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN007000551", "78", new TimeSpan(0, 8, 15, 0, 0), 101 },
                    { 552, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN007000552", "85", new TimeSpan(0, 12, 30, 0, 0), 101 },
                    { 553, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN007000553", "72", new TimeSpan(0, 16, 45, 0, 0), 101 },
                    { 554, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN007000554", "88", new TimeSpan(0, 20, 0, 0, 0), 101 },
                    { 555, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN007000555", "75", new TimeSpan(0, 6, 20, 0, 0), 101 },
                    { 556, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN007000556", "82", new TimeSpan(0, 10, 35, 0, 0), 102 },
                    { 557, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN007000557", "79", new TimeSpan(0, 14, 50, 0, 0), 102 },
                    { 558, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN007000558", "86", new TimeSpan(0, 18, 5, 0, 0), 102 },
                    { 559, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN007000559", "74", new TimeSpan(0, 22, 25, 0, 0), 102 },
                    { 560, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN007000560", "81", new TimeSpan(0, 2, 40, 0, 0), 102 },
                    { 561, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN007000561", "78", new TimeSpan(0, 8, 15, 0, 0), 102 },
                    { 562, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN007000562", "85", new TimeSpan(0, 12, 30, 0, 0), 103 },
                    { 563, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN007000563", "72", new TimeSpan(0, 16, 45, 0, 0), 103 },
                    { 564, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN007000564", "88", new TimeSpan(0, 20, 0, 0, 0), 103 },
                    { 565, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN007000565", "75", new TimeSpan(0, 6, 20, 0, 0), 103 },
                    { 566, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN007000566", "82", new TimeSpan(0, 10, 35, 0, 0), 104 },
                    { 567, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN007000567", "79", new TimeSpan(0, 14, 50, 0, 0), 104 },
                    { 568, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN007000568", "86", new TimeSpan(0, 18, 5, 0, 0), 104 },
                    { 569, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN007000569", "74", new TimeSpan(0, 22, 25, 0, 0), 104 },
                    { 570, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN007000570", "81", new TimeSpan(0, 2, 40, 0, 0), 104 },
                    { 571, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN007000571", "78", new TimeSpan(0, 8, 15, 0, 0), 104 },
                    { 572, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN007000572", "85", new TimeSpan(0, 12, 30, 0, 0), 104 },
                    { 573, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN007000573", "72", new TimeSpan(0, 16, 45, 0, 0), 105 },
                    { 574, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN007000574", "88", new TimeSpan(0, 20, 0, 0, 0), 105 },
                    { 575, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN007000575", "75", new TimeSpan(0, 6, 20, 0, 0), 105 },
                    { 576, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN007000576", "82", new TimeSpan(0, 10, 35, 0, 0), 105 },
                    { 577, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN007000577", "79", new TimeSpan(0, 14, 50, 0, 0), 105 },
                    { 578, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN008000578", "86", new TimeSpan(0, 18, 5, 0, 0), 106 },
                    { 579, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN008000579", "74", new TimeSpan(0, 22, 25, 0, 0), 106 },
                    { 580, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN008000580", "81", new TimeSpan(0, 2, 40, 0, 0), 106 },
                    { 581, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN008000581", "78", new TimeSpan(0, 8, 15, 0, 0), 106 },
                    { 582, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN008000582", "85", new TimeSpan(0, 12, 30, 0, 0), 106 },
                    { 583, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN008000583", "72", new TimeSpan(0, 16, 45, 0, 0), 106 },
                    { 584, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN008000584", "88", new TimeSpan(0, 20, 0, 0, 0), 107 },
                    { 585, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN008000585", "75", new TimeSpan(0, 6, 20, 0, 0), 107 },
                    { 586, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN008000586", "82", new TimeSpan(0, 10, 35, 0, 0), 107 },
                    { 587, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN008000587", "79", new TimeSpan(0, 14, 50, 0, 0), 107 },
                    { 588, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN008000588", "86", new TimeSpan(0, 18, 5, 0, 0), 108 },
                    { 589, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN008000589", "74", new TimeSpan(0, 22, 25, 0, 0), 108 },
                    { 590, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN008000590", "81", new TimeSpan(0, 2, 40, 0, 0), 108 },
                    { 591, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN008000591", "78", new TimeSpan(0, 8, 15, 0, 0), 108 },
                    { 592, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN008000592", "85", new TimeSpan(0, 12, 30, 0, 0), 108 },
                    { 593, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN008000593", "72", new TimeSpan(0, 16, 45, 0, 0), 109 },
                    { 594, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN008000594", "88", new TimeSpan(0, 20, 0, 0, 0), 109 },
                    { 595, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN008000595", "75", new TimeSpan(0, 6, 20, 0, 0), 109 },
                    { 596, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN008000596", "82", new TimeSpan(0, 10, 35, 0, 0), 109 },
                    { 597, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN008000597", "79", new TimeSpan(0, 14, 50, 0, 0), 109 },
                    { 598, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN008000598", "86", new TimeSpan(0, 18, 5, 0, 0), 109 },
                    { 599, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN008000599", "74", new TimeSpan(0, 22, 25, 0, 0), 110 },
                    { 600, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN008000600", "81", new TimeSpan(0, 2, 40, 0, 0), 110 },
                    { 601, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN008000601", "78", new TimeSpan(0, 8, 15, 0, 0), 110 },
                    { 602, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN008000602", "85", new TimeSpan(0, 12, 30, 0, 0), 110 },
                    { 603, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN008000603", "72", new TimeSpan(0, 16, 45, 0, 0), 110 },
                    { 604, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN008000604", "88", new TimeSpan(0, 20, 0, 0, 0), 110 },
                    { 605, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN008000605", "75", new TimeSpan(0, 6, 20, 0, 0), 110 },
                    { 606, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN008000606", "82", new TimeSpan(0, 10, 35, 0, 0), 111 },
                    { 607, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN008000607", "79", new TimeSpan(0, 14, 50, 0, 0), 111 },
                    { 608, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN008000608", "86", new TimeSpan(0, 18, 5, 0, 0), 111 },
                    { 609, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN008000609", "74", new TimeSpan(0, 22, 25, 0, 0), 111 },
                    { 610, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN008000610", "81", new TimeSpan(0, 2, 40, 0, 0), 111 },
                    { 611, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN008000611", "78", new TimeSpan(0, 8, 15, 0, 0), 112 },
                    { 612, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN008000612", "85", new TimeSpan(0, 12, 30, 0, 0), 112 },
                    { 613, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN008000613", "72", new TimeSpan(0, 16, 45, 0, 0), 112 },
                    { 614, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN008000614", "88", new TimeSpan(0, 20, 0, 0, 0), 112 },
                    { 615, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN008000615", "75", new TimeSpan(0, 6, 20, 0, 0), 112 },
                    { 616, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN008000616", "82", new TimeSpan(0, 10, 35, 0, 0), 112 },
                    { 617, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN008000617", "79", new TimeSpan(0, 14, 50, 0, 0), 113 },
                    { 618, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN008000618", "86", new TimeSpan(0, 18, 5, 0, 0), 113 },
                    { 619, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN008000619", "74", new TimeSpan(0, 22, 25, 0, 0), 113 },
                    { 620, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN008000620", "81", new TimeSpan(0, 2, 40, 0, 0), 113 },
                    { 621, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN008000621", "78", new TimeSpan(0, 8, 15, 0, 0), 114 },
                    { 622, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN008000622", "85", new TimeSpan(0, 12, 30, 0, 0), 114 },
                    { 623, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN008000623", "72", new TimeSpan(0, 16, 45, 0, 0), 114 },
                    { 624, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN008000624", "88", new TimeSpan(0, 20, 0, 0, 0), 114 },
                    { 625, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN008000625", "75", new TimeSpan(0, 6, 20, 0, 0), 114 },
                    { 626, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN008000626", "82", new TimeSpan(0, 10, 35, 0, 0), 114 },
                    { 627, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN008000627", "79", new TimeSpan(0, 14, 50, 0, 0), 114 },
                    { 628, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN008000628", "86", new TimeSpan(0, 18, 5, 0, 0), 115 },
                    { 629, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN008000629", "74", new TimeSpan(0, 22, 25, 0, 0), 115 },
                    { 630, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN008000630", "81", new TimeSpan(0, 2, 40, 0, 0), 115 },
                    { 631, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN008000631", "78", new TimeSpan(0, 8, 15, 0, 0), 115 },
                    { 632, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN008000632", "85", new TimeSpan(0, 12, 30, 0, 0), 115 },
                    { 633, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN008000633", "72", new TimeSpan(0, 16, 45, 0, 0), 116 },
                    { 634, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN008000634", "88", new TimeSpan(0, 20, 0, 0, 0), 116 },
                    { 635, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN008000635", "75", new TimeSpan(0, 6, 20, 0, 0), 116 },
                    { 636, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN008000636", "82", new TimeSpan(0, 10, 35, 0, 0), 116 },
                    { 637, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN008000637", "79", new TimeSpan(0, 14, 50, 0, 0), 116 },
                    { 638, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN008000638", "86", new TimeSpan(0, 18, 5, 0, 0), 116 },
                    { 639, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN008000639", "74", new TimeSpan(0, 22, 25, 0, 0), 117 },
                    { 640, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN008000640", "81", new TimeSpan(0, 2, 40, 0, 0), 117 },
                    { 641, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN008000641", "78", new TimeSpan(0, 8, 15, 0, 0), 117 },
                    { 642, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN008000642", "85", new TimeSpan(0, 12, 30, 0, 0), 117 },
                    { 643, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN008000643", "72", new TimeSpan(0, 16, 45, 0, 0), 118 },
                    { 644, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN008000644", "88", new TimeSpan(0, 20, 0, 0, 0), 118 },
                    { 645, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN008000645", "75", new TimeSpan(0, 6, 20, 0, 0), 118 },
                    { 646, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN008000646", "82", new TimeSpan(0, 10, 35, 0, 0), 118 },
                    { 647, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN008000647", "79", new TimeSpan(0, 14, 50, 0, 0), 118 },
                    { 648, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN008000648", "86", new TimeSpan(0, 18, 5, 0, 0), 119 },
                    { 649, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN008000649", "74", new TimeSpan(0, 22, 25, 0, 0), 119 },
                    { 650, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN008000650", "81", new TimeSpan(0, 2, 40, 0, 0), 119 },
                    { 651, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN008000651", "78", new TimeSpan(0, 8, 15, 0, 0), 119 },
                    { 652, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN008000652", "85", new TimeSpan(0, 12, 30, 0, 0), 119 },
                    { 653, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN008000653", "72", new TimeSpan(0, 16, 45, 0, 0), 119 },
                    { 654, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN008000654", "88", new TimeSpan(0, 20, 0, 0, 0), 120 },
                    { 655, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN008000655", "75", new TimeSpan(0, 6, 20, 0, 0), 120 },
                    { 656, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN008000656", "82", new TimeSpan(0, 10, 35, 0, 0), 120 },
                    { 657, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN008000657", "79", new TimeSpan(0, 14, 50, 0, 0), 120 },
                    { 658, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN008000658", "86", new TimeSpan(0, 18, 5, 0, 0), 120 },
                    { 659, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN008000659", "74", new TimeSpan(0, 22, 25, 0, 0), 120 },
                    { 660, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN008000660", "81", new TimeSpan(0, 2, 40, 0, 0), 120 },
                    { 743, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN010000743", "72", new TimeSpan(0, 16, 45, 0, 0), 136 },
                    { 744, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN010000744", "88", new TimeSpan(0, 20, 0, 0, 0), 136 },
                    { 745, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN010000745", "75", new TimeSpan(0, 6, 20, 0, 0), 136 },
                    { 746, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN010000746", "82", new TimeSpan(0, 10, 35, 0, 0), 136 },
                    { 747, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN010000747", "79", new TimeSpan(0, 14, 50, 0, 0), 136 },
                    { 748, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN010000748", "86", new TimeSpan(0, 18, 5, 0, 0), 136 },
                    { 749, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN010000749", "74", new TimeSpan(0, 22, 25, 0, 0), 137 },
                    { 750, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN010000750", "81", new TimeSpan(0, 2, 40, 0, 0), 137 },
                    { 751, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN010000751", "78", new TimeSpan(0, 8, 15, 0, 0), 137 },
                    { 752, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN010000752", "85", new TimeSpan(0, 12, 30, 0, 0), 137 },
                    { 753, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN010000753", "72", new TimeSpan(0, 16, 45, 0, 0), 138 },
                    { 754, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN010000754", "88", new TimeSpan(0, 20, 0, 0, 0), 138 },
                    { 755, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN010000755", "75", new TimeSpan(0, 6, 20, 0, 0), 138 },
                    { 756, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN010000756", "82", new TimeSpan(0, 10, 35, 0, 0), 138 },
                    { 757, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN010000757", "79", new TimeSpan(0, 14, 50, 0, 0), 138 },
                    { 758, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN010000758", "86", new TimeSpan(0, 18, 5, 0, 0), 139 },
                    { 759, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN010000759", "74", new TimeSpan(0, 22, 25, 0, 0), 139 },
                    { 760, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN010000760", "81", new TimeSpan(0, 2, 40, 0, 0), 139 },
                    { 761, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN010000761", "78", new TimeSpan(0, 8, 15, 0, 0), 139 },
                    { 762, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN010000762", "85", new TimeSpan(0, 12, 30, 0, 0), 139 },
                    { 763, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN010000763", "72", new TimeSpan(0, 16, 45, 0, 0), 139 },
                    { 764, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN010000764", "88", new TimeSpan(0, 20, 0, 0, 0), 140 },
                    { 765, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN010000765", "75", new TimeSpan(0, 6, 20, 0, 0), 140 },
                    { 766, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN010000766", "82", new TimeSpan(0, 10, 35, 0, 0), 140 },
                    { 767, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN010000767", "79", new TimeSpan(0, 14, 50, 0, 0), 140 },
                    { 768, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN010000768", "86", new TimeSpan(0, 18, 5, 0, 0), 140 },
                    { 769, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN010000769", "74", new TimeSpan(0, 22, 25, 0, 0), 140 },
                    { 770, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN010000770", "81", new TimeSpan(0, 2, 40, 0, 0), 140 },
                    { 771, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN010000771", "78", new TimeSpan(0, 8, 15, 0, 0), 141 },
                    { 772, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN010000772", "85", new TimeSpan(0, 12, 30, 0, 0), 141 },
                    { 773, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN010000773", "72", new TimeSpan(0, 16, 45, 0, 0), 141 },
                    { 774, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN010000774", "88", new TimeSpan(0, 20, 0, 0, 0), 141 },
                    { 775, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN010000775", "75", new TimeSpan(0, 6, 20, 0, 0), 141 },
                    { 776, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN010000776", "82", new TimeSpan(0, 10, 35, 0, 0), 142 },
                    { 777, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN010000777", "79", new TimeSpan(0, 14, 50, 0, 0), 142 },
                    { 778, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN010000778", "86", new TimeSpan(0, 18, 5, 0, 0), 142 },
                    { 779, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN010000779", "74", new TimeSpan(0, 22, 25, 0, 0), 142 },
                    { 780, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN010000780", "81", new TimeSpan(0, 2, 40, 0, 0), 142 },
                    { 781, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN010000781", "78", new TimeSpan(0, 8, 15, 0, 0), 142 },
                    { 782, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN010000782", "85", new TimeSpan(0, 12, 30, 0, 0), 143 },
                    { 783, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN010000783", "72", new TimeSpan(0, 16, 45, 0, 0), 143 },
                    { 784, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN010000784", "88", new TimeSpan(0, 20, 0, 0, 0), 143 },
                    { 785, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN010000785", "75", new TimeSpan(0, 6, 20, 0, 0), 143 },
                    { 786, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN010000786", "82", new TimeSpan(0, 10, 35, 0, 0), 144 },
                    { 787, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN010000787", "79", new TimeSpan(0, 14, 50, 0, 0), 144 },
                    { 788, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN010000788", "86", new TimeSpan(0, 18, 5, 0, 0), 144 },
                    { 789, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN010000789", "74", new TimeSpan(0, 22, 25, 0, 0), 144 },
                    { 790, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN010000790", "81", new TimeSpan(0, 2, 40, 0, 0), 144 },
                    { 791, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN010000791", "78", new TimeSpan(0, 8, 15, 0, 0), 144 },
                    { 792, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN010000792", "85", new TimeSpan(0, 12, 30, 0, 0), 144 },
                    { 793, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN010000793", "72", new TimeSpan(0, 16, 45, 0, 0), 145 },
                    { 794, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN010000794", "88", new TimeSpan(0, 20, 0, 0, 0), 145 },
                    { 795, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN010000795", "75", new TimeSpan(0, 6, 20, 0, 0), 145 },
                    { 796, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN010000796", "82", new TimeSpan(0, 10, 35, 0, 0), 145 },
                    { 797, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN010000797", "79", new TimeSpan(0, 14, 50, 0, 0), 145 },
                    { 798, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN010000798", "86", new TimeSpan(0, 18, 5, 0, 0), 146 },
                    { 799, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN010000799", "74", new TimeSpan(0, 22, 25, 0, 0), 146 },
                    { 800, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN010000800", "81", new TimeSpan(0, 2, 40, 0, 0), 146 },
                    { 801, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN010000801", "78", new TimeSpan(0, 8, 15, 0, 0), 146 },
                    { 802, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN010000802", "85", new TimeSpan(0, 12, 30, 0, 0), 146 },
                    { 803, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN010000803", "72", new TimeSpan(0, 16, 45, 0, 0), 146 },
                    { 804, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN010000804", "88", new TimeSpan(0, 20, 0, 0, 0), 147 },
                    { 805, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN010000805", "75", new TimeSpan(0, 6, 20, 0, 0), 147 },
                    { 806, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN010000806", "82", new TimeSpan(0, 10, 35, 0, 0), 147 },
                    { 807, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN010000807", "79", new TimeSpan(0, 14, 50, 0, 0), 147 },
                    { 808, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN010000808", "86", new TimeSpan(0, 18, 5, 0, 0), 148 },
                    { 809, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN010000809", "74", new TimeSpan(0, 22, 25, 0, 0), 148 },
                    { 810, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN010000810", "81", new TimeSpan(0, 2, 40, 0, 0), 148 },
                    { 811, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN010000811", "78", new TimeSpan(0, 8, 15, 0, 0), 148 },
                    { 812, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN010000812", "85", new TimeSpan(0, 12, 30, 0, 0), 148 },
                    { 813, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN010000813", "72", new TimeSpan(0, 16, 45, 0, 0), 149 },
                    { 814, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN010000814", "88", new TimeSpan(0, 20, 0, 0, 0), 149 },
                    { 815, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN010000815", "75", new TimeSpan(0, 6, 20, 0, 0), 149 },
                    { 816, "87", 580, "580", 540, 1, false, true, "22", "51", "19", "0.0", "0.0", "68", "31", "31", "33", "10", "SN010000816", "82", new TimeSpan(0, 10, 35, 0, 0), 149 },
                    { 817, "94", 490, "490", 870, 0, true, false, "19", "69", "10", "0.0", "0.0", "51", "22", "26", "25", "6", "SN010000817", "79", new TimeSpan(0, 14, 50, 0, 0), 149 },
                    { 818, "89", 430, "430", 410, 1, false, true, "26", "42", "16", "0.0", "0.0", "79", "38", "29", "36", "14", "SN010000818", "86", new TimeSpan(0, 18, 5, 0, 0), 149 },
                    { 819, "93", 560, "560", 690, 0, true, false, "14", "61", "13", "0.0", "0.0", "42", "26", "33", "19", "9", "SN010000819", "74", new TimeSpan(0, 22, 25, 0, 0), 150 },
                    { 820, "86", 410, "410", 520, 1, false, true, "21", "48", "20", "0.0", "0.0", "63", "33", "24", "31", "11", "SN010000820", "81", new TimeSpan(0, 2, 40, 0, 0), 150 },
                    { 821, "92", 450, "450", 450, 1, false, true, "18", "65", "12", "0.0", "0.0", "55", "25", "28", "22", "8", "SN010000821", "78", new TimeSpan(0, 8, 15, 0, 0), 150 },
                    { 822, "85", 520, "520", 320, 0, true, false, "25", "45", "18", "0.0", "0.0", "72", "35", "32", "35", "12", "SN010000822", "85", new TimeSpan(0, 12, 30, 0, 0), 150 },
                    { 823, "96", 380, "380", 780, 1, false, true, "12", "72", "8", "0.0", "0.0", "38", "18", "25", "18", "5", "SN010000823", "72", new TimeSpan(0, 16, 45, 0, 0), 150 },
                    { 824, "88", 620, "620", 650, 1, true, true, "28", "38", "22", "0.0", "0.0", "84", "42", "30", "38", "15", "SN010000824", "88", new TimeSpan(0, 20, 0, 0, 0), 150 },
                    { 825, "91", 340, "340", 290, 0, true, false, "15", "58", "15", "0.0", "0.0", "46", "28", "27", "20", "7", "SN010000825", "75", new TimeSpan(0, 6, 20, 0, 0), 150 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrapReads_TrapId_Date",
                table: "TrapReads",
                columns: new[] { "TrapId", "Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReadDetails_Time_TrapReadId",
                table: "ReadDetails",
                columns: new[] { "Time", "TrapReadId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrapReads_TrapId_Date",
                table: "TrapReads");

            migrationBuilder.DropIndex(
                name: "IX_ReadDetails_Time_TrapReadId",
                table: "ReadDetails");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 407);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 409);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 411);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 412);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 413);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 414);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 415);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 416);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 417);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 418);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 419);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 420);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 421);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 422);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 423);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 424);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 425);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 426);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 427);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 428);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 429);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 430);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 431);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 432);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 433);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 434);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 435);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 436);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 437);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 438);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 439);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 440);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 441);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 442);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 443);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 444);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 445);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 446);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 447);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 448);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 449);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 450);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 451);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 452);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 453);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 454);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 455);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 456);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 457);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 458);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 459);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 460);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 461);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 462);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 463);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 464);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 465);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 466);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 467);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 468);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 469);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 470);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 471);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 472);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 473);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 474);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 475);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 476);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 477);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 478);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 479);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 480);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 481);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 482);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 483);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 484);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 485);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 486);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 487);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 488);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 489);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 490);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 491);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 492);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 493);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 494);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 495);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 496);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 497);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 498);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 499);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 500);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 502);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 503);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 504);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 505);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 506);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 507);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 508);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 509);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 510);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 511);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 512);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 513);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 514);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 515);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 516);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 517);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 518);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 519);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 520);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 521);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 522);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 523);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 524);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 525);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 526);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 527);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 528);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 529);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 530);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 531);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 532);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 533);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 534);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 535);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 536);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 537);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 538);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 539);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 540);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 541);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 542);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 543);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 544);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 545);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 546);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 547);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 548);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 549);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 550);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 551);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 552);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 553);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 554);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 555);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 556);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 557);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 558);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 559);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 560);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 561);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 562);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 563);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 564);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 565);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 566);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 567);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 568);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 569);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 570);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 571);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 572);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 573);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 574);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 575);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 576);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 577);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 578);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 579);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 580);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 581);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 582);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 583);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 584);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 585);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 586);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 587);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 588);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 589);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 590);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 591);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 592);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 593);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 594);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 595);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 596);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 597);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 598);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 599);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 600);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 601);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 602);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 603);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 604);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 605);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 606);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 607);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 608);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 609);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 610);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 611);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 612);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 613);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 614);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 615);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 616);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 617);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 618);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 619);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 620);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 621);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 622);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 623);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 624);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 625);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 626);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 627);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 628);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 629);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 630);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 631);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 632);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 633);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 634);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 635);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 636);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 637);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 638);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 639);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 640);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 641);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 642);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 643);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 644);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 645);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 646);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 647);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 648);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 649);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 650);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 651);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 652);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 653);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 654);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 655);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 656);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 657);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 658);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 659);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 660);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 661);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 662);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 663);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 664);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 665);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 666);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 667);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 668);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 669);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 670);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 671);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 672);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 673);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 674);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 675);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 676);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 677);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 678);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 679);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 680);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 681);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 682);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 683);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 684);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 685);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 686);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 687);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 688);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 689);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 690);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 691);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 692);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 693);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 694);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 695);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 696);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 697);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 698);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 699);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 700);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 701);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 702);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 703);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 704);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 705);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 706);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 707);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 708);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 709);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 710);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 711);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 712);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 713);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 714);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 715);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 716);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 717);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 718);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 719);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 720);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 721);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 722);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 723);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 724);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 725);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 726);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 727);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 728);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 729);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 730);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 731);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 732);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 733);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 734);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 735);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 736);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 737);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 738);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 739);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 740);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 741);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 742);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 743);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 744);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 745);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 746);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 747);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 748);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 749);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 750);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 751);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 752);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 753);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 754);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 755);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 756);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 757);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 758);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 759);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 760);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 761);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 762);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 763);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 764);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 765);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 766);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 767);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 768);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 769);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 770);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 771);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 772);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 773);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 774);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 775);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 776);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 777);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 778);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 779);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 780);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 781);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 782);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 783);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 784);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 785);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 786);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 787);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 788);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 789);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 790);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 791);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 792);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 793);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 794);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 795);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 796);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 797);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 798);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 799);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 800);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 801);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 802);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 803);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 804);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 805);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 806);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 807);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 808);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 809);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 810);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 811);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 812);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 813);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 814);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 815);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 816);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 817);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 818);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 819);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 820);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 821);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 822);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 823);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 824);

            migrationBuilder.DeleteData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 825);

            migrationBuilder.DeleteData(
                table: "TrapCounterSchedules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrapCounterSchedules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TrapCounterSchedules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TrapCounterSchedules",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TrapCounterSchedules",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TrapCounterSchedules",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TrapCounterSchedules",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TrapCounterSchedules",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TrapCounterSchedules",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TrapCounterSchedules",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TrapCounterSchedules",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TrapCounterSchedules",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TrapCounterSchedules",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TrapCounterSchedules",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TrapCounterSchedules",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TrapCounterSchedules",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TrapCounterSchedules",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TrapCounterSchedules",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TrapCounterSchedules",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TrapCounterSchedules",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "TrapFanSchedules",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TrapFanSchedules",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TrapFanSchedules",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TrapFanSchedules",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TrapFanSchedules",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TrapFanSchedules",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TrapFanSchedules",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TrapFanSchedules",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TrapFanSchedules",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TrapFanSchedules",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TrapFanSchedules",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TrapFanSchedules",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TrapFanSchedules",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "TrapFanSchedules",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "TrapFanSchedules",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "TrapValveQutSchedules",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TrapValveQutSchedules",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TrapValveQutSchedules",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TrapValveQutSchedules",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TrapValveQutSchedules",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TrapValveQutSchedules",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TrapValveQutSchedules",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TrapValveQutSchedules",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TrapValveQutSchedules",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "TrapValveQutSchedules",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "UserTraps",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserTraps",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserTraps",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserTraps",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserTraps",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserTraps",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserTraps",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserTraps",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserTraps",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UserTraps",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "TrapReads",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Traps",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Traps",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Traps",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Traps",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Traps",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Traps",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Traps",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Traps",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Traps",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Traps",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.CreateIndex(
                name: "IX_TrapReads_TrapId_Date",
                table: "TrapReads",
                columns: new[] { "TrapId", "Date" });
        }
    }
}
