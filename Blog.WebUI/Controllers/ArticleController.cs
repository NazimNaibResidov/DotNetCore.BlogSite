using Blog.Data.Core.IUnit;
using Blog.Entity.Data;
using Blog.WebUI.Helpers;
using Blog.WebUI.Helpers.Images;
using Blog.WebUI.Helpers.Paths;
using Blog.WebUI.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Blog.WebUI.Controllers
{
    public class ArticleController : Controller
    {
        
        private readonly IUnitOfWork context;
        private readonly IHostingEnvironment env;
        public ArticleController(IUnitOfWork _context,IHostingEnvironment environment)
        {
            context = _context;
            env = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {

            ViewBag.cat= context.CategoryRepstory.Select();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Article article,IFormFile file)
        {

            if (ModelState.IsValid)
            {
                var id = "89a74492-e7b7-4564-a82a-5bb97cf367d6";
                    //HttpContext.Session.Get<string>("id");

                article.DateTime = DateTime.Now;
                article.Views = 0;
                article.Like = 0;
                article.UserId=id;

article.ImageId=  await ImageOptions.SaveImage(file, env, context);
                
                context.ArticleRepostory.Add(article);
                await context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(article);
        }
        public async Task<IActionResult> Delete(int id)
        {

           var data= context.ArticleRepostory.GetById(id);
            context.ArticleRepostory.Delete(data);
            await context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Update(int id)
        {
            return View();
        }
        public async Task<IActionResult> Update(Article article)
        {
           
            return RedirectToAction("Index", "Home");
        }
    }
}