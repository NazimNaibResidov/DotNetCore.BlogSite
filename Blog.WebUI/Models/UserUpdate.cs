using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Models
{
    public class UserUpdate
    {
        public string Id { get; set; }
        
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
