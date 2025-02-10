using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using vstore.ProductApi.Models;

namespace vstore.ProductApi.Mapping;

public class MappingProfileConfig : Profile
{
    public MappingProfileConfig()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
