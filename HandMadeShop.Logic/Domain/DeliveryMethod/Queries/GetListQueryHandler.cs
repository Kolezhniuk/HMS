using System.Collections.Generic;
using HandMadeShop.Dtos.DeliveryMethod;
using HandMadeShop.Logic.Interfaces;

namespace HandMadeShop.Logic.Domain.DeliveryMethod.Queries
{
    internal sealed class GetListQueryHandler : IQueryHandler<GetListQuery, IEnumerable<DeliveryMethodDto>>
    {
        public GetListQueryHandler()
        {
        }

        public IEnumerable<DeliveryMethodDto> Handle(GetListQuery query)
        {
            return new List<DeliveryMethodDto>();
        }
    }
}