using System.Collections.Generic;
using System.Linq;
using HandMadeShop.Domain.Interfaces;
using HandMadeShop.Domain.RepositoryAbstractions;

namespace HandMadeShop.Domain.Entities.DeliveryMethod.Queries
{
    internal sealed class GetListQueryHandler : IQueryHandler<GetListQuery, IEnumerable<DeliveryMethodDto>>
    {
        private IDeliveryMethodRepository _deliveryMethodRepository;

        public GetListQueryHandler(IDeliveryMethodRepository deliveryMethodRepository)
        {
            _deliveryMethodRepository = deliveryMethodRepository;
        }

        public  IEnumerable<DeliveryMethodDto> Handle(GetListQuery query)
        {
          var dBResponse = _deliveryMethodRepository.GetList();

          return dBResponse.Select(i => new DeliveryMethodDto
          {
              Name = i.Name
          });
        }
    }
}