using Microsoft.EntityFrameworkCore;

namespace HandMadeShop.Domain.Interfaces
{
  public interface IEntity
  {
    ModelBuilder Configure(ModelBuilder builder);
  }
}
