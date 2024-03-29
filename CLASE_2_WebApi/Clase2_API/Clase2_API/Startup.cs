﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clase2_API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Clase2_API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ApplicationDBContext>
                (options => options.UseInMemoryDatabase("DB"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env,
            ApplicationDBContext contexto)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            if (!contexto.Amigos.Any())
            {
                contexto.Amigos.AddRange(new List<Amigo>()
                {
                    new Amigo(){ID=1,Apellido="Montenegro",Nombre="Teresita"},
                    new Amigo(){ID=2,Apellido="Gallego",Nombre="Cristina"},
                    new Amigo(){ID=3,Apellido="Guarnes",Nombre="Guillermo"},
                });
                contexto.SaveChanges(); // guardo registros
            }

        }
    }
}
