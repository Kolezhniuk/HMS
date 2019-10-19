using System.Threading.Tasks;
using HandMadeShop.Logic.Interfaces;
using HandMadeShop.Logic.Utils;
using Raven.Client.Documents.Session;

namespace HandMadeShop.Logic.Domain.Product.Commands
{
    public class AddProductCommandHandler : ICommandHandler<AddProductCommand>
    {
        private readonly IAsyncDocumentSession _session;

        public AddProductCommandHandler(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public async Task<CommandResult> Handle(AddProductCommand command)
        {
            var product = new Core.Models.Product
            {
                Name = command.Name,
                Price = command.Price
            };
            await _session.StoreAsync(product);
            await _session.SaveChangesAsync();
            return await Task.FromResult(CommandResult.Ok(product.Id));
        }
    }
}