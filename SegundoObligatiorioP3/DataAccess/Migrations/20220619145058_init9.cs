using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCompra",
                table: "PlantaComprada",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPlanta",
                table: "PlantaComprada",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnaPlantaIdPlanta",
                table: "PlantaComprada",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MiTipoPlantaIdTipoPlanta",
                table: "Planta",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idTipoPlanta",
                table: "Planta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "miPlantaIdPlanta",
                table: "FichaCuidado",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantaComprada_UnaPlantaIdPlanta",
                table: "PlantaComprada",
                column: "UnaPlantaIdPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_Planta_MiTipoPlantaIdTipoPlanta",
                table: "Planta",
                column: "MiTipoPlantaIdTipoPlanta");

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
                name: "FK_Planta_TipoPlanta_MiTipoPlantaIdTipoPlanta",
                table: "Planta",
                column: "MiTipoPlantaIdTipoPlanta",
                principalTable: "TipoPlanta",
                principalColumn: "IdTipoPlanta",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantaComprada_Planta_UnaPlantaIdPlanta",
                table: "PlantaComprada",
                column: "UnaPlantaIdPlanta",
                principalTable: "Planta",
                principalColumn: "IdPlanta",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichaCuidado_Planta_miPlantaIdPlanta",
                table: "FichaCuidado");

            migrationBuilder.DropForeignKey(
                name: "FK_Planta_TipoPlanta_MiTipoPlantaIdTipoPlanta",
                table: "Planta");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantaComprada_Planta_UnaPlantaIdPlanta",
                table: "PlantaComprada");

            migrationBuilder.DropIndex(
                name: "IX_PlantaComprada_UnaPlantaIdPlanta",
                table: "PlantaComprada");

            migrationBuilder.DropIndex(
                name: "IX_Planta_MiTipoPlantaIdTipoPlanta",
                table: "Planta");

            migrationBuilder.DropIndex(
                name: "IX_FichaCuidado_miPlantaIdPlanta",
                table: "FichaCuidado");

            migrationBuilder.DropColumn(
                name: "IdCompra",
                table: "PlantaComprada");

            migrationBuilder.DropColumn(
                name: "IdPlanta",
                table: "PlantaComprada");

            migrationBuilder.DropColumn(
                name: "UnaPlantaIdPlanta",
                table: "PlantaComprada");

            migrationBuilder.DropColumn(
                name: "MiTipoPlantaIdTipoPlanta",
                table: "Planta");

            migrationBuilder.DropColumn(
                name: "idTipoPlanta",
                table: "Planta");

            migrationBuilder.DropColumn(
                name: "miPlantaIdPlanta",
                table: "FichaCuidado");
        }
    }
}
