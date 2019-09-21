using HandMadeShop.Domain.Interfaces;
using System;

namespace HandMadeShop.Domain.Entities
{
  public class OrderStateHistory : IEntity
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OrderId { get; set; }
    public int? OldOrderStateId { get; set; }
    public int? NewOrderStateId { get; set; }
    public string Text { get; set; }
    public DateTime Created { get; set; }
  }
}
