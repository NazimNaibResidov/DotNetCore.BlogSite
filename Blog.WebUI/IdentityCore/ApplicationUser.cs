using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.IdentityCore
{
    public class ApplicationUser:IdentityUser
    {
        public string SurName { get; set; }
    }
}
