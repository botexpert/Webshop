namespace Webshop.Application.DTOs
{
    public class ShopItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public string ImageUrl { get; set; }
        // public bool IsFavorite { get; set; }
        public int StockQuantity { get; set; }
        public string Category { get; set; }
    }
}