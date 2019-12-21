using HandMadeShop.Logic.Interfaces;

namespace HandMadeShop.Infrastrucutre.Domain.DeliveryMethod.Commands
{
    public sealed class CreateDeliveryMethodCommand : ICommand
    {
        public CreateDeliveryMethodCommand(string name, int position)
        {
            Name = name;
            Position = position;
        }

        public string Name { get; }
        public int Position { get; }
    }
}