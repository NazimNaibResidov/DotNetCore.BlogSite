using Blog.Data.Core.IUnit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.ViewComponents
{
    public class PostLeaveCommentViewComponent:ViewComponent
    {
        private readonly IUnitOfWork unitOfWork;
        public PostLeaveCommentViewComponent(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IViewComponentResult Invoke(int id)
        {
          return View(id);
        }
    }
}
