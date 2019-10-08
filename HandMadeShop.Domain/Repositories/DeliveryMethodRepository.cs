using HandMadeShop.Domain.Entities.DeliveryMethod;
using HandMadeShop.Domain.Interfaces;
using HandMadeShop.Domain.RepositoryAbstractions;

namespace HandMadeShop.Domain.Repositories
{
  public class DeliveryMethodRepository : RepositoryBase<DeliveryMethod>, IDeliveryMethodRepository
  {
    public DeliveryMethodRepository(IStorageContext storageContext) : base(storageContext)
    {
    }
  }
}