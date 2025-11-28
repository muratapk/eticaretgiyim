using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eticaretgiyim.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
