using System.Collections.Generic;
using HandMadeShop.Dtos.Measure;
using HandMadeShop.Logic.Interfaces;

namespace HandMadeShop.Logic.Domain.Measure.Queries
{
    public class GetMeasureListQuery : IQuery<IEnumerable<MeasureDto>>
    {
    }
}