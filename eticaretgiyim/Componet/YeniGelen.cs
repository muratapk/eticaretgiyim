using eticaretgiyim.Data;
using Microsoft.AspNetCore.Mvc;

namespace eticaretgiyim.Componet
{
    public class YeniGelen:ViewComponent
    {
        private readonly GiyimDbContext _context;

        public YeniGelen(GiyimDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var yenigelenlist = _context.urunlers.Take(8).OrderByDescending(x=>x.UrunID).ToList();
            return View(yenigelenlist);
        }
    }
}
