using eticaretgiyim.Data;
using eticaretgiyim.Models;
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
            var result=_context.kullanicilars.ToList();
            //veritabanındaki kullanicilar listesin getir
            return View(result);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var bul=_context.kullanicilars.Find(id);
            return View(bul);
        }
        [HttpGet]
        public IActionResult Delete(int id  )
        {
            var bul = _context.kullanicilars.Find(id);
            _context.kullanicilars.Remove(bul);
            _context.SaveChanges();
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Kullanicilar formlagelen)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                formlagelen.KayitTarihi = DateTime.Now;
                _context.kullanicilars.Add(formlagelen);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
           
        }
        [HttpPost]
        public IActionResult Edit(Kullanicilar formlagelen)
        {
            var bul = _context.kullanicilars.Find(formlagelen.KullaniciID);
            bul.Ad = formlagelen.Ad;
            bul.Soyad = formlagelen.Soyad;
            bul.Eposta = formlagelen.Eposta;
            bul.SifreHash = formlagelen.SifreHash;
            bul.Telefon = formlagelen.Telefon;
            bul.Rol = formlagelen.Rol;
            _context.SaveChanges();                                                                                                                                                                                                                                                                                                                                                        
            return RedirectToAction("Index");
        }

    }
}
