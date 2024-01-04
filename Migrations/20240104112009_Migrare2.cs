using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberBooking.Migrations
{
    public partial class Migrare2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Data_Programare",
                table: "Serviciu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data_Programare",
                table: "Serviciu");
        }
    }
}
