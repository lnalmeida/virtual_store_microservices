using AutoMapper;
using vstore.ProductApi.Core.Domain.Entities;
using vstore.ProductApi.Core.DTOs;

namespace vstore.ProductApi.Api.Mapping;

public class MappingProfileConfig : Profile
{
    public MappingProfileConfig()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}