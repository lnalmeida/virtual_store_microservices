
using vstore.ProductApi.Core.Domain.Entities;

namespace vstore.ProductApi.Core.DTOs;

public class CategoryDto
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Product> Products { get; set; } = new List<Product>();
}