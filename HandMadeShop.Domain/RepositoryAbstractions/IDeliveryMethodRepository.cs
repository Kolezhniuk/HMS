using HandMadeShop.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandMadeShop.Domain.RepositoryAbstractions
{
  public interface IDeliveryMethodRepository
  {
    Task<IEnumerable<DeliveryMethod>> GetListAsync();
  }
}
