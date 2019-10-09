using HandMadeShop.Logic.Interfaces;
using HandMadeShop.Logic.Utils;

namespace HandMadeShop.Logic.Domain.DeliveryMethod.Commands
{
    public class CreateDeliveryMethodHandler : ICommandHandler<CreateDeliveryMethodCommand>
    {
        public CreateDeliveryMethodHandler()
        {
        }

        public CommandResult Handle(CreateDeliveryMethodCommand command)
        {
            return CommandResult.Ok();
        }
    }
}