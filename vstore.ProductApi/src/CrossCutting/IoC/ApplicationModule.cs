using vstore.ProductApi.Core.Domain.Interfaces.Services;
using vstore.ProductApi.Core.Services;

namespace vstore.ProductApi.CrossCutting.IoC;

    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }

