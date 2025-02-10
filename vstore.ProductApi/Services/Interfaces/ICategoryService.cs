using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vstore.ProductApi.Services.Interfaces;

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task<IEnumerable<CategoryDto>> GetCategoriesWithProductsAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<CategoryDto> GetCategoryByNameAsync(string name);
        Task<CategoryDto> GetCategoryByIdWithProductsAsync(int id);
        Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto);
        Task<CategoryDto> UpdateCategoryAsync(int id, CategoryDto categoryDto);
        Task<bool> DeleteCategoryAsync(int id);
    
    }
