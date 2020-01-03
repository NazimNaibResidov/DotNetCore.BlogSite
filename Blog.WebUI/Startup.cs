using Blog.WebUI.Helpers;
using Blog.WebUI.Helpers.Identity;
using Blog.WebUI.Helpers.Service;
using Blog.WebUI.Tools;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Blog.WebUI
{
    public class Startup
    {
        private IConfiguration  Configuration { get; }
        public Startup(IConfiguration _Configuration)
        {
            Configuration = _Configuration;

        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                // options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });





            IdentityOptions.Identity(services);
            Servies.DInj(services);
          
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
            DbOptions.EntityDbContext(services, Configuration);
            DbOptions.IdentityDbContext(services, Configuration);
           
           
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(
                routes => routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}")
                );

        }
    }
}
