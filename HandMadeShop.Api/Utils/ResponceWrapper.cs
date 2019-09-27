using System;

namespace HandMadeShop.Api.Utils
{
    public class ResponceWrapper<T>
    {
        public T Result { get; }
        public string ErrorMessage { get; }
        public DateTime TimeGenerated { get; }

        protected internal ResponceWrapper(T result, string errorMessage)
        {
            Result = result;
            ErrorMessage = errorMessage;
            TimeGenerated = DateTime.UtcNow;
        }
    }
    public sealed class ResponceWrapper : ResponceWrapper<string>
    {
        private ResponceWrapper(string errorMessage)
            : base(null, errorMessage)
        {
        }

        public static ResponceWrapper<T> Ok<T>(T result)
        {
            return new ResponceWrapper<T>(result, null);
        }

        public static ResponceWrapper Ok()
        {
            return new ResponceWrapper(null);
        }

        public static ResponceWrapper Error(string errorMessage)
        {
            return new ResponceWrapper(errorMessage);
        }
    }
}