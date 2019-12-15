using System.Net;

namespace HandMadeShop.Api.Utils
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
            Success = true;
            Status = HttpStatusCode.OK;
        }

        public ApiResponse(HttpStatusCode status, string message = null)
        {
            Status = status;
            Message = message;
        }

        public T Data { get; set; }
        public bool Success { get; set; }
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
    }
}