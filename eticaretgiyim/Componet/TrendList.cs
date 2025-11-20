using eticaretgiyim.Data;
using Microsoft.AspNetCore.Mvc;

namespace eticaretgiyim.Componet
{
    public class TrendList:ViewComponent
    {
        private readonly GiyimDbContext _context;
        public TrendList(GiyimDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var trendlist = _context.urunlers.ToList();
            return View(trendlist);
        }
    }
}
