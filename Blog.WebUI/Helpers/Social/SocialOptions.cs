using Blog.WebUI.IdentityCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Helpers.Social
{
    public class SocialOptions
    {
     //   public static void Social(IServiceCollection services)
     //   {
     //       services.AddAuthentication(options =>
     //       { 
     //       })
     //       .AddGoogle(options =>
     //       {
     //           options.ClientId = "23298745479-2dh2se1i9eu1301rtn99bnuo8o68pic8.apps.googleusercontent.com";
     //           options.ClientSecret = "4D64InQ52UlFXiVldIyE5FLT";
     //       })
     //       .AddFacebook(options =>
     //       {
     //           options.AppId = "2178547412439405";
     //           options.AppSecret = "03b2368705ee8cd29c7711f82f4be619";
     //       });
     //   }
     //   public static void Multiple(IServiceCollection services)
     //   {

     //       services.AddDefaultIdentity<ApplicationUser>()
        
     //   .AddEntityFrameworkStores<ApplicationDbContext>();
     //       services.AddAuthentication()
     //       .AddGoogle(options =>
     //{
     //    options.ClientId = "23298745479-2dh2se1i9eu1301rtn99bnuo8o68pic8.apps.googleusercontent.com";
     //    options.ClientSecret = "4D64InQ52UlFXiVldIyE5FLT";
     //})
     //       .AddFacebook(options =>
     //       {
     //           options.AppId = "2178547412439405";
     //           options.AppSecret = "03b2368705ee8cd29c7711f82f4be619";
     //       });
           
     //   }
     //   public static void IdentityWithGoogle(IServiceCollection services)
     //   {
     //       services.AddAuthentication().AddGoogle(options =>
     //       {
     //           options.ClientId = "23298745479-2dh2se1i9eu1301rtn99bnuo8o68pic8.apps.googleusercontent.com";
     //           options.ClientSecret = "4D64InQ52UlFXiVldIyE5FLT";


     //           options.ClaimActions.MapJsonKey("urn:google:picture", "picture", "url");
     //           options.ClaimActions.MapJsonKey("urn:google:locale", "locale", "string");
     //           options.SaveTokens = true;

     //           options.Events.OnCreatingTicket = ctx =>
     //           {
     //               List<AuthenticationToken> tokens = ctx.Properties.GetTokens().ToList();

     //               tokens.Add(new AuthenticationToken()
     //               {
     //                   Name = "TicketCreated",
     //                   Value = DateTime.UtcNow.ToString()
     //               });

     //               ctx.Properties.StoreTokens(tokens);

     //               return Task.CompletedTask;
     //           };
     //       });
     //   }
    }
}
