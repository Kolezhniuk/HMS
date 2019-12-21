using System.Collections.Generic;
using HandMadeShop.Dtos.DeliveryMethod;
using HandMadeShop.Infrastrucutre.Interfaces;

namespace HandMadeShop.Infrastrucutre.Domain.DeliveryMethod.Queries
{
    public class GetListQuery : IQuery<IEnumerable<DeliveryMethodDto>>
    {
    }
}