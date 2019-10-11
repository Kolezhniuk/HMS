using System.Threading.Tasks;
using HandMadeShop.Logic.Utils;

namespace HandMadeShop.Logic.Interfaces
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Task<CommandResult> Handle(TCommand command);
    }
}