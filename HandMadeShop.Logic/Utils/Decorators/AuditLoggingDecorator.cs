using System;
using System.Text.Json;
using System.Threading.Tasks;
using HandMadeShop.Logic.Interfaces;
using Microsoft.Extensions.Logging;

namespace HandMadeShop.Logic.Utils.Decorators
{
    public sealed class AuditLoggingDecorator<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _handler;
        private readonly ILogger<ICommandHandler<TCommand>> _logger;

        public AuditLoggingDecorator(ICommandHandler<TCommand> handler, ILogger<ICommandHandler<TCommand>> logger)
        {
            _logger = logger;
            _handler = handler;
        }

        public Task<CommandResult> Handle(TCommand command)
        {
            try
            {
                var commandJson = JsonSerializer.Serialize(command);
                _logger.LogInformation(
                    $"Command handler of type {command.GetType().Name} processing payload: {commandJson}");
                return _handler.Handle(command);
            }
            catch (Exception e)
            {
                _logger.LogError(
                    $"Command handler of type {command.GetType().Name} error. Reason: {JsonSerializer.Serialize(e)}");
                throw;
            }
        }
    }
}