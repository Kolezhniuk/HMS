using System.Threading.Tasks;
using HandMadeShop.Dtos.Measure;
using HandMadeShop.Logic.Interfaces;
using Raven.Client.Documents.Session;

namespace HandMadeShop.Logic.Domain.Measure.Queries
{
    public class GetMeasureQuery : IQuery<MeasureDto>
    {
        public string Id { get; set; }

        public sealed class GetMeasureQueryHandler : IQueryHandler<GetMeasureQuery, MeasureDto>
        {
            private readonly IAsyncDocumentSession _session;

            public GetMeasureQueryHandler(IAsyncDocumentSession session)
            {
                _session = session;
            }

            public async Task<MeasureDto> Handle(GetMeasureQuery query)
            {
                var measure = await _session.LoadAsync<Core.DomainEntities.Measure>(query.Id);

                return new MeasureDto
                {
                    Id = measure.Id,
                    Name = measure.Name,
                    Position = measure.Position
                };
            }
        }
    }
}