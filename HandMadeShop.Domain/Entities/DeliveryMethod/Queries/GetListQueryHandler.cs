using System.Collections.Generic;
using System.Linq;
using HandMadeShop.Domain.Interfaces;
using HandMadeShop.Domain.RepositoryAbstractions;
using Microsoft.Extensions.Logging;

namespace HandMadeShop.Domain.Entities.DeliveryMethod.Queries
{
  internal sealed class GetListQueryHandler : IQueryHandler<GetListQuery, IEnumerable<DeliveryMethodDto>>
  {
    private readonly IDeliveryMethodRepository _deliveryMethodRepository;
    private readonly ILogger<GetListQueryHandler> _logger;

    public GetListQueryHandler(IDeliveryMethodRepository deliveryMethodRepository,
      ILogger<GetListQueryHandler> logger)
    {
      _deliveryMethodRepository = deliveryMethodRepository;
      _logger = logger;
    }

    public IEnumerable<DeliveryMethodDto> Handle(GetListQuery query)
    {
      _logger.LogWarning("Query Log", query);
      var dBResponse = _deliveryMethodRepository.GetAll();

      return dBResponse.Select(i => new DeliveryMethodDto
      {
        Name = i.Name
      });
    }
  }
}