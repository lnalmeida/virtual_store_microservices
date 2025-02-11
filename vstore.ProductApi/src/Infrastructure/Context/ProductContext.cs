using Microsoft.EntityFrameworkCore;
using vstore.ProductApi.Core.Domain.Entities;
using vstore.ProductApi.Infrastructure.Data.Configuration;

namespace vstore.ProductApi.Infrastructure.Context;

public class ProductContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
    
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
    }

}