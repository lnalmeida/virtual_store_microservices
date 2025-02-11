using Microsoft.AspNetCore.Mvc;
using vstore.ProductApi.Core.Domain.Interfaces.Services;
using vstore.ProductApi.Core.DTOs;

namespace vstore.ProductApi.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(IProductService productService, ILogger<ProductController> logger) : Controller
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
    {
        logger.LogInformation("Getting all products");
        var products = await productService.GetProductsAsync();
        if (products == null)
        {
            return NotFound();
        }

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProductById(int id)
    {
        logger.LogInformation($"Getting product with id: {id}");
        var product = await productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] ProductDto product)
    {
        logger.LogInformation($"Creating product with name: {product.Name}");
        var createdProduct = await productService.CreateProductAsync(product);
        if (createdProduct == null)
        {
            return BadRequest();
        }

        return Ok(createdProduct);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductDto>> UpdateProduct(int id, [FromBody] ProductDto product)
    {
        logger.LogInformation($"Updating product with id: {id}");
        var updatedProduct = await productService.UpdateProductAsync(id, product);
        if (updatedProduct == null)
        {
            return BadRequest();
        }

        return Ok(updatedProduct);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        logger.LogInformation($"Deleting product with id: {id}");
        var deleted = await productService.DeleteProductAsync(id);
        if (!deleted)
        {
            return BadRequest();
        }

        return Ok();
    }
}