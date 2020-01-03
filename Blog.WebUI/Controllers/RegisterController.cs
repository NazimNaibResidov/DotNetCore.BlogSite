using Blog.Data.Core.IUnit;
using Blog.Entity.Data;
using Blog.WebUI.Helpers.Images;
using Blog.WebUI.IdentityCore;
using Blog.WebUI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.WebUI.Controllers
{
    public class RegisterController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHostingEnvironment env;
        private readonly IUnitOfWork unitOfWork;

        public RegisterController(UserManager<ApplicationUser> _userManager, IUnitOfWork _unitOfWork, IHostingEnvironment env)
        {
            userManager = _userManager;
            unitOfWork = _unitOfWork;
            this.env = env;

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model,IFormFile file)
        {
            if (ModelState.IsValid)
            {

                //-----------------------------------------------//
                ApplicationUser identity = new ApplicationUser();
                identity.UserName = model.Name;
                identity.SurName = model.Surname;
                identity.Email = model.Email;
                //--------------------------------------------//
                IdentityResult resulte = await userManager.CreateAsync(identity, model.Password);
                if (resulte.Succeeded)
                {
                   
                    User user = new User();

                    var data = await userManager.FindByEmailAsync(model.Email);
      user.Id = identity.Id;
      user.Name = model.Name;
      user.Surname = model.Surname;
      user.Email = model.Email;
user.ImageID=await  ImageOptions.SaveImageForUser(file, env,unitOfWork);
                   
     



                    unitOfWork.userRepstory.Add(user);
                    await unitOfWork.SaveChanges();

                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    foreach (var item in resulte.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model);
        }
    }
}