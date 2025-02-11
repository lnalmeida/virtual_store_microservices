using Microsoft.EntityFrameworkCore;
using vstore.ProductApi.Core.Domain.Entities;
using vstore.ProductApi.Core.Domain.Interfaces.Repositories;
using vstore.ProductApi.Infrastructure.Context;

namespace vstore.ProductApi.Infrastructure.Repositories;

public class CategoryRepository(ProductContext productContext) : ICategoryRepository
{
    private readonly ProductContext _productContext = productContext;

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _productContext.Categories
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Category>> GetCategoriesWithProductsAsync()
    {
        return await _productContext.Categories
            .AsSplitQuery()
            .Include(c => c.Products)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        var category = await _productContext.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.CategoryId == id);

        if (category == null)
        {
            return null!;
        }
        return category;
    }

    public async Task<Category> GetCategoryByNameAsync(string name)
    {
        var category = await _productContext.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Name.Contains(name));

        if (category == null)
        {
            return null!;
        }

        return category;
    }


    public async Task<Category> CreateCategoryAsync(Category category)
    {
        await _productContext.Categories.AddAsync(category);
        await _productContext.SaveChangesAsync();
        return category;
    }
    public async Task<Category> UpdateCategoryAsync(int id, Category category)
    {
        var categoryToUpdate = await _productContext.Categories
            .FirstOrDefaultAsync(c => c.CategoryId == id);

        if (categoryToUpdate == null)
        {
            return null!;
        }

        categoryToUpdate.Name = category.Name;

        _productContext.Categories.Update(categoryToUpdate);

        await _productContext.SaveChangesAsync();
        return categoryToUpdate;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var categoryToDelete = await _productContext.Categories
            .FirstOrDefaultAsync(c => c.CategoryId == id);

        if (categoryToDelete == null)
        {
            return false;
        }
        _productContext.Categories.Remove(categoryToDelete);
        await _productContext.SaveChangesAsync();
        return true;
    }

    public async Task<Category> GetCategoryByIdWithProductsAsync(int id)
    {
        var category = await _productContext.Categories
            .Include(c => c.Products.Where(p => p.CategoryId == id))
            .AsSplitQuery()
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.CategoryId == id);

        if (category == null)
        {
            throw new Exception("Category not found");
        }

        return category;
    }
}