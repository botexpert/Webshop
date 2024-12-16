namespace Webshop.Domain.Entities
{
    public class ShopItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public string ImageUrl { get; set; }
        // public bool IsFavorite { get; private set; }
        public int StockQuantity { get; set; }
        public string Category { get; set; }

        public ShopItem(string name, string description, decimal price, string imageUrl, int stockQuantity, string category)
        {
            Name = name;
            Description = description;
            Price = price;
            ImageUrl = imageUrl;
            StockQuantity = stockQuantity;
            Category = category;
        }

        // public void UpdateStock(int quantity)
        // {
        //     if (quantity < 0) throw new ArgumentException("Quantity cannot be negative.");
        //     StockQuantity = quantity;
        // }
    }
}
