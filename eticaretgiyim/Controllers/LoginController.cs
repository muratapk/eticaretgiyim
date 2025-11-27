using Microsoft.AspNetCore.Mvc;

namespace eticaretgiyim.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
