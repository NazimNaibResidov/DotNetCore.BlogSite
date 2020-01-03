using Blog.Entity.Data;
using Blog.WebUI.IdentityCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Blog.WebUI.Helpers.Service
{
    public class DbOptions
    {
        public static void EntityDbContext(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BlogDb"), b => b.MigrationsAssembly("Blog.WebUI")));
        }
        public static void IdentityDbContext(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BlogDb")))
                ;
        }
    }
}
