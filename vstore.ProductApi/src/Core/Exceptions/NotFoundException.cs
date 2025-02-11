using System.Net;

namespace vstore.ProductApi.Core.Exceptions;

public class NotFoundException : CustomException
{
    public NotFoundException(string message)
        : base(message, HttpStatusCode.NotFound, "NotFound")
    {
    }
}