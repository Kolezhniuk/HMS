using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandMadeShop.Dtos.Measure;
using HandMadeShop.Logic.Interfaces;
using Microsoft.Extensions.Logging;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace HandMadeShop.Logic.Domain.Measure.Queries
{
    public class GetAllMeasuresQuery : IQuery<IEnumerable<MeasureDto>>
    {
        internal sealed class GetALLMeasuresQueryHandler : IQueryHandler<GetAllMeasuresQuery, IEnumerable<MeasureDto>>
        {
            private readonly ILogger<IQueryHandler<GetAllMeasuresQuery, IEnumerable<MeasureDto>>> _logger;
            private readonly IAsyncDocumentSession _session;

            public GetALLMeasuresQueryHandler(IAsyncDocumentSession session,
                ILogger<IQueryHandler<GetAllMeasuresQuery, IEnumerable<MeasureDto>>> logger)
            {
                _session = session;
                _logger = logger;
            }

            public async Task<IEnumerable<MeasureDto>> Handle(GetAllMeasuresQuery query)
            {
                return (await _session.Query<Core.DomainEntities.Measure>().ToListAsync())
                    .Select(i => new MeasureDto
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Position = i.Position
                    });
            }
        }
    }
}