using eticaretgiyim.Models;

namespace eticaretgiyim.Interface
{
    public interface ICartService
    {
        List<CartItem> GetCartItems();
        void AddToCart(CartItem item);
        void Remove(long productId);
        void ClearCart();
        void SaveCart(List<CartItem> cart);
    }
}
