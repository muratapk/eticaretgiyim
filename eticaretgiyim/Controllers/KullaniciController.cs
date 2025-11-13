using eticaretgiyim.Data;
using Microsoft.AspNetCore.Mvc;

namespace eticaretgiyim.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly GiyimDbContext _context;
        //global tanımlanan _context bu sayfa her yerden çağırabileyim private
        //değiştirilmesin
        public KullaniciController(GiyimDbContext context)
        {
            _context = context;
        }
        //ototmatik Constructor Oluşturuldu
        public IActionResult Index()
        {
            var result=_context.Kullanicilars.ToList();
            //veritabanındaki kullanicilar listesin getir
            return View(result);
        }
    }
}
