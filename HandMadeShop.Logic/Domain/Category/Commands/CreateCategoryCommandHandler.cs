using System.Threading.Tasks;
using HandMadeShop.Logic.Interfaces;
using HandMadeShop.Logic.Utils;

namespace HandMadeShop.Logic.Domain.Category.Commands
{
    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand>
    {
        public CreateCategoryCommandHandler()
        {
        }

        public async Task<CommandResult> Handle(CreateCategoryCommand command)
        {
            return await Task.FromResult(CommandResult.Ok());
        }
    }
}