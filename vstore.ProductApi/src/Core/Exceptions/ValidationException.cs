using System.Net;

namespace vstore.ProductApi.Core.Exceptions;

public class ValidationException : CustomException
{
    public ValidationException(string message)
        : base(message, HttpStatusCode.UnprocessableEntity, "ValidationError")
    {
    }
}