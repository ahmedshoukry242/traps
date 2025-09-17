using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataWithReadDetailsFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ServerCreationDate",
                table: "TrapReads",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TrapReads",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            // Clear existing data to ensure clean seeding
            migrationBuilder.Sql("DELETE FROM ReadDetails");
            migrationBuilder.Sql("DELETE FROM TrapReads");
            migrationBuilder.Sql("DELETE FROM Traps");

            // Insert 10 Traps with IDENTITY_INSERT
            migrationBuilder.Sql("SET IDENTITY_INSERT Traps ON");
            migrationBuilder.Sql(@"
                INSERT INTO Traps (Id, Name, SerialNumber, TrapStatus, ReadingDate, FileDate, Lat, Long, IsCounterOn, IsCounterReadingFromSimCard, IsScheduleOn, IsThereEmergency, IsNew)
                VALUES 
                (1, 'Trap 1', 'SN001', 1, '2024-01-01', '2024-01-01', '40.7128', '-74.0060', 1, 0, 1, 0, 1),
                (2, 'Trap 2', 'SN002', 1, '2024-01-02', '2024-01-02', '40.7589', '-73.9851', 1, 0, 1, 0, 1),
                (3, 'Trap 3', 'SN003', 1, '2024-01-03', '2024-01-03', '40.7505', '-73.9934', 1, 0, 1, 0, 1),
                (4, 'Trap 4', 'SN004', 1, '2024-01-04', '2024-01-04', '40.7282', '-73.7949', 1, 0, 1, 0, 1),
                (5, 'Trap 5', 'SN005', 1, '2024-01-05', '2024-01-05', '40.6892', '-74.0445', 1, 0, 1, 0, 1),
                (6, 'Trap 6', 'SN006', 1, '2024-01-06', '2024-01-06', '40.7831', '-73.9712', 1, 0, 1, 0, 1),
                (7, 'Trap 7', 'SN007', 1, '2024-01-07', '2024-01-07', '40.7484', '-73.9857', 1, 0, 1, 0, 1),
                (8, 'Trap 8', 'SN008', 1, '2024-01-08', '2024-01-08', '40.6782', '-73.9442', 1, 0, 1, 0, 1),
                (9, 'Trap 9', 'SN009', 1, '2024-01-09', '2024-01-09', '40.7794', '-73.9632', 1, 0, 1, 0, 1),
                (10, 'Trap 10', 'SN010', 1, '2024-01-10', '2024-01-10', '40.7549', '-73.9840', 1, 0, 1, 0, 1)
            ");
            migrationBuilder.Sql("SET IDENTITY_INSERT Traps OFF");

            // Insert 150 TrapReads (15 per trap)
            migrationBuilder.Sql("SET IDENTITY_INSERT TrapReads ON");
            migrationBuilder.Sql(@"
                DECLARE @TrapId INT = 1;
                DECLARE @ReadId INT = 1;
                DECLARE @Counter INT = 1;

                WHILE @TrapId <= 10
                BEGIN
                    SET @Counter = 1;
                    WHILE @Counter <= 15
                    BEGIN
                        INSERT INTO TrapReads (Id, TrapId, Date, ServerCreationDate)
                        VALUES (
                            @ReadId,
                            @TrapId,
                            DATEADD(day, @Counter - 1, '2024-01-01'),
                            DATEADD(day, @Counter, '2024-01-01')
                        );
                        
                        SET @ReadId = @ReadId + 1;
                        SET @Counter = @Counter + 1;
                    END
                    SET @TrapId = @TrapId + 1;
                END
            ");
            migrationBuilder.Sql("SET IDENTITY_INSERT TrapReads OFF");

            // Generate ReadDetails for all TrapReads
            migrationBuilder.Sql("SET IDENTITY_INSERT ReadDetails ON");
            migrationBuilder.Sql(@"
                DECLARE @TrapReadId INT = 1;
                DECLARE @DetailId INT = 1;
                DECLARE @DetailCounter INT;

                -- Loop through all 150 TrapReads
                WHILE @TrapReadId <= 150
                BEGIN
                    SET @DetailCounter = 1;
                    -- Generate 5-8 ReadDetails per TrapRead
                    DECLARE @NumDetails INT = 5 + (@TrapReadId % 4); -- This gives us 5-8 details per read
                    
                    WHILE @DetailCounter <= @NumDetails
                    BEGIN
                        INSERT INTO ReadDetails (Id, TrapReadId, Time, SerialNumber, ReadingLat, ReadingLng, Counter, Fan, Co2, Co2Val, ReadingSmall, ReadingLarg, ReadingMosuqitoes, ReadingTempIn, ReadingTempOut, ReadingWindSpeed, ReadingHumidty, ReadingFly, BigBattery, SmallBattery, IsDone, IsClean)
                        VALUES (
                            @DetailId,
                            @TrapReadId,
                            CAST(DATEADD(minute, @DetailCounter * 10, '08:00:00') AS TIME),
                            'SN' + RIGHT('000' + CAST(@TrapReadId AS VARCHAR), 3) + '_' + CAST(@DetailCounter AS VARCHAR),
                            '40.7128',
                            '-74.0060',
                            @DetailCounter * 10,
                            @DetailCounter % 3,
                            @DetailCounter * 5,
                            'CO2_' + CAST(@DetailCounter AS VARCHAR),
                            'Small_' + CAST(@DetailCounter AS VARCHAR),
                            'Large_' + CAST(@DetailCounter AS VARCHAR),
                            'Mosquitoes_' + CAST(@DetailCounter AS VARCHAR),
                            'TempIn_' + CAST(@DetailCounter AS VARCHAR),
                            'TempOut_' + CAST(@DetailCounter AS VARCHAR),
                            'WindSpeed_' + CAST(@DetailCounter AS VARCHAR),
                            'Humidity_' + CAST(@DetailCounter AS VARCHAR),
                            'Fly_' + CAST(@DetailCounter AS VARCHAR),
                            'BigBat_' + CAST(@DetailCounter AS VARCHAR),
                            'SmallBat_' + CAST(@DetailCounter AS VARCHAR),
                            CASE WHEN @DetailCounter % 2 = 0 THEN 1 ELSE 0 END,
                            CASE WHEN @DetailCounter % 3 = 0 THEN 1 ELSE 0 END
                        );
                        
                        SET @DetailId = @DetailId + 1;
                        SET @DetailCounter = @DetailCounter + 1;
                    END
                    
                    SET @TrapReadId = @TrapReadId + 1;
                END
            ");
            migrationBuilder.Sql("SET IDENTITY_INSERT ReadDetails OFF");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "ConcurrencyStamp",
                value: "c8554266-b7bb-4f44-9aac-0cbaa7b4e92a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "ConcurrencyStamp",
                value: "c8554266-b7bb-4f44-9aac-0cbaa7b4e92a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "ConcurrencyStamp",
                value: "c8554266-b7bb-4f44-9aac-0cbaa7b4e92a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "ConcurrencyStamp",
                value: "c8554266-b7bb-4f44-9aac-0cbaa7b4e92a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "ConcurrencyStamp",
                value: "c8554266-b7bb-4f44-9aac-0cbaa7b4e92a");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "ServerCreationDate",
                table: "TrapReads",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "TrapReads",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            // Clean up seeded data
            migrationBuilder.Sql("DELETE FROM ReadDetails");
            migrationBuilder.Sql("DELETE FROM TrapReads");
            migrationBuilder.Sql("DELETE FROM Traps WHERE Id BETWEEN 1 AND 10");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c8554266-b7bb-4f44-9aac-0cbaa7b4e92a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "c8554266-b7bb-4f44-9aac-0cbaa7b4e92a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "c8554266-b7bb-4f44-9aac-0cbaa7b4e92a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "c8554266-b7bb-4f44-9aac-0cbaa7b4e92a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "c8554266-b7bb-4f44-9aac-0cbaa7b4e92a");
        }
    }
}
