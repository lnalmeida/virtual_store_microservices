using AutoMapper;
using vstore.ProductApi.Core.Domain.Entities;
using vstore.ProductApi.Core.Domain.Interfaces.Repositories;
using vstore.ProductApi.Core.Domain.Interfaces.Services;
using vstore.ProductApi.Core.DTOs;

namespace vstore.ProductApi.Core.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }


    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        var products = await _productRepository.GetProductsAsync();
        if(products == null)
        {
            throw new Exception("Products not found");
        }
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

        public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        var productById = await _productRepository.GetProductByIdAsync(id);
        if(productById == null)
        {
            throw new Exception("Product not found");
        }
        return _mapper.Map<ProductDto>(productById);
    }

    public async Task<ProductDto> CreateProductAsync(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        var createdProduct = await _productRepository.CreateProductAsync(product);
        if( createdProduct.Equals(null))
        {
            throw new Exception("Product not created");
        }
        return _mapper.Map<ProductDto>(createdProduct);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var productToDelete = await _productRepository.DeleteProductAsync(id);
        if(productToDelete.Equals(null))
        {
            throw new Exception("Product not deleted");
        }
        return true;
    }

    public async Task<ProductDto> UpdateProductAsync(int id, ProductDto productDto)
    {
        var productToUpdate = await _productRepository.UpdateProductAsync(id, _mapper.Map<Product>(productDto));
        if(productToUpdate.Equals(null))
        {
            throw new Exception("Product not updated");
        }
        return _mapper.Map<ProductDto>(productToUpdate);
    }
}
