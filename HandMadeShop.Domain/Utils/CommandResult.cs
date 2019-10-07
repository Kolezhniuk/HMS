namespace HandMadeShop.Domain.Utils
{
    public class CommandResult
    {
        private CommandResult(bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; private set; }

        public string Error { get; private set; }

        public static CommandResult Ok()
        {
            return new CommandResult(true, null);
        }

        public static CommandResult Fail(string errorMessage)
        {
            return new CommandResult(false, errorMessage);
        }
    }
}