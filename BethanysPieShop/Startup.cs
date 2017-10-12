using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BethanysPieShop
{
    public class Startup
    {
        /*
         Migrations Commands:
         1) Add-Migration Initial
         2) Update-Database
             
             */
        private IConfigurationRoot _configurationRoot;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder()
                                    .SetBasePath(hostingEnvironment.ContentRootPath)
                                    .AddJsonFile("appsettings.json")
                                    .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IPieRepository, PieRepository>();
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ShoppingCart>(ShoppingCart.GetCart);

            services.AddMvc();

            services.AddMemoryCache();
            services.AddSession();

            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetService<AppDbContext>();
            DbInitializer.Seed(dbContext);
        }
       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage(); // Enable the use of the developer exception page in the app
            app.UseStatusCodePages();   // Add support for text only headers for common status codes.
            app.UseStaticFiles(); // Enable the ability for my site to serve static files.
            app.UseSession(); // should go before ...defaultRoute otherwise will not work.
            app.UseMvcWithDefaultRoute(); // Setup the MVC middleware using the default routing schema.
        }
    }
}
