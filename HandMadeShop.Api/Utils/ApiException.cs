using System;
using System.Net;

namespace HandMadeShop.Api.Utils
{
    public class ApiException : Exception
    {
        public ApiException(HttpStatusCode status)
        {
            Status = status;
        }

        public ApiException(HttpStatusCode status, string message) : base(message)
        {
            Status = status;
        }

        public HttpStatusCode Status { get; set; }
    }
}