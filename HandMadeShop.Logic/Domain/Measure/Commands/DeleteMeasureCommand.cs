using System.Threading.Tasks;
using HandMadeShop.Logic.Interfaces;
using HandMadeShop.Logic.Utils;
using Raven.Client.Documents.Session;

namespace HandMadeShop.Logic.Domain.Measure.Commands
{
    public sealed class DeleteMeasureCommand : ICommand
    {
        public DeleteMeasureCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public sealed class DeleteMeasureCommandHandler : ICommandHandler<DeleteMeasureCommand>
        {
            private readonly IAsyncDocumentSession _session;

            public DeleteMeasureCommandHandler(IAsyncDocumentSession session)
            {
                _session = session;
            }

            public async Task<CommandResult> Handle(DeleteMeasureCommand command)
            {
                _session.Delete(command.Id);
                await _session.SaveChangesAsync();
                return CommandResult.Ok();
            }
        }
    }
}