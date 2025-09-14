using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class trapReadIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrapReads_TrapId",
                table: "TrapReads");

            migrationBuilder.CreateIndex(
                name: "IX_TrapReads_TrapId_Date",
                table: "TrapReads",
                columns: new[] { "TrapId", "Date" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrapReads_TrapId_Date",
                table: "TrapReads");

            migrationBuilder.CreateIndex(
                name: "IX_TrapReads_TrapId",
                table: "TrapReads",
                column: "TrapId");
        }
    }
}
