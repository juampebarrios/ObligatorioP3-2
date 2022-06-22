using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    IdCompra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCompra = table.Column<DateTime>(nullable: false),
                    PrecioCompra = table.Column<double>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    TasaImpuesto = table.Column<double>(nullable: true),
                    EsAmericaSur = table.Column<bool>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Flete = table.Column<bool>(nullable: true),
                    Iva = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.IdCompra);
                });

            migrationBuilder.CreateTable(
                name: "PlantaComprada",
                columns: table => new
                {
                    IdPlantaComprada = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(nullable: false),
                    PrecioUnitario = table.Column<double>(nullable: false),
                    IdCompra = table.Column<int>(nullable: false),
                    IdPlanta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantaComprada", x => x.IdPlantaComprada);
                });

            migrationBuilder.CreateTable(
                name: "TipoPlanta",
                columns: table => new
                {
                    IdTipoPlanta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUnico = table.Column<string>(nullable: false),
                    DescripcionTipo = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPlanta", x => x.IdTipoPlanta);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.UniqueConstraint("AK_Usuario_Email", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Planta",
                columns: table => new
                {
                    IdPlanta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCientifico = table.Column<string>(nullable: false),
                    NombreVulgar = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 200, nullable: false),
                    Ambiente = table.Column<string>(nullable: false),
                    AlturaMax = table.Column<double>(nullable: false),
                    Foto = table.Column<string>(nullable: false),
                    Precio = table.Column<double>(nullable: false),
                    IdTipoPlanta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planta", x => x.IdPlanta);
                    table.ForeignKey(
                        name: "FK_Planta_TipoPlanta_IdTipoPlanta",
                        column: x => x.IdTipoPlanta,
                        principalTable: "TipoPlanta",
                        principalColumn: "IdTipoPlanta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FichaCuidado",
                columns: table => new
                {
                    IdFicha = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrecuenciaRiego = table.Column<string>(nullable: false),
                    TipoIluminacion = table.Column<string>(nullable: false),
                    Temperatura = table.Column<int>(nullable: false),
                    IdPlanta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaCuidado", x => x.IdFicha);
                    table.ForeignKey(
                        name: "FK_FichaCuidado_Planta_IdPlanta",
                        column: x => x.IdPlanta,
                        principalTable: "Planta",
                        principalColumn: "IdPlanta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FichaCuidado_IdPlanta",
                table: "FichaCuidado",
                column: "IdPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_Planta_IdTipoPlanta",
                table: "Planta",
                column: "IdTipoPlanta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "FichaCuidado");

            migrationBuilder.DropTable(
                name: "PlantaComprada");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Planta");

            migrationBuilder.DropTable(
                name: "TipoPlanta");
        }
    }
}
