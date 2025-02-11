using vstore.ProductApi.Core.Domain.Entities;

namespace vstore.ProductApi.Core.Domain.Interfaces.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<IEnumerable<Category>> GetCategoriesWithProductsAsync();
    Task<Category> GetCategoryByIdAsync(int id);
    Task<Category> GetCategoryByNameAsync(string name);
    Task<Category> GetCategoryByIdWithProductsAsync(int id);
    Task<Category> CreateCategoryAsync(Category categoryDto);
    Task<Category> UpdateCategoryAsync(int id, Category categoryDto);
    Task<bool> DeleteCategoryAsync(int id);
}