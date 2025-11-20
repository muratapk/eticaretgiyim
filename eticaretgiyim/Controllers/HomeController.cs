using eticaretgiyim.Data;
using eticaretgiyim.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eticaretgiyim.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GiyimDbContext _context;
        public HomeController(ILogger<HomeController> logger,GiyimDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UrunDetay(int id)
        {
            var result=_context.urunlers.Where(u=>u.UrunID==id).FirstOrDefault();
            return View(result);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
