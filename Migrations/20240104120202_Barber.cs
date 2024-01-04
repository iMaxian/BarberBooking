using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberBooking.Migrations
{
    public partial class Barber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BarberID",
                table: "Serviciu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Barber",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Rateing = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barber", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Serviciu_BarberID",
                table: "Serviciu",
                column: "BarberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Serviciu_Barber_BarberID",
                table: "Serviciu",
                column: "BarberID",
                principalTable: "Barber",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Serviciu_Barber_BarberID",
                table: "Serviciu");

            migrationBuilder.DropTable(
                name: "Barber");

            migrationBuilder.DropIndex(
                name: "IX_Serviciu_BarberID",
                table: "Serviciu");

            migrationBuilder.DropColumn(
                name: "BarberID",
                table: "Serviciu");
        }
    }
}
