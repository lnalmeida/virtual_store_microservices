namespace vstore.ProductApi.CrossCutting.IoC;

public static class CustomModule
{
    public static IServiceCollection AddCustomModule(this IServiceCollection services)
    {
        services.AddAutoMapperModule();
        services.AddSwaggerModule();
        return services;
    }
}