using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Dominio;

namespace DataAccess.Contexto
{
    public class ViveroContexto : DbContext
    {
        public string _connString;
        public ViveroContexto(string connString)
        {
            _connString = connString;
        }

        public ViveroContexto(DbContextOptions<ViveroContexto> options) : base(options)
        {

        }
        #region
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=.\; database=SegundoObligatorio; integrated security=true;");
        }
        */
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Compra>();
            modelBuilder.Entity<FichaCuidado>();
            modelBuilder.Entity<Importacion>();
            modelBuilder.Entity<TipoPlanta>();
            modelBuilder.Entity<PlantaComprada>();
            modelBuilder.Entity<Planta>();
            modelBuilder.Entity<Plaza>();
            modelBuilder.Entity<TipoPlanta>();
            modelBuilder.Entity<Usuario>();

            modelBuilder.Entity<Usuario>().HasAlternateKey(u => u.Email);

            modelBuilder.Entity<Planta>().HasOne(t => t.MiTipoPlanta);
            modelBuilder.Entity<FichaCuidado>().HasOne(p => p.MiPlanta);
            modelBuilder.Entity<PlantaComprada>().HasOne(p => p.UnaPlanta);
            modelBuilder.Entity<Compra>().HasMany(p => p.PlantasCompradas).WithOne(p => p.miCompra);

            modelBuilder.Entity<Plaza>().HasBaseType<Compra>();
            modelBuilder.Entity<Importacion>().HasBaseType<Compra>();

        }


        public  DbSet<Compra> Compra { get; set; }
        public  DbSet<FichaCuidado> FichaCuidado { get; set; }
        public  DbSet<Importacion> Importacion { get; set; }
        public  DbSet<Planta> Planta { get; set; }
        public  DbSet<PlantaComprada> PlantaComprada { get; set; }
        public  DbSet<Plaza> Plaza { get; set; }
        public  DbSet<TipoPlanta> TipoPlanta { get; set; }
        public  DbSet<Usuario> Usuario { get; set; }


    }
}
