using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class dataTypesChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrapReads_TrapId_Date",
                table: "TrapReads");

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

            migrationBuilder.CreateIndex(
                name: "IX_TrapReads_TrapId_Date",
                table: "TrapReads",
                columns: new[] { "TrapId", "Date" });
        }
    }
}
