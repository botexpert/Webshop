namespace Webshop.Domain.Entities
{
    public class ShopItem
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public decimal? DiscountedPrice { get; private set; }
        public string ImageUrl { get; private set; }
        // public bool IsFavorite { get; private set; }
        public int StockQuantity { get; private set; }
        public string Category { get; private set; }

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
