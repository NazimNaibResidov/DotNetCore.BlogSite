using Blog.Data.Abstrac;
using Blog.Data.Core.EF;
using Blog.Entity.Data;

namespace Blog.Data.Concreate
{
    public class CommentRepostory:BaseRepostory<Comment>,ICommentRepstory
    {
        public CommentRepostory(BlogDbContext context) : base(context)
        {

        }
    }
}
