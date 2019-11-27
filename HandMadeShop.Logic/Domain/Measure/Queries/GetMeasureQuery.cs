using HandMadeShop.Dtos.Measure;
using HandMadeShop.Logic.Interfaces;

namespace HandMadeShop.Logic.Domain.Measure.Queries
{
    public class GetMeasureQuery : IQuery<MeasureDto>
    {
        public string Id { get; set; }
    }
}