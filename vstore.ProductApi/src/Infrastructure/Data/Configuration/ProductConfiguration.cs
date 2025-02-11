using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using vstore.ProductApi.Core.Domain.Entities;

namespace vstore.ProductApi.Infrastructure.Data.Configuration;

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(255);
            builder.Property(p => p.Price).HasPrecision(12,2).IsRequired();
            builder.Property(p => p.ImageUrl).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Stock).IsRequired();
        }
}
