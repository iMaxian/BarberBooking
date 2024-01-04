using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberBooking.Migrations
{
    public partial class ServiciuStil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stil",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireStil = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stil", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ServiciuStil",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiciuID = table.Column<int>(type: "int", nullable: false),
                    StilID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciuStil", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServiciuStil_Serviciu_ServiciuID",
                        column: x => x.ServiciuID,
                        principalTable: "Serviciu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiciuStil_Stil_StilID",
                        column: x => x.StilID,
                        principalTable: "Stil",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiciuStil_ServiciuID",
                table: "ServiciuStil",
                column: "ServiciuID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciuStil_StilID",
                table: "ServiciuStil",
                column: "StilID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiciuStil");

            migrationBuilder.DropTable(
                name: "Stil");
        }
    }
}
