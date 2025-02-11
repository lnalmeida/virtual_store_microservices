using Microsoft.EntityFrameworkCore;
using vstore.ProductApi.Core.Domain.Entities;
using vstore.ProductApi.Core.Domain.Interfaces.Repositories;
using vstore.ProductApi.Infrastructure.Context;

namespace vstore.ProductApi.Infrastructure.Repositories;

public class ProductRepository(ProductContext productContext) : IProductRepository
{
    private readonly ProductContext _productContext = productContext;

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _productContext.Products.AsNoTracking().ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        var product = await _productContext.Products
        .AsNoTracking()
        .FirstOrDefaultAsync(p => p.ProductId == id);

        if (product == null)
        {
            return null!;
        }
        return product;
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        await _productContext.Products.AddAsync(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateProductAsync(int id, Product product)
    {
        var productToUpdate = await _productContext.Products
        .FirstOrDefaultAsync(p => p.ProductId == id);

        if (productToUpdate == null)
        {
            return null!;
        }

        productToUpdate.Name = product.Name;
        productToUpdate.Description = product.Description;
        productToUpdate.Price = product.Price;
        productToUpdate.ImageUrl = product.ImageUrl;
        productToUpdate.Stock = product.Stock;
        productToUpdate.CategoryId = product.CategoryId;

        _productContext.Products.Update(productToUpdate);

        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var productToDelete = await _productContext.Products
        .FirstOrDefaultAsync(p => p.ProductId == id);

        if (productToDelete == null)
        {
            return false;
        }
        _productContext.Products.Remove(productToDelete);
        await _productContext.SaveChangesAsync();
        return true;
    }
}
