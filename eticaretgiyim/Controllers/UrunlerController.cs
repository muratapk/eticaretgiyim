using eticaretgiyim.Data;
using eticaretgiyim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eticaretgiyim.Controllers
{
    public class UrunlerController : Controller
    {
        private readonly GiyimDbContext _context;

        public UrunlerController(GiyimDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.urunlers.ToList();   
            return View(result);
        }
        [HttpGet]
        public IActionResult Detay(int id)
        {
            var urun = _context.urunlers.FirstOrDefault(u => u.UrunID == id);
            if (urun == null)
            {
                return NotFound();
            }
            return View(urun);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var urun = _context.urunlers.FirstOrDefault(u => u.UrunID == id);

            ViewBag.Kategoriler = new SelectList(_context.kategorilers, "KategoriID", "KategoriAd");
                                                                                          
            if (urun == null)
            {
                return NotFound();
            }
            return View(urun);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var urun = _context.urunlers.FirstOrDefault(u => u.UrunID == id);
            if (urun == null)
            {
                return NotFound();
            }
            return View(urun);
        }
        public IActionResult Create()
        {
            ViewBag.Kategoriler =new SelectList(_context.kategorilers, "KategoriID", "KategoriAd");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Urunler urun,IFormFile Picture)
        {
            if(Picture != null && Picture.Length > 0)
            {
                var uzanti = Path.GetExtension(Picture.FileName).ToLower();   
                //dosyanın uzantısını al
                if(uzanti != ".jpg" && uzanti != ".png" && uzanti != ".jpeg")
                {
                    ModelState.AddModelError("Picture", "Sadece .jpg, .png ve .jpeg uzantılı dosyalar yüklenebilir.");
                    ViewBag.Kategoriler = new SelectList(_context.kategorilers, "KategoriID", "KategoriAd");
                    return View(urun);
                    //tekrar view create e dön

                }
                var yenidosya = Guid.NewGuid().ToString() + uzanti;
                //dosya adını benzersiz yap için guid kullan

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product_Image/", yenidosya);
                //dosyayı kaydet kullanılacak yolu belirle
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Picture.CopyTo(stream);
                }
                urun.GorselUrl = "/Product_Image/" + yenidosya;
            }

            if (ModelState.IsValid)
            {
                _context.urunlers.Add(urun);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Kategoriler = new SelectList(_context.kategorilers, "KategoriID", "KategoriAd");
            return View(urun);
        }
        [HttpPost]
        public IActionResult Edit(Urunler urun,IFormFile Picture)
        {

            if (Picture != null && Picture.Length > 0)
            {
                var uzanti = Path.GetExtension(Picture.FileName).ToLower();
                //dosyanın uzantısını al
                if (uzanti != ".jpg" && uzanti != ".png" && uzanti != ".jpeg")
                {
                    ModelState.AddModelError("Picture", "Sadece .jpg, .png ve .jpeg uzantılı dosyalar yüklenebilir.");
                    ViewBag.Kategoriler = new SelectList(_context.kategorilers, "KategoriID", "KategoriAd");
                    return View(urun);
                    //tekrar view create e dön

                }
                var yenidosya = Guid.NewGuid().ToString() + uzanti;
                //dosya adını benzersiz yap için guid kullan

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product_Image/", yenidosya);
                //dosyayı kaydet kullanılacak yolu belirle
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Picture.CopyTo(stream);
                }
                urun.GorselUrl = "/Product_Image/" + yenidosya;
            }



            if (ModelState.IsValid)
            {
                _context.urunlers.Update(urun);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Kategoriler = new SelectList(_context.kategorilers, "KategoriID", "KategoriAd");
            return View(urun);
        }
        [HttpPost]
        public IActionResult Delete(Urunler urunler)
        {

           if(urunler.UrunID==null)
            {
                return NotFound();
            }
            var urun = _context.urunlers.FirstOrDefault(u => u.UrunID == urunler.UrunID);
            if (urun == null)
            {
                return NotFound();
            }
            _context.urunlers.Remove(urun);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
