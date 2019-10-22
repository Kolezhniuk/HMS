using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandMadeShop.Dtos.Measure;
using HandMadeShop.Logic.Interfaces;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace HandMadeShop.Logic.Domain.Measure.Queries
{
    internal sealed class GetALLMeasuresQueryHandler : IQueryHandler<GetAllMeasuresQuery, IEnumerable<MeasureDto>>
    {
        private readonly IAsyncDocumentSession _session;

        public GetALLMeasuresQueryHandler(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<MeasureDto>> Handle(GetAllMeasuresQuery query) =>
            (await _session.Query<Core.Models.Measure>().ToListAsync())
            .Select(i => new MeasureDto
            {
                Id = i.Id,
                Name = i.Name,
                Position = i.Position
            });
    }
}