using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantaComprada_Compra_CompraIdCompra",
                table: "PlantaComprada");

            migrationBuilder.DropIndex(
                name: "IX_PlantaComprada_CompraIdCompra",
                table: "PlantaComprada");

            migrationBuilder.DropColumn(
                name: "CompraIdCompra",
                table: "PlantaComprada");

            migrationBuilder.AddColumn<int>(
                name: "miCompraIdCompra",
                table: "PlantaComprada",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantaComprada_miCompraIdCompra",
                table: "PlantaComprada",
                column: "miCompraIdCompra");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantaComprada_Compra_miCompraIdCompra",
                table: "PlantaComprada",
                column: "miCompraIdCompra",
                principalTable: "Compra",
                principalColumn: "IdCompra",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantaComprada_Compra_miCompraIdCompra",
                table: "PlantaComprada");

            migrationBuilder.DropIndex(
                name: "IX_PlantaComprada_miCompraIdCompra",
                table: "PlantaComprada");

            migrationBuilder.DropColumn(
                name: "miCompraIdCompra",
                table: "PlantaComprada");

            migrationBuilder.AddColumn<int>(
                name: "CompraIdCompra",
                table: "PlantaComprada",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantaComprada_CompraIdCompra",
                table: "PlantaComprada",
                column: "CompraIdCompra");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantaComprada_Compra_CompraIdCompra",
                table: "PlantaComprada",
                column: "CompraIdCompra",
                principalTable: "Compra",
                principalColumn: "IdCompra",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
