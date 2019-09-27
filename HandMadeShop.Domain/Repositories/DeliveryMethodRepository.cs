using HandMadeShop.Domain.Entities;
using HandMadeShop.Domain.Interfaces;
using HandMadeShop.Domain.RepositoryAbstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandMadeShop.Domain.Repositories
{
  public class DeliveryMethodRepository : RepositoryBase<DeliveryMethod>, IDeliveryMethodRepository
  {
    public DeliveryMethodRepository(IStorageContext storageContext) : base(storageContext)
    {
    }

    public async Task<IEnumerable<DeliveryMethod>> GetListAsync() =>
      await this.dbSet.AsNoTracking().ToListAsync();
  }
}
