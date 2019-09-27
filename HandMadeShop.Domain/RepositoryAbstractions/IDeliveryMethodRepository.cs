using HandMadeShop.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using HandMadeShop.Domain.Entities.DeliveryMethod;

namespace HandMadeShop.Domain.RepositoryAbstractions
{
  public interface IDeliveryMethodRepository
  {
    Task<IEnumerable<DeliveryMethod>> GetListAsync();
    IEnumerable<DeliveryMethod> GetList();
  }
}
