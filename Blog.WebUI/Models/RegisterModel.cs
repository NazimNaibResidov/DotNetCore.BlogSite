using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Models
{
    public class RegisterModel
    {
        [Required]
        [UIHint("Name")]
        public string Name { get; set; }
        [Required]
        [UIHint("Surname")]
        public string Surname { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
        [Required]
        [UIHint("Email")]
        public string Email { get; set; }
    }
}
