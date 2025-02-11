namespace vstore.ProductApi.CrossCutting.IoC;

public static class SwaggerModule
{
    public static IServiceCollection AddSwaggerModule(this IServiceCollection services)
    {
        services.AddSwaggerGen();

        return services;
    }
}