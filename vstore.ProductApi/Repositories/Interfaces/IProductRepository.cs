using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vstore.ProductApi.Models;

namespace vstore.ProductApi.Repositories.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task<Product> CreateProductAsync(Product Product);
    Task<Product> UpdateProductAsync(int id, Product product);
    Task<bool> DeleteProductAsync(int id);
}
