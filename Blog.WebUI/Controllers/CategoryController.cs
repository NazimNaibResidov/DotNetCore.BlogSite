using Blog.Data.Core.IUnit;
using Blog.Entity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public CategoryController(IUnitOfWork _unitOfWork)
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
        public async Task<IActionResult> Add(Category category)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.CategoryRepstory.Add(category);
                await unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }
        public IActionResult Blog(int id)
        {
            var context = unitOfWork.ArticleRepostory.Select()
                  .Where(x => x.CategoryId == id)
                  .Include(x => x.Image)
                  .Include(x => x.Category)
                  .Include(x => x.User)
                  .ToList();
            if (context.Count==0)
            {
                return View("_Errors");
            }
           
            return View("_List", context);
        }
    }
}