using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Entity.Data
{
    public partial class Image
    {
        public Image()
        {
            Articles = new HashSet<Article>();
          
          
        }

        public int Id { get; set; }
        [StringLength(256)]
        public string Name { get; set; }
        [StringLength(256)]
        public string SPath { get; set; }
        [StringLength(256)]
        public string MPath { get; set; }
        [StringLength(256)]
        public string BPath { get; set; }
        [StringLength(256)]
        public string SliderPath { get; set; }
        [StringLength(256)]
        public string UserPath { get; set; }
        public DateTime DateTime { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
      
    }
}