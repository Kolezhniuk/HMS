using HandMadeShop.Logic.Interfaces;

namespace HandMadeShop.Logic.Domain.Product.Commands
{
    public sealed class AddProductCommand : ICommand
    {
        public AddProductCommand(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }
        public double Price { get; }
        public string PhotoUrl { get; }
    }
}