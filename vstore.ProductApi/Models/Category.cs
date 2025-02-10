namespace vstore.ProductApi.Models;

public class Category
{
    public Category()
    {

    }
    public Category(string name)
    {
        Name = name;
    }

    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
