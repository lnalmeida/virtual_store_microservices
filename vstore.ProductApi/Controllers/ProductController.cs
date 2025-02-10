using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using vstore.ProductApi.Services.Interfaces;

namespace vstore.ProductApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(IProductService productService, ILogger<ProductController> logger) : Controller
    {
        private readonly ILogger<ProductController> _logger = logger;
        private readonly IProductService _productService = productService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            _logger.LogInformation("Getting all products");
            var products = await _productService.GetProductsAsync();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            _logger.LogInformation($"Getting product with id: {id}");
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] ProductDto product)
        {
            _logger.LogInformation($"Creating product with name: {product.Name}");
            var createdProduct = await _productService.CreateProductAsync(product);
            if (createdProduct == null)
            {
                return BadRequest();
            }
            return Ok(createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int id, [FromBody] ProductDto product)
        {
            _logger.LogInformation($"Updating product with id: {id}");
            var updatedProduct = await _productService.UpdateProductAsync(id, product);
            if (updatedProduct == null)
            {
                return BadRequest();
            }
            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            _logger.LogInformation($"Deleting product with id: {id}");
            var deleted = await _productService.DeleteProductAsync(id);
            if (!deleted)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}