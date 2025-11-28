using eticaretgiyim.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eticaretgiyim.Controllers
{
    public class LogoutController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LogoutController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            await _signInManager.SignOutAsync();
            TempData["Mesaj"] = "Başarıyla çıkış yaptınız.";

            return RedirectToAction("Index", "Home");
        }
    }
}
