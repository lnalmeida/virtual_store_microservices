using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vstore.ProductApi.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProductsAsync();
    Task<ProductDto> GetProductByIdAsync(int id);
    Task<ProductDto> CreateProductAsync(ProductDto productDto);
    Task<ProductDto> UpdateProductAsync(int id, ProductDto productDto);
    Task<bool> DeleteProductAsync(int id);

}
