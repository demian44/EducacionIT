using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MIddlewareEjemplo
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger)
        {
            // el mètodo .Run no permite que se ejecuten otros middleware
            /*app.Run(async (context) =>
            {
                await context.Response.WriteAsync( "Hola Mundo!" ); 

            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hola Mundo desde segundo Middleware ");
            });*/
            app.UseMyMiddleware();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hola Mundo!\n");
                await next();
            });

            app.Run(async (context) => { await context.Response.WriteAsync( "Hola Mundo 2!" ); });

            //Con .Use podemos usar varios middleware combinados
            /* app.Use(async (context, next) =>
              {
                  await context.Response.WriteAsync("Hola Mundo!\n");
                  await next();
              });

              app.Use(async (context, next) =>
              {
                  await context.Response.WriteAsync("Hola Mundo desde segundo Middleware \n");
                  await next();
              });*/

                //app.UseWelcomePage();
                /*app.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync("Hola Mundo!\n");
                    await next();
                });*/



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
