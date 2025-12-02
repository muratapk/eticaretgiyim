using eticaretgiyim.Interface;
using eticaretgiyim.Models;

namespace eticaretgiyim.Oturum
{
    public class CartService : ICartService
    {
        public readonly IHttpContextAccessor _httpContextAccessor;
        public const string CartKey= "MyCart";

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }



        //sabit bir anahtar belirledik

        public void AddToCart(CartItem item)
        {
            var cart = GetCartItems();
            var existingItem = cart.FirstOrDefault(i => i.ProductId == item.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                cart.Add(item);
            }
            SaveCart(cart);
        }

        public void ClearCart()
        {
            throw new NotImplementedException();
        }

        public List<CartItem> GetCartItems()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var data= session.GetString(CartKey);
            if (data==null)
            {
                return new List<CartItem>();
            }
            return System.Text.Json.JsonSerializer.Deserialize<List<CartItem>>(data);
        }

        public void Remove(long productId)
        {
            var cart = GetCartItems();
            var itemToRemove = cart.FirstOrDefault(i => i.ProductId == productId);
            if (itemToRemove != null)
            {
                cart.Remove(itemToRemove);
                SaveCart(cart);
            }
        }

        public void SaveCart(List<CartItem> cart)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var data = System.Text.Json.JsonSerializer.Serialize(cart);
            session.SetString(CartKey, data);
        }
    }
}
