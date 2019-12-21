namespace HandMadeShop.Logic.Utils
{
    public class CommandResult
    {
        private CommandResult(bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        private CommandResult(bool isSuccess, string payload, string error)
        {
            IsSuccess = isSuccess;
            Payload = payload;
            Error = error;
        }

        public bool IsSuccess { get; }

        public string Error { get; }
        public string Payload { get; }

        public static CommandResult Ok()
        {
            return new CommandResult(true, null);
        }

        public static CommandResult Ok(string payload)
        {
            return new CommandResult(true, payload, null);
        }

        public static CommandResult Fail(string errorMessage)
        {
            return new CommandResult(false, errorMessage);
        }
    }
}