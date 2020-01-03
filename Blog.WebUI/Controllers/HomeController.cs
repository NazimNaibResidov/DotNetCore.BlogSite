using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Blog.Data.Abstrac;
using Blog.Data.Concreate;
using Blog.Data.Core.IUnit;
using Blog.Entity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IArticleRepostory articleRepostory;
        public HomeController(IUnitOfWork _unitOfWork,IArticleRepostory _articleRepostory)
        {
            unitOfWork = _unitOfWork;
            articleRepostory = _articleRepostory;
        }
        public IActionResult Index()
        {

            var contex= unitOfWork.ArticleRepostory.Select().Include(x => x.Image)
                 .Include(x => x.Category)
                 .Include(x => x.User).ToList().OrderByDescending(x=>x.Id);

            return View("_List",contex);

           
          
        }
    }
}