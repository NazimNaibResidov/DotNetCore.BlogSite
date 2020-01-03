using Blog.Data.Core.IUnit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Blog.WebUI.ViewComponents
{
    public class CategoryMenuViewComponent:ViewComponent
    {
        private readonly IUnitOfWork unitOfWork;
        public CategoryMenuViewComponent(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public IViewComponentResult Invoke()
        {
          var context=  unitOfWork.CategoryRepstory.Select()
                .Include(x => x.Articles)
                .ToList();
            return View(context);
        }
    }
}
