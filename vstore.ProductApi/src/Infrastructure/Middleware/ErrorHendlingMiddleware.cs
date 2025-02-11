using System.Net;
using System.Text.Json;
using vstore.ProductApi.Core.Exceptions;

namespace vstore.ProductApi.Infrastructure.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    //private readonly ILogger _logger;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;
    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _logger = logger;
        _next = next;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exp)
        {
            _logger.LogError($"An unhandled exception has occurred:{exp.GetBaseException}");
            await HandleExceptionAsync(httpContext, exp);
        }
    }
    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exp)
    {
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        httpContext.Response.ContentType = "application/json";
        await httpContext.Response.WriteAsync(new ErrorDetails
        {
            StatusCode = httpContext.Response.StatusCode,
            Message = "Internal Server Error from Custom Middleware"
        }.ToString());
    }
}

internal class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}