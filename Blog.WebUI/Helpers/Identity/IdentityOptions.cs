using Blog.WebUI.IdentityCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Helpers.Identity
{
    public class IdentityOptions
    {
        public static void Identity(IServiceCollection services)
        {
            var xx = services.AddIdentity<ApplicationUser, IdentityRole>
                 (options =>
                 {
                     options.Password.RequiredLength = 7;
                     options.Password.RequireDigit = false;
                     options.Password.RequiredUniqueChars = 0;
                     options.Password.RequireLowercase = false;
                     options.Password.RequireUppercase = false;
                     options.Password.RequiredUniqueChars = 0;
                     options.Password.RequireNonAlphanumeric = false;
                 })
                 .AddEntityFrameworkStores<ApplicationDbContext>
                 ().AddDefaultTokenProviders();

        }
    }
}
