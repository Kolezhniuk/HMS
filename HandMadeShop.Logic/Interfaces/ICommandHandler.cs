using HandMadeShop.Logic.Utils;

namespace HandMadeShop.Logic.Interfaces
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        CommandResult Handle(TCommand command);
    }
}