using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PantallaOne.Migrations
{
    public partial class Secundaria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Direccion",
                table: "Clientes",
                newName: "Ciudad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ciudad",
                table: "Clientes",
                newName: "Direccion");
        }
    }
}
