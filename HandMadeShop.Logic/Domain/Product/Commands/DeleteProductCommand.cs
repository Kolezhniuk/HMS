using System.Threading.Tasks;
using HandMadeShop.Logic.Interfaces;
using HandMadeShop.Logic.Utils;
using Raven.Client.Documents.Session;

namespace HandMadeShop.Logic.Domain.Product.Commands
{
    public sealed class DeleteProductCommand : ICommand
    {
        public DeleteProductCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
        {
            private readonly IAsyncDocumentSession _session;

            public DeleteProductCommandHandler(IAsyncDocumentSession session)
            {
                _session = session;
            }

            public async Task<CommandResult> Handle(DeleteProductCommand command)
            {
                _session.Delete(command.Id);

                await _session.SaveChangesAsync();

                return CommandResult.Ok();
            }
        }
    }
}