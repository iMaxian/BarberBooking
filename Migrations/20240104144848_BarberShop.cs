using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberBooking.Migrations
{
    public partial class BarberShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BarberShopID",
                table: "Serviciu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BarberShop",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrTelefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rateing = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarberShop", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_BarberShopID",
                table: "Serviciu",
                column: "BarberShopID");

            migrationBuilder.AddForeignKey(
                name: "FK_Serviciu_BarberShop_BarberShopID",
                table: "Serviciu",
                column: "BarberShopID",
                principalTable: "BarberShop",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Serviciu_BarberShop_BarberShopID",
                table: "Serviciu");

            migrationBuilder.DropTable(
                name: "BarberShop");

            migrationBuilder.DropIndex(
                name: "IX_Serviciu_BarberShopID",
                table: "Serviciu");

            migrationBuilder.DropColumn(
                name: "BarberShopID",
                table: "Serviciu");
        }
    }
}
