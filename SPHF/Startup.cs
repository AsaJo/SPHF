using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SPHF.Data;
using SPHF.Models.Repos;
using SPHF.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPHF
{
    public class Startup
    {
        // A Big NOTE for you: If it dose not work with public --->use  this before startup Constructor.
        // private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)// step 4 Config
        {
            Configuration = configuration;// Source of config
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<TankDbContext>(options =>// Step 5
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));// Step 5

            services.AddScoped<ITankRepo, DbTankRepo>();// IoC & DI//         Step 6 Dependency injection!!
            services.AddScoped<ITankService, TankService>();// IoC & DI
            services.AddScoped<ICountryRepo, DbCountryRepo>();// IoC & DI
            services.AddScoped<ICountryService, CountryService>();// IoC & DI

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
