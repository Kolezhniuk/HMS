using CSharpFunctionalExtensions;

namespace HandMadeShop.Domain.Interfaces
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }
}