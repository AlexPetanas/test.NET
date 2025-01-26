namespace DesafioNET.Models
{
    public class ApiException
    {
        public int StatusCode { get; }

        public string? Message { get; }

        public string? Detail { get; }
        public ApiException(int statusCode,string? message ,string? detail = null)
        {
            StatusCode = statusCode;
            Message = message;
            Detail = detail;
        }
    }
}
