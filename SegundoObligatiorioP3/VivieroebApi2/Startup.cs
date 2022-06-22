using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using DataAccess;
using Dominio.InterfacesRepositorio;
using DataAccess.EF;
using DataAccess.Contexto;
using Microsoft.EntityFrameworkCore;

namespace VivieroebApi2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IRepositorioPlanta, RepositorioPlanta>();
            services.AddScoped<IRepositorioPlaza, RepositorioPlaza>();
            services.AddScoped<IRepositorioImportacion, RepositorioImportacion>();
            //Inyeccion de dependencias
            services.AddDbContext<ViveroContexto>
                (opt => opt.UseSqlServer(Configuration.GetConnectionString("ConexionVivero")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
