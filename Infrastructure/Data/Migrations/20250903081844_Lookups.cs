using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Lookups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeZoneName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtcOffsetMinutes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "None" },
                    { 2, "Afaq" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "TimeZoneName", "UtcOffsetMinutes" },
                values: new object[,]
                {
                    { 1, "Egypt", "Africa/Cairo", 120 },
                    { 2, "Saudi Arabia", "Asia/Riyadh", 180 },
                    { 3, "United Arab Emirates", "Asia/Dubai", 240 },
                    { 4, "Qatar", "Asia/Qatar", 180 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Cairo" },
                    { 2, 1, "Alexandria" },
                    { 3, 1, "Giza" },
                    { 4, 1, "Damietta" },
                    { 5, 1, "Port Said" },
                    { 6, 1, "Suez" },
                    { 7, 1, "Aswan" },
                    { 8, 1, "Luxor" },
                    { 9, 1, "Qena" },
                    { 10, 1, "Sohag" },
                    { 11, 1, "Ismailia" },
                    { 12, 1, "Menofia" },
                    { 13, 1, "Qalyubia" },
                    { 14, 1, "Sharqia" },
                    { 15, 1, "Beheira" },
                    { 16, 1, "Fayoum" },
                    { 17, 1, "Minya" },
                    { 18, 1, "Asyut" },
                    { 19, 1, "Dakahlia" },
                    { 20, 1, "Matruh" },
                    { 21, 1, "Beni Suef" },
                    { 22, 1, "Red Sea" },
                    { 23, 1, "North Sinai" },
                    { 24, 1, "South Sinai" },
                    { 26, 2, "Riyadh" },
                    { 27, 2, "Jeddah" },
                    { 28, 2, "Mecca" },
                    { 29, 2, "Medina" },
                    { 30, 2, "Dammam" },
                    { 31, 2, "Khobar" },
                    { 32, 2, "Tabuk" },
                    { 33, 2, "Hail" },
                    { 34, 2, "Qassim" },
                    { 35, 2, "Najran" },
                    { 36, 2, "Jizan" },
                    { 37, 2, "Asir" },
                    { 38, 2, "Al Bahah" },
                    { 39, 2, "Northern Borders" },
                    { 40, 2, "Jouf" },
                    { 41, 3, "Dubai" },
                    { 42, 3, "Abu Dhabi" },
                    { 43, 3, "Sharjah" },
                    { 44, 3, "Ajman" },
                    { 45, 3, "Umm Al-Quwain" },
                    { 46, 3, "Fujairah" },
                    { 47, 3, "Ras Al Khaimah" },
                    { 48, 4, "Doha" },
                    { 49, 4, "Al Wakrah" },
                    { 50, 4, "Al Khor" },
                    { 51, 4, "Mesaieed" },
                    { 52, 4, "Al Rayyan" },
                    { 53, 4, "Al Daayen" },
                    { 54, 4, "Umm Salal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Traps_CategoryId",
                table: "Traps",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Traps_CountryId",
                table: "Traps",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Traps_Categories_CategoryId",
                table: "Traps",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Traps_Countries_CountryId",
                table: "Traps",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Traps_States_CountryId",
                table: "Traps",
                column: "CountryId",
                principalTable: "States",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Traps_Categories_CategoryId",
                table: "Traps");

            migrationBuilder.DropForeignKey(
                name: "FK_Traps_Countries_CountryId",
                table: "Traps");

            migrationBuilder.DropForeignKey(
                name: "FK_Traps_States_CountryId",
                table: "Traps");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Traps_CategoryId",
                table: "Traps");

            migrationBuilder.DropIndex(
                name: "IX_Traps_CountryId",
                table: "Traps");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");
        }
    }
}
