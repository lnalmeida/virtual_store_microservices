using Microsoft.AspNetCore.Mvc;
using vstore.ProductApi.Services.Interfaces;

namespace vstore.ProductApi.Controllers
{
    [Route("[controller]")]
    public class CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger) : Controller
    {
        private readonly ICategoryService _categoryService = categoryService;
        private readonly ILogger<CategoryController> _logger = logger;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories()
        {
            _logger.LogInformation("Getting all categories");
            var categories = await _categoryService.GetCategoriesAsync();
            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        [HttpGet("withproducts")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategoriesWithProducts()
        {
            _logger.LogInformation("Getting all categories with products");
            var categories = await _categoryService.GetCategoriesWithProductsAsync();
            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
        {
            _logger.LogInformation($"Getting category with id: {id}");
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpGet("byname/{name}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryByName(string name)
        {
            _logger.LogInformation($"Getting category with name: {name}");
            var category = await _categoryService.GetCategoryByNameAsync(name);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpGet("{id}/products")]
        public async Task<ActionResult<CategoryDto>> GetCategoryByIdWithProducts(int id)
        {
            _logger.LogInformation($"Getting category with id: {id} and products");
            var category = await _categoryService.GetCategoryByIdWithProductsAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory([FromBody] CategoryDto category)
        {
            _logger.LogInformation($"Creating category with name: {category.Name}");
            var createdCategory = await _categoryService.CreateCategoryAsync(category);
            if (createdCategory == null)
            {
                return BadRequest();
            }
            return Ok(createdCategory);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDto>> UpdateCategory(int id, [FromBody] CategoryDto category)
        {
            _logger.LogInformation($"Updating category with id: {id}");
            var updatedCategory = await _categoryService.UpdateCategoryAsync(id, category);
            if (updatedCategory == null)
            {
                return BadRequest();
            }
            return Ok(updatedCategory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCategory(int id)
        {
            _logger.LogInformation($"Deleting category with id: {id}");
            var deletedCategory = await _categoryService.DeleteCategoryAsync(id);
            if (deletedCategory == false)
            {
                return BadRequest();
            }
            return Ok(deletedCategory);
        }
    }
}