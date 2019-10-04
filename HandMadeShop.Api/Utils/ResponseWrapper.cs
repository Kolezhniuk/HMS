using System;

namespace HandMadeShop.Api.Utils
{
    public class ResponseWrapper<T>
    {
        protected internal ResponseWrapper(T result, string errorMessage)
        {
            Result = result;
            ErrorMessage = errorMessage;
            TimeGenerated = DateTime.UtcNow;
        }

        public T Result { get; }
        public string ErrorMessage { get; }
        public DateTime TimeGenerated { get; }
    }

    public sealed class ResponseWrapper : ResponseWrapper<string>
    {
        private ResponseWrapper(string errorMessage)
            : base(null, errorMessage)
        {
        }

        public static ResponseWrapper<T> Ok<T>(T result)
        {
            return new ResponseWrapper<T>(result, null);
        }

        public static ResponseWrapper Ok()
        {
            return new ResponseWrapper(null);
        }

        public static ResponseWrapper Error(string errorMessage)
        {
            return new ResponseWrapper(errorMessage);
        }
    }
}