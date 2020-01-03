using System;
using System.Threading.Tasks;
using Blog.Data.Abstrac;
using Blog.Data.Concreate;
using Blog.Data.Core.IUnit;
using Blog.Entity.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Concreate
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDbContext context;

        public UnitOfWork(BlogDbContext _context)
        {
           
            context = _context ?? throw new ArgumentNullException("Argument context cannot be null");
            
        }

        private ICategoryRepstory _CategoryRepstory;
        private IImageRepstory    _ImageRepstory;
        private IUserRepstory _userRepstory;
        
        private IArticleRepostory _ArticleRepostory;
        private ICommentRepstory  _CommentRepstory;


        public ICategoryRepstory CategoryRepstory {

            get
            {
                return _CategoryRepstory ?? (_CategoryRepstory = new CategoryRepstory(context));
            }
            set
            {
                CategoryRepstory = _CategoryRepstory;
            }
        }
        public IImageRepstory    ImageRepstory { get {

                return _ImageRepstory ?? (_ImageRepstory = new ImageRepstory(context));
            } }
       
        public IArticleRepostory ArticleRepostory { get

            {
                return _ArticleRepostory ?? (_ArticleRepostory = new ArticalRepostory(context));
            }
                }
        public ICommentRepstory  CommentRepstory { get {

                return _CommentRepstory ?? (_CommentRepstory = new CommentRepostory(context));
            } }

        public IUserRepstory userRepstory
        {
            get
            {
                return _userRepstory ?? (_userRepstory = new UserRepstory(context));
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> SaveChanges()
        {
            
            try
            {
                return await context.SaveChangesAsync();
            }
           
            catch (DbUpdateConcurrencyException ex)
            {
                return 0;
            }
            catch (DbUpdateException ex)
            {

                return 0;
            }

        }
    }
}
