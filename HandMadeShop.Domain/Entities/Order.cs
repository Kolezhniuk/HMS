using HandMadeShop.Domain.Interfaces;
using System;

namespace HandMadeShop.Domain.Entities
{
  public class Order : IEntity
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OrderStateId { get; set; }
    public int DeliveryMethodId { get; set; }
    public int DeliveryPrice { get; set; }
    public int PaymentMethodId { get; set; }
    public string Note { get; set; }
    public DateTime? PaymentDate { get; set; }
    public DateTime Created { get; set; }
  }
}
