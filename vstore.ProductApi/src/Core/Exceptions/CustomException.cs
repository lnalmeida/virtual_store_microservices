using System.Net;

namespace vstore.ProductApi.Core.Exceptions;

public class CustomException : Exception
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorType { get; }
    public string Details { get; }

    public CustomException(
        string message,
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
        string errorType = null!,
        string details = null!,
        Exception innerException = null!)
        : base(message, innerException)
    {
        StatusCode = statusCode;
        ErrorType = errorType;
        Details = details;
    }
}