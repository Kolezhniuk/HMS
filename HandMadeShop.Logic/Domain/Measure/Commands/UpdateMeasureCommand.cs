using System;
using System.Threading.Tasks;
using HandMadeShop.Logic.Interfaces;
using HandMadeShop.Logic.Utils;
using Raven.Client.Documents.Session;

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

        internal sealed class UpdateMeasureCommandHandler : ICommandHandler<UpdateMeasureCommand>
        {
            private readonly IAsyncDocumentSession _session;

            public UpdateMeasureCommandHandler(IAsyncDocumentSession session)
            {
                _session = session;
            }

            public async Task<CommandResult> Handle(UpdateMeasureCommand command)
            {
                try
                {
                    var entity = await _session.LoadAsync<Core.Models.Measure>(command.Id);
                    entity.Name = command.Name;
                    entity.Position = command.Position;
                    await _session.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return CommandResult.Fail(e.Message);
                }

                return CommandResult.Ok();
            }
        }
    }
}