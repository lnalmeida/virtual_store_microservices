using Microsoft.AspNetCore.Mvc;
using vstore.ProductApi.Core.Domain.Interfaces.Services;
using vstore.ProductApi.Core.DTOs;

namespace vstore.ProductApi.Api.Controllers;

[Route("[controller]")]
public class CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger) : Controller
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories()
    {
        logger.LogInformation("Getting all categories");
        var categories = await categoryService.GetCategoriesAsync();
        if (categories == null)
        {
            return NotFound();
        }

        return Ok(categories);
    }

    [HttpGet("withproducts")]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategoriesWithProducts()
    {
        logger.LogInformation("Getting all categories with products");
        var categories = await categoryService.GetCategoriesWithProductsAsync();
        if (categories == null)
        {
            return NotFound();
        }

        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
    {
        logger.LogInformation($"Getting category with id: {id}");
        var category = await categoryService.GetCategoryByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpGet("byname/{name}")]
    public async Task<ActionResult<CategoryDto>> GetCategoryByName(string name)
    {
        logger.LogInformation($"Getting category with name: {name}");
        var category = await categoryService.GetCategoryByNameAsync(name);
        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpGet("{id}/products")]
    public async Task<ActionResult<CategoryDto>> GetCategoryByIdWithProducts(int id)
    {
        logger.LogInformation($"Getting category with id: {id} and products");
        var category = await categoryService.GetCategoryByIdWithProductsAsync(id);
        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDto>> CreateCategory([FromBody] CategoryDto category)
    {
        logger.LogInformation($"Creating category with name: {category.Name}");
        var createdCategory = await categoryService.CreateCategoryAsync(category);
        if (createdCategory == null)
        {
            return BadRequest();
        }

        return Ok(createdCategory);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CategoryDto>> UpdateCategory(int id, [FromBody] CategoryDto category)
    {
        logger.LogInformation($"Updating category with id: {id}");
        var updatedCategory = await categoryService.UpdateCategoryAsync(id, category);
        if (updatedCategory == null)
        {
            return BadRequest();
        }

        return Ok(updatedCategory);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteCategory(int id)
    {
        logger.LogInformation($"Deleting category with id: {id}");
        var deletedCategory = await categoryService.DeleteCategoryAsync(id);
        if (deletedCategory == false)
        {
            return BadRequest();
        }

        return Ok(deletedCategory);
    }
}