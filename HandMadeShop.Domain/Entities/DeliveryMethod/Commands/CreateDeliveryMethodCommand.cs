
using HandMadeShop.Domain.Interfaces;

namespace HandMadeShop.Domain.Entities.DeliveryMethod.Commands
{
  public sealed class CreateDeliveryMethodCommand : ICommand
  {
    public string Name { get; }
    public int Position { get; }

    public CreateDeliveryMethodCommand(string name, int position)
    {
      Name = name;
      Position = position;
    }
  }
}