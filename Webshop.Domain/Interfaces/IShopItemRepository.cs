using Webshop.Domain.Entities;

namespace Webshop.Domain.Interfaces
{
    public interface IShopItemRepository : IRepository<ShopItem>
    {
        Task<IEnumerable<ShopItem>> GetShopItemsAsync();
    }
}