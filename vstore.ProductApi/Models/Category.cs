using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vstore.ProductApi.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}