using Blog.Data.Core.IUnit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Blog.WebUI.ViewComponents
{
    public class PopularRecentViewComponent:ViewComponent
    {
        private readonly IUnitOfWork unitOfWork;
        public PopularRecentViewComponent(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.img = unitOfWork.ArticleRepostory.Select()
                 .Include(x => x.Image).ToList();
            ViewBag.rec = unitOfWork.ArticleRepostory.Select().Include(x=>x.Image).OrderByDescending(x => x.Views).Take(5).ToList();
            var data = unitOfWork.ArticleRepostory.Select().Include(x => x.Image).OrderByDescending(x => x.Id).Take(5).ToList();
            return View(data);
        }
    }
}
