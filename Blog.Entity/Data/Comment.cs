using System;
using System.Collections.Generic;

namespace Blog.Entity.Data
{
    public partial class Comment
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Context { get; set; }
        public string UserId { get; set; }
        public int ArticleId { get; set; }
      
        public virtual Article Article { get; set; }
        public virtual User User { get; set; }
    }
}