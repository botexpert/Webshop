using Webshop.Domain.Entities;
using Webshop.Application.Interfaces;
using Webshop.Application.DTOs;
using Webshop.Domain.Interfaces;

namespace Webshop.Infrastructure.Services
{
    public class ShopItemService : IShopItemService
    {
        private readonly IRepository<ShopItem> _repository;

        public ShopItemService(IRepository<ShopItem> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ShopItemDto>> GetAllItemsAsync()
        {
            var items = await _repository.GetAllAsync();
            return items.Select(item => new ShopItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                DiscountedPrice = item.DiscountedPrice,
                ImageUrl = item.ImageUrl,
                // IsFavorite = item.IsFavorite,
                StockQuantity = item.StockQuantity,
                Category = item.Category
            });
        }

        public async Task<ShopItemDto> GetItemByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item == null ? null : new ShopItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                DiscountedPrice = item.DiscountedPrice,
                ImageUrl = item.ImageUrl,
                // IsFavorite = item.IsFavorite,
                StockQuantity = item.StockQuantity,
                Category = item.Category
            };
        }

        public async Task<ShopItemDto> AddItemAsync(ShopItemDto itemDto)
        {
            var shopItem = new ShopItem(
                itemDto.Name, itemDto.Description, itemDto.Price,
                itemDto.ImageUrl, itemDto.StockQuantity, itemDto.Category);

            await _repository.AddAsync(shopItem);
            await _repository.SaveChangesAsync();

            itemDto.Id = shopItem.Id;
            return itemDto;
        }

        public async Task UpdateItemAsync(int id, ShopItemDto itemDto)
        {
            var shopItem = await _repository.GetByIdAsync(id);
            if (shopItem == null) throw new Exception("ShopItem not found.");

            shopItem = new ShopItem(
                itemDto.Name, itemDto.Description, itemDto.Price,
                itemDto.ImageUrl, itemDto.StockQuantity, itemDto.Category);

            await _repository.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
