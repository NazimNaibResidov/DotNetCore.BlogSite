using Blog.Data.Core.IUnit;
using Blog.WebUI.IdentityCore;
using Blog.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blog.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IPasswordHasher<ApplicationUser> passwordHasher;
        private readonly IPasswordValidator<ApplicationUser> passwordValidator;


        public UserController(UserManager<ApplicationUser> _userManager,
            IPasswordHasher<ApplicationUser> _passwordHasher,
            IPasswordValidator<ApplicationUser> _passwordValidator,
            SignInManager<ApplicationUser> _signInManager,
            IUnitOfWork _unitOfWork)
        {
            this._userManager = _userManager;
            passwordHasher = _passwordHasher;
            passwordValidator = _passwordValidator;
            this._signInManager = _signInManager;
            unitOfWork = _unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
      
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user =await _userManager.FindByIdAsync(id);
            if (user!=null)
            {
                var resulte = await _userManager.DeleteAsync(user);
                if (resulte.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in resulte.Errors)
                    {
                        ModelState.AddModelError("key", item.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("key", "User Not Found");
            }
            return View("Index",_userManager.Users);
        }
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var user =await _userManager.FindByIdAsync(id);
            if (user!=null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdate data)
        {
            var user =await _userManager.FindByIdAsync(data.Id);
            if (user!=null)
            { user.Email = data.Email;
                IdentityResult identityResult = null;
                if (!string.IsNullOrEmpty(data.Password))
                {
                    identityResult= await passwordValidator.ValidateAsync(_userManager, user, data.Password);
                    
                    if (identityResult.Succeeded)
                    {
                      user.PasswordHash=  passwordHasher.HashPassword(user, data.Password);
                    }
                    else
                    {
                   foreach (IdentityError item in identityResult.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                   
                   
                }
                if (!string.IsNullOrEmpty(data.UserName))
                {
                  identityResult= await _userManager.SetUserNameAsync(user, data.UserName);
                }
                if (identityResult.Succeeded)
                    {
                       await _userManager.UpdateAsync(user);
                    return RedirectToAction("Index");
                    }
            }
            return View(data);
           
            
        }

       
    }
}