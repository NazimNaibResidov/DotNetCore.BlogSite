using System;
using System.Collections.Generic;

namespace Blog.Entity.Data
{
    public partial class Article
    {
        public Article()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string Head { get; set; }
        public string Contet { get; set; }
        public DateTime DateTime { get; set; }
        public int Views { get; set; }
        public int Like { get; set; }
        public int CategoryId { get; set; }
        public int ImageId { get; set; }
        public string UserId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Image Image { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}