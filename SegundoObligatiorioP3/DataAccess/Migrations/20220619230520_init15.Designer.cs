﻿// <auto-generated />
using System;
using DataAccess.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(ViveroContexto))]
    [Migration("20220619230520_init15")]
    partial class init15
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Compra", b =>
                {
                    b.Property<int>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<double>("PrecioCompra")
                        .HasColumnType("float");

                    b.HasKey("IdCompra");

                    b.ToTable("Compra");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Compra");
                });

            modelBuilder.Entity("Dominio.FichaCuidado", b =>
                {
                    b.Property<int>("IdFicha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FrecuenciaRiego")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPlanta")
                        .HasColumnType("int");

                    b.Property<int>("Temperatura")
                        .HasColumnType("int");

                    b.Property<string>("TipoIluminacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFicha");

                    b.HasIndex("IdPlanta");

                    b.ToTable("FichaCuidado");
                });

            modelBuilder.Entity("Dominio.Planta", b =>
                {
                    b.Property<int>("IdPlanta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AlturaMax")
                        .HasColumnType("float");

                    b.Property<string>("Ambiente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdTipoPlanta")
                        .HasColumnType("int");

                    b.Property<string>("NombreCientifico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreVulgar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("IdPlanta");

                    b.HasIndex("IdTipoPlanta");

                    b.ToTable("Planta");
                });

            modelBuilder.Entity("Dominio.PlantaComprada", b =>
                {
                    b.Property<int>("IdPlantaComprada")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdCompra")
                        .HasColumnType("int");

                    b.Property<int>("IdPlanta")
                        .HasColumnType("int");

                    b.Property<double>("PrecioUnitario")
                        .HasColumnType("float");

                    b.HasKey("IdPlantaComprada");

                    b.HasIndex("IdCompra");

                    b.HasIndex("IdPlanta");

                    b.ToTable("PlantaComprada");
                });

            modelBuilder.Entity("Dominio.TipoPlanta", b =>
                {
                    b.Property<int>("IdTipoPlanta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescripcionTipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUnico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoPlanta");

                    b.ToTable("TipoPlanta");
                });

            modelBuilder.Entity("Dominio.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.HasAlternateKey("Email");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Dominio.Importacion", b =>
                {
                    b.HasBaseType("Dominio.Compra");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EsAmericaSur")
                        .HasColumnType("bit");

                    b.Property<double>("TasaImpuesto")
                        .HasColumnType("float");

                    b.ToTable("Importacion");

                    b.HasDiscriminator().HasValue("Importacion");
                });

            modelBuilder.Entity("Dominio.Plaza", b =>
                {
                    b.HasBaseType("Dominio.Compra");

                    b.Property<bool>("Flete")
                        .HasColumnType("bit");

                    b.Property<double>("Iva")
                        .HasColumnType("float");

                    b.ToTable("Plaza");

                    b.HasDiscriminator().HasValue("Plaza");
                });

            modelBuilder.Entity("Dominio.FichaCuidado", b =>
                {
                    b.HasOne("Dominio.Planta", "miPlanta")
                        .WithMany()
                        .HasForeignKey("IdPlanta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Planta", b =>
                {
                    b.HasOne("Dominio.TipoPlanta", "MiTipoPlanta")
                        .WithMany()
                        .HasForeignKey("IdTipoPlanta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.PlantaComprada", b =>
                {
                    b.HasOne("Dominio.Compra", "miCompra")
                        .WithMany("PlantasCompradas")
                        .HasForeignKey("IdCompra")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.TipoPlanta", "UnaPlanta")
                        .WithMany()
                        .HasForeignKey("IdPlanta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
