namespace vstore.ProductApi.CrossCutting.IoC;

public static class ApiModule
{
    public static IServiceCollection AddApiModule(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        return services;
    }
}