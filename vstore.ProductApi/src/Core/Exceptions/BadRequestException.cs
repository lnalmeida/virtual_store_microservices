using System.Net;

namespace vstore.ProductApi.Core.Exceptions;

public class BadRequestException : CustomException
{
    public BadRequestException(string message)
        : base(message, HttpStatusCode.BadRequest, "BadRequest")
    {
    }
}