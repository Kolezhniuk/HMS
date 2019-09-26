using System.Threading.Tasks;

namespace HandMadeShop.Domain.Interfaces
{
  public interface IStorageContext
  {
    Task SaveAsync();
  }
}
