using HandMadeShop.Domain.Utils;

namespace HandMadeShop.Domain.Interfaces
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        CommandResult Handle(TCommand command);
    }
}