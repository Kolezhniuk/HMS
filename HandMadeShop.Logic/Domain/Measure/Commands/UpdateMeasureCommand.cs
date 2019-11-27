using HandMadeShop.Logic.Interfaces;

namespace HandMadeShop.Logic.Domain.Measure.Commands
{
    public sealed class UpdateMeasureCommand : ICommand
    {
        public UpdateMeasureCommand(string id, string name, int position)
        {
            Id = id;
            Name = name;
            Position = position;
        }

        public string Id { get; }
        public string Name { get; }
        public int Position { get; }
    }
}