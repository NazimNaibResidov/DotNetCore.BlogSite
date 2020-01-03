using Blog.Data.Abstrac;
using Blog.Data.Core.EF;
using Blog.Entity.Data;

namespace Blog.Data.Concreate
{
    public class ArticalRepostory:BaseRepostory<Article>,IArticleRepostory
    {
        public ArticalRepostory(BlogDbContext context) : base(context)
        {

        }
    }
}
