namespace eticaretgiyim.Models
{
    public class CartItem
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public decimal TotalPrice 
        { 
            get 
            {
                return Price * Quantity;
            }
        }
        public CartItem(long productId, string productName, int quantity, decimal price, string imageUrl)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            ImageUrl = imageUrl;
        }
    }
}
