using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_PlantaComprada_Compra_miCompraIdCompra",
                table: "PlantaComprada");

            migrationBuilder.DropIndex(
                name: "IX_PlantaComprada_UnaPlantaIdPlanta",
                table: "PlantaComprada");

            migrationBuilder.DropIndex(
                name: "IX_PlantaComprada_miCompraIdCompra",
                table: "PlantaComprada");

            migrationBuilder.DropIndex(
                name: "IX_Planta_MiTipoPlantaIdTipoPlanta",
                table: "Planta");

            migrationBuilder.DropIndex(
                name: "IX_FichaCuidado_miPlantaIdPlanta",
                table: "FichaCuidado");

            migrationBuilder.DropColumn(
                name: "UnaPlantaIdPlanta",
                table: "PlantaComprada");

            migrationBuilder.DropColumn(
                name: "miCompraIdCompra",
                table: "PlantaComprada");

            migrationBuilder.DropColumn(
                name: "MiTipoPlantaIdTipoPlanta",
                table: "Planta");

            migrationBuilder.DropColumn(
                name: "miPlantaIdPlanta",
                table: "FichaCuidado");

            migrationBuilder.RenameColumn(
                name: "idTipoPlanta",
                table: "Planta",
                newName: "IdTipoPlanta");

            migrationBuilder.RenameColumn(
                name: "idPlanta",
                table: "FichaCuidado",
                newName: "IdPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_PlantaComprada_IdCompra",
                table: "PlantaComprada",
                column: "IdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_PlantaComprada_IdPlanta",
                table: "PlantaComprada",
                column: "IdPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_Planta_IdTipoPlanta",
                table: "Planta",
                column: "IdTipoPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_FichaCuidado_IdPlanta",
                table: "FichaCuidado",
                column: "IdPlanta");

            migrationBuilder.AddForeignKey(
                name: "FK_FichaCuidado_TipoPlanta_IdPlanta",
                table: "FichaCuidado",
                column: "IdPlanta",
                principalTable: "TipoPlanta",
                principalColumn: "IdTipoPlanta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Planta_TipoPlanta_IdTipoPlanta",
                table: "Planta",
                column: "IdTipoPlanta",
                principalTable: "TipoPlanta",
                principalColumn: "IdTipoPlanta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantaComprada_Compra_IdCompra",
                table: "PlantaComprada",
                column: "IdCompra",
                principalTable: "Compra",
                principalColumn: "IdCompra",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantaComprada_TipoPlanta_IdPlanta",
                table: "PlantaComprada",
                column: "IdPlanta",
                principalTable: "TipoPlanta",
                principalColumn: "IdTipoPlanta",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichaCuidado_TipoPlanta_IdPlanta",
                table: "FichaCuidado");

            migrationBuilder.DropForeignKey(
                name: "FK_Planta_TipoPlanta_IdTipoPlanta",
                table: "Planta");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantaComprada_Compra_IdCompra",
                table: "PlantaComprada");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantaComprada_TipoPlanta_IdPlanta",
                table: "PlantaComprada");

            migrationBuilder.DropIndex(
                name: "IX_PlantaComprada_IdCompra",
                table: "PlantaComprada");

            migrationBuilder.DropIndex(
                name: "IX_PlantaComprada_IdPlanta",
                table: "PlantaComprada");

            migrationBuilder.DropIndex(
                name: "IX_Planta_IdTipoPlanta",
                table: "Planta");

            migrationBuilder.DropIndex(
                name: "IX_FichaCuidado_IdPlanta",
                table: "FichaCuidado");

            migrationBuilder.RenameColumn(
                name: "IdTipoPlanta",
                table: "Planta",
                newName: "idTipoPlanta");

            migrationBuilder.RenameColumn(
                name: "IdPlanta",
                table: "FichaCuidado",
                newName: "idPlanta");

            migrationBuilder.AddColumn<int>(
                name: "UnaPlantaIdPlanta",
                table: "PlantaComprada",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "miCompraIdCompra",
                table: "PlantaComprada",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MiTipoPlantaIdTipoPlanta",
                table: "Planta",
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
                name: "IX_PlantaComprada_miCompraIdCompra",
                table: "PlantaComprada",
                column: "miCompraIdCompra");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PlantaComprada_Compra_miCompraIdCompra",
                table: "PlantaComprada",
                column: "miCompraIdCompra",
                principalTable: "Compra",
                principalColumn: "IdCompra",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
