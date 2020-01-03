using System;
using System.Threading.Tasks;
using Blog.Data.Abstrac;


namespace Blog.Data.Core.IUnit
{
   public interface  IUnitOfWork:IDisposable
    {
        ICategoryRepstory CategoryRepstory { get; set; }
        IImageRepstory ImageRepstory { get;  }
        IArticleRepostory ArticleRepostory { get;  }
        ICommentRepstory CommentRepstory { get;  }
        IUserRepstory userRepstory { get; }
        Task<int>  SaveChanges();

    }
}
