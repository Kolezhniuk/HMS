using HandMadeShop.Domain.Interfaces;

namespace HandMadeShop.Domain.Entities
{
  public class ProductDetail : IEntity
  {
    public int ProductId { get; set; }
    public int DetailId { get; set; }
  }
}
