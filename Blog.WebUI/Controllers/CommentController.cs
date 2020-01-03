using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Core.IUnit;
using Blog.Entity.Data;
using Blog.WebUI.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public CommentController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Comment comment,int id)
        {
            comment.DateTime = DateTime.Now;
            comment.ArticleId = id;
            comment.UserId=   HttpContext.Session.Get<string>("id");
            unitOfWork.CommentRepstory.Add(comment);
            return RedirectToAction("Read","Blog",new { id = id });
        }
    }
}