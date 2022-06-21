using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantaComprada_TipoPlanta_IdPlanta",
                table: "PlantaComprada");

            migrationBuilder.AlterColumn<string>(
                name: "DescripcionTipo",
                table: "TipoPlanta",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantaComprada_Planta_IdPlanta",
                table: "PlantaComprada",
                column: "IdPlanta",
                principalTable: "Planta",
                principalColumn: "IdPlanta",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantaComprada_Planta_IdPlanta",
                table: "PlantaComprada");

            migrationBuilder.AlterColumn<string>(
                name: "DescripcionTipo",
                table: "TipoPlanta",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantaComprada_TipoPlanta_IdPlanta",
                table: "PlantaComprada",
                column: "IdPlanta",
                principalTable: "TipoPlanta",
                principalColumn: "IdTipoPlanta",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
