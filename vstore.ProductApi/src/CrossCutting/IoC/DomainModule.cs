using vstore.ProductApi.Core.Domain.Interfaces.Repositories;
using vstore.ProductApi.Infrastructure.Repositories;

namespace vstore.ProductApi.CrossCutting.IoC;

public static class DomainModule
{
    public static IServiceCollection AddDomainModule(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }
}
