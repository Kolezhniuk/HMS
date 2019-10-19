using HandMadeShop.Logic.Interfaces;

namespace HandMadeShop.Logic.Domain.Measure.Commands
{
    public sealed class DeleteMeasureCommand : ICommand
    {
        public DeleteMeasureCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}