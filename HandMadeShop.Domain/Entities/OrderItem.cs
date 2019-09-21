using HandMadeShop.Domain.Interfaces;

namespace HandMadeShop.Domain.Entities
{
  public class OrderItem : IEntity
  {
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public double Quantity { get; set; }
    public double Discount { get; set; }
    //public int OrderItemStateId { get; set; }
  }
}
