using vstore.ProductApi.Api.Mapping;

namespace vstore.ProductApi.CrossCutting.IoC;

public static class AutoMapperModule
{
    public static IServiceCollection AddAutoMapperModule(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfileConfig));
        return services;
    }
}