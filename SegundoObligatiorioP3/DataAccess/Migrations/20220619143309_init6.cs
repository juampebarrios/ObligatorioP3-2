using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planta_TipoPlanta_MiTipoPlantaIdTipoPlanta",
                table: "Planta");

            migrationBuilder.DropIndex(
                name: "IX_Planta_MiTipoPlantaIdTipoPlanta",
                table: "Planta");

            migrationBuilder.DropColumn(
                name: "MiTipoPlantaIdTipoPlanta",
                table: "Planta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MiTipoPlantaIdTipoPlanta",
                table: "Planta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Planta_MiTipoPlantaIdTipoPlanta",
                table: "Planta",
                column: "MiTipoPlantaIdTipoPlanta");

            migrationBuilder.AddForeignKey(
                name: "FK_Planta_TipoPlanta_MiTipoPlantaIdTipoPlanta",
                table: "Planta",
                column: "MiTipoPlantaIdTipoPlanta",
                principalTable: "TipoPlanta",
                principalColumn: "IdTipoPlanta",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
