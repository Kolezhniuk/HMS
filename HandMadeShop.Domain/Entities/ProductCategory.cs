using HandMadeShop.Domain.Interfaces;

namespace HandMadeShop.Domain.Entities
{
  public class ProductCategory : IEntity
  {
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
  }
}
