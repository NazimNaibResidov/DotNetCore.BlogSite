using Blog.Data.Abstrac;
using Blog.Data.Core.EF;
using Blog.Entity.Data;

namespace Blog.Data.Concreate
{
    public class ImageRepstory:BaseRepostory<Image>,IImageRepstory
    {
        public ImageRepstory(BlogDbContext context):base(context)
        {

        }
    }
}
