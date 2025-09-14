using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class TrapSchedules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrapCounterSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScdTime = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    TrapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrapCounterSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrapCounterSchedules_Traps_TrapId",
                        column: x => x.TrapId,
                        principalTable: "Traps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrapFanSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScdTime = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    TrapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrapFanSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrapFanSchedules_Traps_TrapId",
                        column: x => x.TrapId,
                        principalTable: "Traps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrapValveQutSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScdTime = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    TrapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrapValveQutSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrapValveQutSchedules_Traps_TrapId",
                        column: x => x.TrapId,
                        principalTable: "Traps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrapCounterSchedules_TrapId",
                table: "TrapCounterSchedules",
                column: "TrapId");

            migrationBuilder.CreateIndex(
                name: "IX_TrapFanSchedules_TrapId",
                table: "TrapFanSchedules",
                column: "TrapId");

            migrationBuilder.CreateIndex(
                name: "IX_TrapValveQutSchedules_TrapId",
                table: "TrapValveQutSchedules",
                column: "TrapId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrapCounterSchedules");

            migrationBuilder.DropTable(
                name: "TrapFanSchedules");

            migrationBuilder.DropTable(
                name: "TrapValveQutSchedules");
        }
    }
}
