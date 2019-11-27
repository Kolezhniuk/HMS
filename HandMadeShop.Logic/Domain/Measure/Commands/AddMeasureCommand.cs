using HandMadeShop.Logic.Interfaces;

namespace HandMadeShop.Logic.Domain.Measure.Commands
{
    public sealed class AddMeasureCommand : ICommand
    {
        public AddMeasureCommand(string name, int position)
        {
            Name = name;
            Position = position;
        }

        public string Name { get; }
        public int Position { get; }
    }
}