﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init : Migration
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
                name: "TipoPlanta",
                columns: table => new
                {
                    IdTipoPlanta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUnico = table.Column<string>(nullable: false),
                    DescripcionTipo = table.Column<string>(nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Planta",
                columns: table => new
                {
                    IdPlanta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCientifico = table.Column<string>(nullable: false),
                    NombreVulgar = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    Ambiente = table.Column<string>(nullable: false),
                    AlturaMax = table.Column<double>(nullable: false),
                    Foto = table.Column<string>(nullable: false),
                    Precio = table.Column<double>(nullable: false),
                    idTipoPlanta = table.Column<int>(nullable: false),
                    MiTipoPlantaIdTipoPlanta = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planta", x => x.IdPlanta);
                    table.ForeignKey(
                        name: "FK_Planta_TipoPlanta_MiTipoPlantaIdTipoPlanta",
                        column: x => x.MiTipoPlantaIdTipoPlanta,
                        principalTable: "TipoPlanta",
                        principalColumn: "IdTipoPlanta",
                        onDelete: ReferentialAction.Restrict);
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
                    idPlanta = table.Column<int>(nullable: false),
                    miPlantaIdPlanta = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaCuidado", x => x.IdFicha);
                    table.ForeignKey(
                        name: "FK_FichaCuidado_Planta_miPlantaIdPlanta",
                        column: x => x.miPlantaIdPlanta,
                        principalTable: "Planta",
                        principalColumn: "IdPlanta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlantaComprada",
                columns: table => new
                {
                    IdPlantaComprada = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(nullable: false),
                    PrecioUnitario = table.Column<double>(nullable: false),
                    idCompra = table.Column<int>(nullable: false),
                    idPlanta = table.Column<int>(nullable: false),
                    UnaPlantaIdPlanta = table.Column<int>(nullable: true),
                    CompraIdCompra = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantaComprada", x => x.IdPlantaComprada);
                    table.ForeignKey(
                        name: "FK_PlantaComprada_Compra_CompraIdCompra",
                        column: x => x.CompraIdCompra,
                        principalTable: "Compra",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantaComprada_Planta_UnaPlantaIdPlanta",
                        column: x => x.UnaPlantaIdPlanta,
                        principalTable: "Planta",
                        principalColumn: "IdPlanta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FichaCuidado_miPlantaIdPlanta",
                table: "FichaCuidado",
                column: "miPlantaIdPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_Planta_MiTipoPlantaIdTipoPlanta",
                table: "Planta",
                column: "MiTipoPlantaIdTipoPlanta");

            migrationBuilder.CreateIndex(
                name: "IX_PlantaComprada_CompraIdCompra",
                table: "PlantaComprada",
                column: "CompraIdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_PlantaComprada_UnaPlantaIdPlanta",
                table: "PlantaComprada",
                column: "UnaPlantaIdPlanta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FichaCuidado");

            migrationBuilder.DropTable(
                name: "PlantaComprada");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Planta");

            migrationBuilder.DropTable(
                name: "TipoPlanta");
        }
    }
}