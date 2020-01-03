using Blog.Data.Core.IUnit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.ViewComponents
{
    public class AuthorMenuViewComponent:ViewComponent
    {
        private readonly IUnitOfWork unitOfWork;
        public AuthorMenuViewComponent(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IViewComponentResult Invoke()
        {
           var context= unitOfWork.userRepstory.Select()
                .Include(x => x.Image)
                .FirstOrDefault();
            return View(context);
        }
    }
}
