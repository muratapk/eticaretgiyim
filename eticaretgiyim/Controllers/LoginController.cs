using eticaretgiyim.Dto;
using eticaretgiyim.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eticaretgiyim.Controllers
{
    
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager,SignInManager<AppUser> signManager)
        {
            _userManager = userManager;
            _signInManager = signManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDto gelen)
        {
            var result=await _signInManager.PasswordSignInAsync(gelen.UserName,gelen.Password,false,false);
            if(result.Succeeded)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }
    }
}
