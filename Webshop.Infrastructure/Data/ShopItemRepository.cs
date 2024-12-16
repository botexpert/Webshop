using Microsoft.EntityFrameworkCore;
using Webshop.Domain.Interfaces;
using Webshop.Domain.Entities;

namespace Webshop.Infrastructure.Data
{
    public class ShopItemRepository : Repository<ShopItem>, IShopItemRepository
    {
        public ShopItemRepository(WebshopDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ShopItem>> GetShopItemsAsync()
        {
            return await _context.ShopItems.ToListAsync();
        }
    }
}
