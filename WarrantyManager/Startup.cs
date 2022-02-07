using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using WarrantyManager.Data;
using WarrantyManager.Services;

namespace WarrantyManager
{
    public class Startup
    {

        private readonly bool _seedDatabase;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _seedDatabase = bool.Parse(Configuration["SeedDatabase"]);
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WarrantyManagementDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:WarrantyDb"]);
                //options.UseSqlite(Configuration["ConnectionStrings:WarrantyDbPortable"]);

                //
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowDeveloperOrigin",
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin();
                                  });
            });

            services.AddScoped<IWarrantyService, WarrantyService>();

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //services.AddControllers();
            services.AddAutoMapper(typeof(Startup));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Warranty Manager API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //database seeding
            if (_seedDatabase == true)
            {
                SeedDatabase(app);
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Warranty Manager");
            });
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("AllowDeveloperOrigin");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        private void SeedDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            if (!serviceScope.ServiceProvider.GetService<WarrantyManagementDbContext>().AllMigrationsApplied())
            {
                try
                {
                    serviceScope.ServiceProvider.GetService<WarrantyManagementDbContext>().Database.Migrate();
                    serviceScope.ServiceProvider.GetService<WarrantyManagementDbContext>().EnsureSeeded(false);
                }
                catch (Exception)
                {
                    throw;

                }
            }
            else
            {
                serviceScope.ServiceProvider.GetService<WarrantyManagementDbContext>().Database.Migrate();
                serviceScope.ServiceProvider.GetService<WarrantyManagementDbContext>().EnsureSeeded(true);

            }


        }




    }
}
