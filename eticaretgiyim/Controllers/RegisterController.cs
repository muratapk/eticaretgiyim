using eticaretgiyim.Data;
using eticaretgiyim.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eticaretgiyim.Controllers
{
    public class RegisterController : Controller
    {
        private readonly GiyimDbContext _context;

        private readonly UserManager<AppUser> _userManager;
        public RegisterController(GiyimDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
