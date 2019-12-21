using System.Threading.Tasks;
using HandMadeShop.Infrastrucutre.Utils.Decorators;
using HandMadeShop.Logic.Interfaces;
using HandMadeShop.Logic.Utils;
using Raven.Client.Documents.Session;

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

        [AuditLog]
        internal sealed class AddMeasureCommandHandler : ICommandHandler<AddMeasureCommand>
        {
            private readonly IAsyncDocumentSession _session;

            public AddMeasureCommandHandler(IAsyncDocumentSession session)
            {
                _session = session;
            }

            public async Task<CommandResult> Handle(AddMeasureCommand command)
            {
                var measure = new Infrastrucutre.DomainEntities.Measure
                {
                    Name = command.Name,
                    Position = command.Position
                };

                await _session.StoreAsync(measure);
                await _session.SaveChangesAsync();

                return CommandResult.Ok(measure.Id);
            }
        }
    }
}