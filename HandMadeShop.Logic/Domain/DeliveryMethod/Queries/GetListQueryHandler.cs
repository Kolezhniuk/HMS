using System.Collections.Generic;
using System.Threading.Tasks;
using HandMadeShop.Dtos.DeliveryMethod;
using HandMadeShop.Logic.Interfaces;

namespace HandMadeShop.Logic.Domain.DeliveryMethod.Queries
{
    internal sealed class GetListQueryHandler : IQueryHandler<GetListQuery, IEnumerable<DeliveryMethodDto>>
    {
        public async Task<IEnumerable<DeliveryMethodDto>> Handle(GetListQuery query)
        {
            return await Task.FromResult(new List<DeliveryMethodDto>());
        }
    }
}