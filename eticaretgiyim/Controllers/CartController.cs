using eticaretgiyim.Data;
using eticaretgiyim.Interface;
using eticaretgiyim.Models;
using Microsoft.AspNetCore.Mvc;

namespace eticaretgiyim.Controllers
{
    public class CartController : Controller
    {
        private readonly GiyimDbContext _context;
        private readonly ICartService _cartService;
        public CartController(GiyimDbContext context, ICartService cartService)
        {
            _context = context;
            _cartService = cartService;
        }
        public IActionResult Add(int id)
        {
            var product = _context.urunlers.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            //var cartItem = new Models.CartItem(product.Id, product.Name, 1, product.Price, product.ImageUrl);
            var cartItem = new CartItem(product);
            _cartService.AddToCart(cartItem);
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var cartItems = _cartService.GetCartItems();
            ViewBag.TotalPrice = cartItems.Sum(i => i.TotalPrice);
            ViewBag.TotalQuantity = cartItems.Sum(i => i.Quantity);
            return View(cartItems);
        }
        public IActionResult Summary()
        {
            var cartItems = _cartService.GetCartItems();
            ViewBag.TotalQuantity = cartItems.Sum(i => i.Quantity);
            return PartialView("_CartSummary");
        }
    }
}
