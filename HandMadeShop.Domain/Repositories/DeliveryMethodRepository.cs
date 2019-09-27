using HandMadeShop.Domain.Entities;
using HandMadeShop.Domain.Interfaces;
using HandMadeShop.Domain.RepositoryAbstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandMadeShop.Domain.Entities.DeliveryMethod;

namespace HandMadeShop.Domain.Repositories
{
  public class DeliveryMethodRepository : RepositoryBase<DeliveryMethod>, IDeliveryMethodRepository
  {
    public DeliveryMethodRepository(IStorageContext storageContext) : base(storageContext)
    {
    }

    public async Task<IEnumerable<DeliveryMethod>> GetListAsync() =>
      await this.dbSet.AsNoTracking().ToListAsync();

    public IEnumerable<DeliveryMethod> GetList()
    {
      return dbSet.AsNoTracking().ToList();
    }
  }
}
