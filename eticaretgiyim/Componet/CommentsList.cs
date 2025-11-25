using eticaretgiyim.Data;
using Microsoft.AspNetCore.Mvc;

namespace eticaretgiyim.Componet
{
    public class CommentsList:ViewComponent
    {
        private readonly GiyimDbContext _context;

        public CommentsList(GiyimDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(int urunId)
        {
            var comments = _context.comments
                .Where(c => c.UrunId == urunId)
                .OrderByDescending(c => c.CreatedAt)
                .ToList();
            return View(comments);
        }
    }
}
