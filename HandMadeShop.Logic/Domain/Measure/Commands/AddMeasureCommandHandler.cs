using System;
using System.Threading.Tasks;
using HandMadeShop.Logic.Interfaces;
using HandMadeShop.Logic.Utils;
using Raven.Client.Documents.Session;

namespace HandMadeShop.Logic.Domain.Measure.Commands
{
    public class AddMeasureCommandHandler : ICommandHandler<AddMeasureCommand>
    {
        private readonly IAsyncDocumentSession _session;

        public AddMeasureCommandHandler(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public async Task<CommandResult> Handle(AddMeasureCommand command)
        {
            var measure = new Core.Models.Measure
            {
                Name = command.Name,
                Position = command.Position
            };

            try
            {
                await _session.StoreAsync(measure);
                await _session.SaveChangesAsync();
            }

            catch (Exception e)
            {
                return CommandResult.Fail(e.Message);
            }

            return CommandResult.Ok(measure.Id);
        }
    }
}