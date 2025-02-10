using AutoMapper;
using vstore.ProductApi.Models;
using vstore.ProductApi.Repositories.Interfaces;
using vstore.ProductApi.Services.Interfaces;

namespace vstore.ProductApi.Services;

public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
    {
        var categories = await _categoryRepository.GetCategoriesAsync();
        if (categories == null)
        {
            throw new Exception("Categories not found");
        }
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);

    }

    public async Task<IEnumerable<CategoryDto>> GetCategoriesWithProductsAsync()
    {
        var categories = await _categoryRepository.GetCategoriesWithProductsAsync();
        if (categories == null)
        {
            throw new Exception("Categories not found");
        }
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(int id)
    {
        var categoryById = await _categoryRepository.GetCategoryByIdAsync(id);
        if (categoryById == null)
        {
            throw new Exception("Category not found");
        }
        return _mapper.Map<CategoryDto>(categoryById);
    }

    public async Task<CategoryDto> GetCategoryByNameAsync(string name)
    {
        var categoryByName = await _categoryRepository.GetCategoryByNameAsync(name);
        if (categoryByName == null)
        {
            throw new Exception("Category not found");
        }
        return _mapper.Map<CategoryDto>(categoryByName);
    }

    public async Task<CategoryDto> GetCategoryByIdWithProductsAsync(int id)
    {
        var categoryByIdWithProducts = await _categoryRepository.GetCategoryByIdWithProductsAsync(id);
        if (categoryByIdWithProducts == null)
        {
            throw new Exception("Category not found");
        }
        return _mapper.Map<CategoryDto>(categoryByIdWithProducts);
    }

    public async Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto)
    {
        await _categoryRepository.CreateCategoryAsync(_mapper.Map<Category>(categoryDto));
        return categoryDto;
    }

    public async Task<CategoryDto> UpdateCategoryAsync(int id, CategoryDto categoryDto)
    {
        var categoryToUpdate = await _categoryRepository.UpdateCategoryAsync(id, _mapper.Map<Category>(categoryDto));
        if (categoryToUpdate.Equals(null))
        {
            throw new Exception("Category not updated");
        }
        return _mapper.Map<CategoryDto>(categoryToUpdate);
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var categoryToDelete = await _categoryRepository.DeleteCategoryAsync(id);
        if (categoryToDelete.Equals(null))
        {
            throw new Exception("Category not deleted");
        }
        return true;
    }
}
