namespace vstore.ProductApi.Core.Exceptions;

public class ErrorResponse
{
    public string Message { get; set; }
    public string Details { get; set; }
    public string Type { get; set; }
    public DateTime Timestamp { get; set; }

    public ErrorResponse(string message, string type = null!, string details = null!)
    {
        Message = message;
        Type = type ?? "Error";
        Details = details;
        Timestamp = DateTime.UtcNow;
    }
}