using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConvertReadDetailsToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Traps_States_CountryId",
                table: "Traps");

            // Convert string data to numeric format before changing column types
            migrationBuilder.Sql(@"
                -- Convert ReadingSmall: Extract numeric part or set to 0
                UPDATE ReadDetails 
                SET ReadingSmall = CASE 
                    WHEN ReadingSmall LIKE 'Small_%' THEN 
                        CASE 
                            WHEN ISNUMERIC(SUBSTRING(ReadingSmall, 7, LEN(ReadingSmall))) = 1 
                            THEN CAST(SUBSTRING(ReadingSmall, 7, LEN(ReadingSmall)) AS VARCHAR)
                            ELSE '0' 
                        END
                    WHEN ISNUMERIC(ReadingSmall) = 1 THEN ReadingSmall
                    ELSE '0'
                END;
            ");

            migrationBuilder.Sql(@"
                -- Convert ReadingLarg: Extract numeric part or set to 0  
                UPDATE ReadDetails 
                SET ReadingLarg = CASE 
                    WHEN ReadingLarg LIKE 'Large_%' THEN 
                        CASE 
                            WHEN ISNUMERIC(SUBSTRING(ReadingLarg, 7, LEN(ReadingLarg))) = 1 
                            THEN CAST(SUBSTRING(ReadingLarg, 7, LEN(ReadingLarg)) AS VARCHAR)
                            ELSE '0' 
                        END
                    WHEN ISNUMERIC(ReadingLarg) = 1 THEN ReadingLarg
                    ELSE '0'
                END;
            ");

            migrationBuilder.Sql(@"
                -- Convert ReadingMosuqitoes: Extract numeric part or set to 0
                UPDATE ReadDetails 
                SET ReadingMosuqitoes = CASE 
                    WHEN ReadingMosuqitoes LIKE 'Mosquito_%' THEN 
                        CASE 
                            WHEN ISNUMERIC(SUBSTRING(ReadingMosuqitoes, 10, LEN(ReadingMosuqitoes))) = 1 
                            THEN CAST(SUBSTRING(ReadingMosuqitoes, 10, LEN(ReadingMosuqitoes)) AS VARCHAR)
                            ELSE '0' 
                        END
                    WHEN ISNUMERIC(ReadingMosuqitoes) = 1 THEN ReadingMosuqitoes
                    ELSE '0'
                END;
            ");

            migrationBuilder.Sql(@"
                -- Convert ReadingFly: Extract numeric part or set to 0
                UPDATE ReadDetails 
                SET ReadingFly = CASE 
                    WHEN ReadingFly LIKE 'Fly_%' THEN 
                        CASE 
                            WHEN ISNUMERIC(SUBSTRING(ReadingFly, 5, LEN(ReadingFly))) = 1 
                            THEN CAST(SUBSTRING(ReadingFly, 5, LEN(ReadingFly)) AS VARCHAR)
                            ELSE '0' 
                        END
                    WHEN ISNUMERIC(ReadingFly) = 1 THEN ReadingFly
                    ELSE '0'
                END;
            ");

            migrationBuilder.AlterColumn<int>(
                name: "ReadingSmall",
                table: "ReadDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ReadingMosuqitoes",
                table: "ReadDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ReadingLarg",
                table: "ReadDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ReadingFly",
                table: "ReadDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 213,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 214,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 215,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 216,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 217,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 221,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 222,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 223,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 224,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 225,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 226,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 227,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 228,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 229,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 230,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 231,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 260,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 261,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 267,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 268,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 269,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 270,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 271,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 272,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 273,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 274,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 275,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 276,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 277,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 278,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 279,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 280,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 281,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 282,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 283,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 284,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 285,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 286,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 287,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 288,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 289,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 290,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 291,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 292,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 293,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 294,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 300,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 301,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 302,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 303,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 304,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 305,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 306,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 307,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 308,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 309,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 310,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 311,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 312,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 313,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 314,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 315,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 316,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 317,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 318,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 319,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 320,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 321,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 322,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 323,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 324,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 325,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 326,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 327,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 328,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 329,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 330,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 331,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 332,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 333,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 334,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 335,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 336,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 337,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 338,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 339,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 340,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 341,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 342,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 343,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 344,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 345,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 346,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 347,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 348,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 349,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 350,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 351,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 352,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 353,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 354,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 355,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 356,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 357,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 358,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 359,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 360,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 361,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 362,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 363,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 364,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 365,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 366,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 367,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 368,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 369,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 370,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 371,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 372,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 373,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 374,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 375,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 376,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 377,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 378,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 379,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 380,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 381,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 382,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 383,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 384,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 385,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 386,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 387,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 388,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 389,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 390,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 391,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 392,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 393,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 394,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 395,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 396,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 397,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 398,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 399,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 400,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 401,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 402,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 403,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 404,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 405,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 406,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 407,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 408,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 409,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 410,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 411,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 412,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 413,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 414,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 415,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 416,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 417,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 418,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 419,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 420,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 421,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 422,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 423,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 424,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 425,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 426,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 427,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 428,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 429,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 430,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 431,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 432,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 433,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 434,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 435,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 436,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 437,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 438,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 439,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 440,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 441,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 442,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 443,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 444,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 445,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 446,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 447,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 448,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 449,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 450,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 451,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 452,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 453,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 454,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 455,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 456,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 457,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 458,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 459,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 460,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 461,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 462,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 463,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 464,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 465,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 466,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 467,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 468,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 469,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 470,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 471,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 472,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 473,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 474,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 475,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 476,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 477,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 478,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 479,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 480,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 481,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 482,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 483,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 484,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 485,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 486,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 487,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 488,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 489,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 490,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 491,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 492,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 493,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 494,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 495,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 496,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 497,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 498,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 499,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 500,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 501,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 502,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 503,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 504,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 505,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 506,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 507,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 508,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 509,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 510,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 511,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 512,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 513,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 514,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 515,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 516,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 517,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 518,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 519,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 520,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 521,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 522,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 523,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 524,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 525,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 526,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 527,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 528,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 529,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 530,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 531,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 532,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 533,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 534,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 535,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 536,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 537,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 538,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 539,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 540,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 541,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 542,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 543,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 544,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 545,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 546,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 547,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 548,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 549,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 550,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 551,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 552,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 553,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 554,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 555,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 556,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 557,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 558,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 559,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 560,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 561,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 562,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 563,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 564,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 565,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 566,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 567,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 568,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 569,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 570,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 571,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 572,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 573,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 574,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 575,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 576,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 577,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 578,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 579,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 580,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 581,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 582,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 583,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 584,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 585,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 586,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 587,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 588,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 589,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 590,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 591,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 592,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 593,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 594,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 595,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 596,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 597,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 598,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 599,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 600,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 601,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 602,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 603,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 604,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 605,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 606,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 607,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 608,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 609,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 610,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 611,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 612,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 613,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 614,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 615,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 616,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 617,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 618,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 619,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 620,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 621,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 622,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 623,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 624,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 625,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 626,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 627,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 628,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 629,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 630,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 631,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 632,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 633,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 634,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 635,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 636,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 637,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 638,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 639,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 640,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 641,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 642,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 643,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 644,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 645,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 646,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 647,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 648,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 649,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 650,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 651,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 652,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 653,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 654,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 655,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 656,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 657,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 658,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 659,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 660,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 661,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 662,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 663,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 664,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 665,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 666,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 667,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 668,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 669,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 670,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 671,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 672,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 673,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 674,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 675,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 676,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 677,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 678,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 679,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 680,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 681,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 682,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 683,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 684,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 685,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 686,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 687,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 688,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 689,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 690,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 691,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 692,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 693,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 694,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 695,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 696,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 697,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 698,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 699,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 700,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 701,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 702,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 703,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 704,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 705,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 706,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 707,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 708,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 709,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 710,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 711,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 712,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 713,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 714,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 715,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 716,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 717,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 718,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 719,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 720,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 721,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 722,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 723,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 724,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 725,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 726,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 727,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 728,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 729,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 730,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 731,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 732,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 733,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 734,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 735,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 736,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 737,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 738,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 739,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 740,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 741,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 742,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 743,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 744,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 745,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 746,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 747,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 748,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 749,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 750,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 751,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 752,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 753,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 754,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 755,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 756,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 757,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 758,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 759,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 760,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 761,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 762,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 763,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 764,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 765,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 766,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 767,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 768,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 769,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 770,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 771,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 772,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 773,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 774,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 775,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 776,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 777,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 778,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 779,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 780,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 781,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 782,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 783,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 784,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 785,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 786,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 787,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 788,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 789,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 790,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 791,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 792,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 793,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 794,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 795,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 796,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 797,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 798,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 799,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 800,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 801,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 802,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 803,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 804,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 805,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 806,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 807,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 808,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 809,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 810,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 811,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 812,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 813,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 814,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 815,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 816,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 22, 19, 68, 31 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 817,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 19, 10, 51, 22 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 818,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 26, 16, 79, 38 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 819,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 14, 13, 42, 26 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 820,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 21, 20, 63, 33 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 821,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 18, 12, 55, 25 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 822,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 25, 18, 72, 35 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 823,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 12, 8, 38, 18 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 824,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 28, 22, 84, 42 });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 825,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { 15, 15, 46, 28 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "ConcurrencyStamp",
                value: "f1c4bbf5-c540-454a-8bde-d0d456fd79e6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "ConcurrencyStamp",
                value: "69a67845-873f-4af0-a065-c718ea11898a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "ConcurrencyStamp",
                value: "0469e3be-71b2-4cf2-9a8c-d47dfae66a2b");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "ConcurrencyStamp",
                value: "99964320-b38d-4155-8031-93e7ff90afe9");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "ConcurrencyStamp",
                value: "eb9d65d2-597d-47f4-b7ee-a0eae42da90a");

            migrationBuilder.CreateIndex(
                name: "IX_Traps_StateId",
                table: "Traps",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Traps_States_StateId",
                table: "Traps",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Traps_States_StateId",
                table: "Traps");

            migrationBuilder.DropIndex(
                name: "IX_Traps_StateId",
                table: "Traps");

            migrationBuilder.AlterColumn<string>(
                name: "ReadingSmall",
                table: "ReadDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ReadingMosuqitoes",
                table: "ReadDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ReadingLarg",
                table: "ReadDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ReadingFly",
                table: "ReadDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 213,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 214,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 215,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 216,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 217,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 221,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 222,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 223,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 224,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 225,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 226,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 227,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 228,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 229,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 230,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 231,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 260,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 261,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 267,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 268,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 269,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 270,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 271,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 272,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 273,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 274,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 275,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 276,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 277,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 278,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 279,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 280,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 281,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 282,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 283,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 284,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 285,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 286,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 287,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 288,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 289,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 290,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 291,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 292,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 293,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 294,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 295,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 296,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 297,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 299,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 300,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 301,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 302,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 303,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 304,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 305,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 306,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 307,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 308,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 309,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 310,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 311,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 312,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 313,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 314,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 315,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 316,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 317,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 318,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 319,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 320,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 321,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 322,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 323,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 324,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 325,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 326,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 327,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 328,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 329,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 330,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 331,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 332,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 333,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 334,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 335,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 336,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 337,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 338,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 339,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 340,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 341,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 342,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 343,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 344,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 345,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 346,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 347,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 348,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 349,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 350,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 351,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 352,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 353,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 354,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 355,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 356,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 357,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 358,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 359,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 360,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 361,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 362,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 363,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 364,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 365,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 366,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 367,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 368,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 369,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 370,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 371,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 372,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 373,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 374,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 375,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 376,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 377,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 378,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 379,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 380,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 381,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 382,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 383,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 384,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 385,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 386,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 387,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 388,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 389,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 390,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 391,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 392,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 393,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 394,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 395,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 396,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 397,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 398,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 399,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 400,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 401,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 402,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 403,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 404,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 405,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 406,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 407,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 408,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 409,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 410,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 411,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 412,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 413,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 414,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 415,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 416,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 417,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 418,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 419,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 420,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 421,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 422,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 423,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 424,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 425,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 426,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 427,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 428,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 429,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 430,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 431,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 432,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 433,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 434,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 435,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 436,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 437,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 438,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 439,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 440,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 441,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 442,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 443,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 444,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 445,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 446,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 447,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 448,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 449,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 450,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 451,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 452,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 453,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 454,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 455,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 456,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 457,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 458,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 459,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 460,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 461,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 462,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 463,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 464,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 465,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 466,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 467,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 468,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 469,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 470,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 471,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 472,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 473,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 474,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 475,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 476,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 477,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 478,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 479,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 480,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 481,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 482,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 483,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 484,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 485,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 486,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 487,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 488,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 489,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 490,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 491,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 492,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 493,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 494,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 495,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 496,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 497,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 498,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 499,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 500,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 501,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 502,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 503,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 504,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 505,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 506,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 507,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 508,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 509,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 510,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 511,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 512,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 513,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 514,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 515,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 516,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 517,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 518,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 519,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 520,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 521,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 522,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 523,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 524,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 525,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 526,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 527,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 528,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 529,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 530,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 531,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 532,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 533,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 534,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 535,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 536,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 537,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 538,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 539,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 540,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 541,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 542,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 543,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 544,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 545,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 546,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 547,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 548,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 549,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 550,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 551,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 552,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 553,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 554,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 555,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 556,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 557,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 558,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 559,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 560,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 561,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 562,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 563,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 564,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 565,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 566,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 567,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 568,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 569,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 570,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 571,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 572,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 573,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 574,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 575,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 576,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 577,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 578,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 579,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 580,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 581,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 582,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 583,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 584,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 585,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 586,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 587,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 588,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 589,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 590,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 591,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 592,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 593,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 594,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 595,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 596,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 597,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 598,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 599,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 600,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 601,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 602,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 603,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 604,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 605,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 606,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 607,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 608,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 609,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 610,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 611,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 612,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 613,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 614,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 615,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 616,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 617,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 618,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 619,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 620,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 621,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 622,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 623,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 624,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 625,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 626,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 627,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 628,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 629,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 630,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 631,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 632,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 633,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 634,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 635,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 636,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 637,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 638,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 639,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 640,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 641,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 642,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 643,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 644,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 645,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 646,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 647,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 648,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 649,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 650,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 651,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 652,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 653,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 654,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 655,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 656,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 657,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 658,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 659,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 660,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 661,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 662,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 663,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 664,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 665,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 666,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 667,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 668,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 669,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 670,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 671,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 672,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 673,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 674,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 675,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 676,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 677,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 678,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 679,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 680,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 681,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 682,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 683,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 684,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 685,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 686,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 687,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 688,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 689,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 690,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 691,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 692,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 693,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 694,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 695,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 696,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 697,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 698,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 699,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 700,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 701,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 702,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 703,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 704,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 705,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 706,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 707,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 708,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 709,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 710,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 711,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 712,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 713,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 714,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 715,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 716,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 717,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 718,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 719,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 720,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 721,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 722,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 723,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 724,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 725,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 726,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 727,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 728,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 729,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 730,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 731,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 732,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 733,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 734,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 735,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 736,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 737,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 738,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 739,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 740,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 741,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 742,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 743,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 744,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 745,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 746,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 747,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 748,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 749,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 750,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 751,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 752,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 753,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 754,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 755,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 756,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 757,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 758,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 759,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 760,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 761,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 762,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 763,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 764,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 765,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 766,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 767,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 768,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 769,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 770,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 771,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 772,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 773,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 774,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 775,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 776,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 777,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 778,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 779,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 780,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 781,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 782,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 783,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 784,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 785,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 786,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 787,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 788,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 789,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 790,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 791,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 792,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 793,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 794,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 795,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 796,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 797,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 798,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 799,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 800,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 801,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 802,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 803,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 804,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 805,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 806,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 807,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 808,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 809,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 810,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 811,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 812,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 813,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 814,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 815,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 816,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "22", "19", "68", "31" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 817,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "19", "10", "51", "22" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 818,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "26", "16", "79", "38" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 819,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "14", "13", "42", "26" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 820,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "21", "20", "63", "33" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 821,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "18", "12", "55", "25" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 822,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "25", "18", "72", "35" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 823,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "12", "8", "38", "18" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 824,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "28", "22", "84", "42" });

            migrationBuilder.UpdateData(
                table: "ReadDetails",
                keyColumn: "Id",
                keyValue: 825,
                columns: new[] { "ReadingFly", "ReadingLarg", "ReadingMosuqitoes", "ReadingSmall" },
                values: new object[] { "15", "15", "46", "28" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "ConcurrencyStamp",
                value: "89d9e377-0e16-4bf3-a6c0-020d6a5d36f8");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "ConcurrencyStamp",
                value: "3707eb40-6341-412d-9d54-cf2bf08962a3");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "ConcurrencyStamp",
                value: "29ed7a83-6bbf-4d99-83ac-1cace9f810ad");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "ConcurrencyStamp",
                value: "13cecdf0-cc9a-43ed-8f2a-d8cd3eae2f89");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "ConcurrencyStamp",
                value: "e6099246-c8dd-4d80-a4b7-c5aef9dd7394");

            migrationBuilder.AddForeignKey(
                name: "FK_Traps_States_CountryId",
                table: "Traps",
                column: "CountryId",
                principalTable: "States",
                principalColumn: "Id");
        }
    }
}
