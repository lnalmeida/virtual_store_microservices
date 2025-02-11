namespace vstore.ProductApi.CrossCutting.Utils.Extensions;

public static class SwaggerSetupExtension
{
    public static IApplicationBuilder UseSwaggerSetup(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}