using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idCompra",
                table: "PlantaComprada");

            migrationBuilder.DropColumn(
                name: "idPlanta",
                table: "PlantaComprada");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idCompra",
                table: "PlantaComprada",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idPlanta",
                table: "PlantaComprada",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
