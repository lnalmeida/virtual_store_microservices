using Microsoft.EntityFrameworkCore;
using vstore.ProductApi.Infrastructure.Context;
using vstore.ProductApi.Infrastructure.Middleware;

namespace vstore.ProductApi.CrossCutting.IoC;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ProductContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        
        return services;
    }
}
