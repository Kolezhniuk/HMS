using System.Linq;
using System.Threading.Tasks;
using HandMadeShop.Logic.Interfaces;
using HandMadeShop.Logic.Utils;
using Raven.Client.Documents;

namespace HandMadeShop.Logic.Domain.Measure.Commands
{
    public class BulkInsertMeasureCommandHandler : ICommandHandler<BulkInsertMeasureCommand>
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

    /*
     * [{
  "Name": "EUR",
  "Position": 1
}, {
  "Name": "UAH",
  "Position": 2
}, {
  "Name": "MXN",
  "Position": 3
}, {
  "Name": "PEN",
  "Position": 4
}, {
  "Name": "KES",
  "Position": 5
}, {
  "Name": "EUR",
  "Position": 6
}, {
  "Name": "IDR",
  "Position": 7
}, {
  "Name": "EUR",
  "Position": 8
}, {
  "Name": "CNY",
  "Position": 9
}, {
  "Name": "RUB",
  "Position": 10
}]
     */
}