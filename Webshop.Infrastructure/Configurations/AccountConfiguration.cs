using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Webshop.Domain.Entities;

namespace Webshop.Infrastructure.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(si => si.Id);

            builder.Property(si => si.Username)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(si => si.Password)
                .IsRequired();

            builder.Property(si => si.Role)
                .IsRequired()
                .HasDefaultValue("User");
        }
    }
}
