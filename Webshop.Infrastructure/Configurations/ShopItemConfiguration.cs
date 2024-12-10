using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Webshop.Domain.Entities;

namespace Webshop.Infrastructure.Configurations
{
    public class ShopItemConfiguration : IEntityTypeConfiguration<ShopItem>
    {
        public void Configure(EntityTypeBuilder<ShopItem> builder)
        {
            builder.ToTable("ShopItems");

            builder.HasKey(si => si.Id);

            builder.Property(si => si.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(si => si.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(si => si.Price)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(si => si.DiscountedPrice)
                .HasPrecision(18, 2);

            builder.Property(si => si.ImageUrl)
                .HasMaxLength(200);

            builder.Property(si => si.Category)
                .HasMaxLength(50);

            // Default value for IsFavorite
            // builder.Property(si => si.IsFavorite)
            //     .HasDefaultValue(false);

        }
    }
}
