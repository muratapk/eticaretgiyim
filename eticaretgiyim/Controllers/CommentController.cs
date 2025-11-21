using eticaretgiyim.Data;
using eticaretgiyim.Models;
using Microsoft.AspNetCore.Mvc;

namespace eticaretgiyim.Controllers
{
    public class CommentController : Controller
    {
        private readonly GiyimDbContext _context;
        public CommentController(GiyimDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Comments gelen)
        {   
         
           if (ModelState.IsValid)
            {
                gelen.CreatedAt = DateTime.Now;
                _context.comments.Add(gelen);
                _context.SaveChanges();
                return RedirectToAction("UrunDetay", "Home", new { id = gelen.UrunId });
            }
            return View("Index");
        }
    }
}
