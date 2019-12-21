using System.Collections.Generic;
using HandMadeShop.Dtos.DeliveryMethod;
using HandMadeShop.Logic.Interfaces;

namespace HandMadeShop.Logic.Domain.DeliveryMethod.Queries
{
    public class GetListQuery : IQuery<IEnumerable<DeliveryMethodDto>>
    {
    }
}