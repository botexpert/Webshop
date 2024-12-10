using Webshop.Application.DTOs;

namespace Webshop.Application.Interfaces
{
    public interface IShopItemService
    {
        Task<IEnumerable<ShopItemDto>> GetAllItemsAsync();
        Task<ShopItemDto> GetItemByIdAsync(int id);
        Task<ShopItemDto> AddItemAsync(ShopItemDto itemDto);
        Task UpdateItemAsync(int id, ShopItemDto itemDto);
        Task DeleteItemAsync(int id);
    }
}