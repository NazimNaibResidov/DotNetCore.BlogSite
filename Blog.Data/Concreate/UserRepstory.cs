using Blog.Data.Abstrac;
using Blog.Data.Core.EF;
using Blog.Entity.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Concreate
{
   public class UserRepstory:BaseRepostory<User>,IUserRepstory
    {
        public UserRepstory(BlogDbContext context) : base(context)
        {

        }
    }
}
