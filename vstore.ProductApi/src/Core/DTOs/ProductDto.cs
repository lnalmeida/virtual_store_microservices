
namespace vstore.ProductApi.Core.DTOs;

public class ProductDto
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public long Stock { get; set; }
    public int? CategoryId { get; set; }
}