using Blog.Data.Core.IUnit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.ViewComponents
{
    public class PostCommentViewComponent:ViewComponent
    {
        private readonly IUnitOfWork Context;
        public PostCommentViewComponent(IUnitOfWork _Context)
        {
            Context = _Context;
        }
        public IViewComponentResult Invoke(int id)
        {
            var data = Context.CommentRepstory.Select()
               .Where(x => x.ArticleId == id)
               .Include(x => x.User)
              .ThenInclude(x => x.Image)
              .ToList();
            return View(data);
        }
    }
}
