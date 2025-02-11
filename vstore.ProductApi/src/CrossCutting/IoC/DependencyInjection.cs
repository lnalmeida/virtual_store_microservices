namespace vstore.ProductApi.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCustomModule();
        services.AddDomainModule();
        services.AddApplicationModule();
        services.AddInfrastructureModule(configuration);
        services.AddApiModule();
        
        return services;
    }
}