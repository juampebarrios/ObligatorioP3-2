using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichaCuidado_Planta_miPlantaIdPlanta",
                table: "FichaCuidado");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantaComprada_Planta_UnaPlantaIdPlanta",
                table: "PlantaComprada");

            migrationBuilder.DropIndex(
                name: "IX_PlantaComprada_UnaPlantaIdPlanta",
                table: "PlantaComprada");

            migrationBuilder.DropIndex(
                name: "IX_FichaCuidado_miPlantaIdPlanta",
                table: "FichaCuidado");

            migrationBuilder.DropColumn(
                name: "UnaPlantaIdPlanta",
                table: "PlantaComprada");

            migrationBuilder.DropColumn(
                name: "miPlantaIdPlanta",
                table: "FichaCuidado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnaPlantaIdPlanta",
                table: "PlantaComprada",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "miPlantaIdPlanta",
                table: "FichaCuidado",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantaComprada_UnaPlantaIdPlanta",
                table: "PlantaComprada",
                column: "UnaPlantaIdPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_FichaCuidado_miPlantaIdPlanta",
                table: "FichaCuidado",
                column: "miPlantaIdPlanta");

            migrationBuilder.AddForeignKey(
                name: "FK_FichaCuidado_Planta_miPlantaIdPlanta",
                table: "FichaCuidado",
                column: "miPlantaIdPlanta",
                principalTable: "Planta",
                principalColumn: "IdPlanta",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantaComprada_Planta_UnaPlantaIdPlanta",
                table: "PlantaComprada",
                column: "UnaPlantaIdPlanta",
                principalTable: "Planta",
                principalColumn: "IdPlanta",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
