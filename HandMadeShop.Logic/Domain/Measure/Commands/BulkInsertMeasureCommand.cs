using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandMadeShop.Dtos.Measure;
using HandMadeShop.Logic.Interfaces;
using HandMadeShop.Logic.Utils;
using HandMadeShop.Logic.Utils.Decorators;
using Raven.Client.Documents;

namespace HandMadeShop.Logic.Domain.Measure.Commands
{
    public sealed class BulkInsertMeasureCommand : ICommand
    {
        public BulkInsertMeasureCommand(List<WriteMeasureDto> measureDtos)
        {
            MeasureDtos = measureDtos;
        }

        public List<WriteMeasureDto> MeasureDtos { get; }

        [AuditLog]
        internal sealed class BulkInsertMeasureCommandHandler : ICommandHandler<BulkInsertMeasureCommand>
        {
            private readonly IDocumentStore _store;

            //TODO implenent Merge strategy in bulk insert in future 
            public BulkInsertMeasureCommandHandler(IDocumentStore store)
            {
                _store = store;
            }

            public async Task<CommandResult> Handle(BulkInsertMeasureCommand command)
            {
                var measuresList = command.MeasureDtos.Select(i => new Core.Models.Measure
                {
                    Name = i.Name,
                    Position = i.Position
                });

                await using (var bulkInsert = _store.BulkInsert())
                {
                    foreach (var measure in measuresList)
                    {
                        await bulkInsert.StoreAsync(measure);
                    }
                }

                return CommandResult.Ok();
            }
        }
    }
}