using HandMadeShop.Domain.Interfaces;

namespace HandMadeShop.Domain.Entities
{
  public class ProductMeasure : IEntity
  {
    public int ProductId { get; set; }
    public int MeasureId { get; set; }
  }
}
