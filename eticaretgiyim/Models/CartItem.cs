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
        public CartItem(Urunler product)
        {
            ProductId = product.UrunID;
            ProductName = product.UrunAd;
            Quantity = 1;
            Price =Convert.ToDecimal(product.Fiyat);
            ImageUrl = product.GorselUrl;
        }
    }
}
