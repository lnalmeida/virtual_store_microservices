using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vstore.ProductApi.Models;

namespace vstore.ProductApi.Repositories.Interfaces;

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
