using Microsoft.EntityFrameworkCore;
using Webshop.Domain.Entities;

namespace Webshop.Infrastructure.Data
{
    public class WebshopDbContext : DbContext
    {
        public WebshopDbContext(DbContextOptions<WebshopDbContext> options) 
            : base(options) { }

        public DbSet<ShopItem> ShopItems { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply configurations for entities
            modelBuilder.Entity<ShopItem>().ToTable("ShopItems");
            modelBuilder.Entity<Account>().ToTable("Accounts");

            base.OnModelCreating(modelBuilder);
        }
    }
}
