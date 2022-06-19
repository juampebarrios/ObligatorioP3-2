using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichaCuidado_TipoPlanta_IdPlanta",
                table: "FichaCuidado");

            migrationBuilder.AddForeignKey(
                name: "FK_FichaCuidado_Planta_IdPlanta",
                table: "FichaCuidado",
                column: "IdPlanta",
                principalTable: "Planta",
                principalColumn: "IdPlanta",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichaCuidado_Planta_IdPlanta",
                table: "FichaCuidado");

            migrationBuilder.AddForeignKey(
                name: "FK_FichaCuidado_TipoPlanta_IdPlanta",
                table: "FichaCuidado",
                column: "IdPlanta",
                principalTable: "TipoPlanta",
                principalColumn: "IdTipoPlanta",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
