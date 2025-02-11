using System.Net;
using AutoMapper;
using vstore.ProductApi.Core.Domain.Entities;
using vstore.ProductApi.Core.Domain.Interfaces.Repositories;
using vstore.ProductApi.Core.Domain.Interfaces.Services;
using vstore.ProductApi.Core.DTOs;
using vstore.ProductApi.Core.Exceptions;

namespace vstore.ProductApi.Core.Services;

public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
    {
        try
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            if (categories == null)
            {
                throw new CustomException("Categories not found", HttpStatusCode.NotFound);
            }
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }
        catch (Exception ex)
        {
            throw new CustomException(ex.Message, HttpStatusCode.InternalServerError);
        }
    }

    public async Task<IEnumerable<CategoryDto>> GetCategoriesWithProductsAsync()
    {
        try
        {
            var categories = await _categoryRepository.GetCategoriesWithProductsAsync();
            if (categories == null)
            {
                throw new CustomException("Categories not found", HttpStatusCode.NotFound);
            }
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }
        catch (Exception ex)
        {
            throw new CustomException(ex.Message, HttpStatusCode.InternalServerError);
        }
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(int id)
    {
        try
        {
            var categoryById = await _categoryRepository.GetCategoryByIdAsync(id);
            if (categoryById == null)
            {
                throw new CustomException("Category not found", HttpStatusCode.NotFound);
            }
            return _mapper.Map<CategoryDto>(categoryById);
        }
        catch (Exception ex)
        {
            throw new CustomException(ex.Message, HttpStatusCode.InternalServerError);
        }
    }

    public async Task<CategoryDto> GetCategoryByNameAsync(string name)
    {
        try
        {
            var categoryByName = await _categoryRepository.GetCategoryByNameAsync(name);
            if (categoryByName == null)
            {
                throw new CustomException("Category not found", HttpStatusCode.NotFound);
            }
            return _mapper.Map<CategoryDto>(categoryByName);
        }
        catch (Exception ex)
        {
            throw new CustomException(ex.Message, HttpStatusCode.InternalServerError);
        }
    }

    public async Task<CategoryDto> GetCategoryByIdWithProductsAsync(int id)
    {
        try
        {
            var categoryByIdWithProducts = await _categoryRepository.GetCategoryByIdWithProductsAsync(id);
            if (categoryByIdWithProducts == null)
            {
                throw new CustomException("Category not found", HttpStatusCode.NotFound);
            }
            return _mapper.Map<CategoryDto>(categoryByIdWithProducts);
        }
        catch (Exception ex)
        {
            throw new CustomException(ex.Message, HttpStatusCode.InternalServerError);
        }
    }

    public async Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto)
    {
        try
        {
            var categoryByName = await _categoryRepository.GetCategoryByNameAsync(categoryDto.Name);
            if (categoryByName != null)
            {
                throw new CustomException("Category already exists", HttpStatusCode.BadRequest);
            }
            await _categoryRepository.CreateCategoryAsync(_mapper.Map<Category>(categoryDto));
            return categoryDto;

        }
        catch (Exception ex)
        {
            throw new CustomException(ex.Message, HttpStatusCode.InternalServerError);
        }
    }

    public async Task<CategoryDto> UpdateCategoryAsync(int id, CategoryDto categoryDto)
    {
        try
        {
            var categoryToUpdate = await _categoryRepository.UpdateCategoryAsync(id, _mapper.Map<Category>(categoryDto));
            if (categoryToUpdate == null)
            {
                throw new CustomException("Category not found", HttpStatusCode.NotFound);
            }
            return _mapper.Map<CategoryDto>(categoryToUpdate);
        }
        catch (Exception ex)
        {
            throw new CustomException(ex.Message, HttpStatusCode.InternalServerError);
        }
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        try 
        {
            var categoryToDelete = await _categoryRepository.DeleteCategoryAsync(id);
            if (categoryToDelete.Equals(null))
            {
                throw new CustomException("Category not found", HttpStatusCode.NotFound);
            }
            return true;
        }
        catch (Exception ex)
        {
            throw new CustomException(ex.Message, HttpStatusCode.InternalServerError);
        }
    }
}
