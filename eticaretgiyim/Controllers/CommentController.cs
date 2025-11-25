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
            var result=_context.comments.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save(Comments gelen)
        {
            _context.comments.Add(gelen);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
           var result= _context.comments.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Comments gelen)
        {
            _context.comments.Update(gelen);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(Comments gelen)
        {
            _context.comments.Remove(gelen);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = _context.comments.Find(id);
            return View(result);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var result = _context.comments.Find(id);
            return View(result);
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
            return RedirectToAction("UrunDetay", "Home", new { id = gelen.UrunId });
        }
        [HttpGet]
        public IActionResult GetComments(int urunId)
        {
            var comments = _context.comments
                .Where(c => c.UrunId == urunId)
                .OrderByDescending(c => c.CreatedAt)
                .ToList();
            return PartialView("_CommentsPartial", comments);
        }
    }
}
