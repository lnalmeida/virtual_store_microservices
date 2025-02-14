using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using vstore.ProductApi.Core.Domain.Entities;

namespace vstore.ProductApi.Infrastructure.Data.Configuration;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
            builder.HasMany(c => c.Products).WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
        }

    }