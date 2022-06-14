using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Dominio; 

namespace DataAccess.Contexto
{
    public class Vivero : DbContext
    {
        public DbSet<Compra> Compra { get; set; }
        public DbSet<FichaCuidado> FichaCuidado { get; set; }
        public DbSet<Importacion> Importacion { get; set; }
        public DbSet<Planta> Planta { get; set; }
        public DbSet<PlantaComprada> PlantaComprada { get; set; }
        public DbSet<Plaza> Plaza { get; set; }
        public DbSet<TipoPlanta> TipoPlanta { get; set; }
        public DbSet<Usuario> Usuario { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=.\; database=SegundoObligatorio; integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compra>();
            modelBuilder.Entity<FichaCuidado>();
            modelBuilder.Entity<Importacion>();
            modelBuilder.Entity<Planta>();
            modelBuilder.Entity<PlantaComprada>();
            modelBuilder.Entity<Plaza>();
            modelBuilder.Entity<TipoPlanta>();
            modelBuilder.Entity<Usuario>();

            //Creo la relacion
            modelBuilder.Entity<FichaCuidado>().HasOne(p => p.miPlanta);
            modelBuilder.Entity<Planta>().HasOne(p => p.MiTipoPlanta);
            modelBuilder.Entity<PlantaComprada>().HasOne(p => p.UnaPlanta);
            // modelBuilder.Entity<Vehiculo>().HasOne(v => v.Marca);

        }
    }
}
