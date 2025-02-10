using System.Text.Json.Serialization;

namespace vstore.ProductApi.Models;

public class Product
{
    public Product()
    {
    }

    public Product(int productId, string name, string description, decimal price, string imageUrl, long stock, int? categoryId, Category? category)
    {
        ProductId = productId;
        Name = name;
        Description = description;
        Price = price;
        ImageUrl = imageUrl;
        Stock = stock;
        CategoryId = categoryId;
        Category = category;
    }


    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public long Stock { get; set; }
    public int? CategoryId { get; set; }
    [JsonIgnore]
    public Category? Category { get; set; }
}