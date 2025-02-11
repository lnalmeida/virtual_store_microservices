using vstore.ProductApi.Infrastructure.Middleware;

namespace vstore.ProductApi.CrossCutting.Utils.Extensions;
public static class ErrorHandlingMiddlewareExtensions
{
    public static void UseErrorHandling(
        this IApplicationBuilder app)
    {
         app.UseMiddleware<ErrorHandlingMiddleware>();
    }
}