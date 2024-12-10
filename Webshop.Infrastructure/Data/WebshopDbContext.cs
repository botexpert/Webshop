using Microsoft.EntityFrameworkCore;
using Webshop.Domain.Entities;

namespace Webshop.Infrastructure.Data
{
    public class WebshopDbContext : DbContext
    {
        public WebshopDbContext(DbContextOptions<WebshopDbContext> options) 
            : base(options) { }

        public DbSet<ShopItem> ShopItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply configurations for entities
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebshopDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
