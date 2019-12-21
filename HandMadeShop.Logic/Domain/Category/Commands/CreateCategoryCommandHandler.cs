using System.Threading.Tasks;
using HandMadeShop.Logic.Interfaces;
using HandMadeShop.Logic.Utils;

namespace HandMadeShop.Infrastrucutre.Domain.Category.Commands
{
    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand>
    {
        public async Task<CommandResult> Handle(CreateCategoryCommand command)
        {
            return await Task.FromResult(CommandResult.Ok());
        }
    }
}