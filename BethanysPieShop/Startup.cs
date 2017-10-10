using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BethanysPieShop
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }
       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage(); // Enable the use of the developer exception page in the app
            app.UseStatusCodePages();   // Add support for text only headers for common status codes.
            app.UseStaticFiles(); // Enable the ability for my site to serve static files.
            app.UseMvcWithDefaultRoute(); // Setup the MVC middleware using the default routing schema.
        }
    }
}
