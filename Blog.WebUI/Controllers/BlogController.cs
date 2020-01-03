using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Core.IUnit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public BlogController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Read(int id)
        {
            var data = unitOfWork.ArticleRepostory
                .Select()
                .Include(x => x.User)
                .Include(x => x.Category)
                .Include(x=>x.Comments)
                .Include(x => x.Image)
                
                .FirstOrDefault(x=>x.Id==id);
                
            return View(data);
        }
    }
}