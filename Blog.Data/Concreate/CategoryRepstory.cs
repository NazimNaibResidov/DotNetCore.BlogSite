using Blog.Data.Abstrac;
using Blog.Data.Core.EF;
using Blog.Entity.Data;

namespace Blog.Data.Concreate
{
    public class CategoryRepstory:BaseRepostory<Category>,ICategoryRepstory
    {
        public CategoryRepstory(BlogDbContext context) : base(context)
        {

        }
    }
}
