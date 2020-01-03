using Blog.Data.Core.IUnit;
using Blog.Entity.Data;
using Blog.WebUI.IdentityCore;
using Blog.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Blog.WebUI.Infrastructure;

namespace Blog.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IUnitOfWork unitOfWork;

        public LoginController(UserManager<ApplicationUser> _userManager,
           SignInManager<ApplicationUser> _signInManager,IUnitOfWork _unitOfWork)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            unitOfWork = _unitOfWork;
         
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        HttpContext.Session.Set("id", user.Id);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("key", "Invalide Errors");
            }
            return View(model);
        }
        public async Task<IActionResult> LoginComment(LoginModel model,int id)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        HttpContext.Session.Set("id", user.Id);
                        return RedirectToAction("Read", "Blog",new { id = id });
                    }
                }
                ModelState.AddModelError("", "Invalide Errors");
            }
            return View(model);
        }
        public async Task<IActionResult> SingOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}