using System.Threading.Tasks;
using HandMadeShop.Logic.Interfaces;
using HandMadeShop.Logic.Utils;

namespace HandMadeShop.Logic.Domain.DeliveryMethod.Commands
{
    public class CreateDeliveryMethodCommandHandler : ICommandHandler<CreateDeliveryMethodCommand>
    {
        public CreateDeliveryMethodCommandHandler()
        {
        }

        public async Task<CommandResult> Handle(CreateDeliveryMethodCommand command)
        {
            return await Task.FromResult(CommandResult.Ok());
        }
    }
}