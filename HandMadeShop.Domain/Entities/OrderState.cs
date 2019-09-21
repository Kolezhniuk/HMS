using HandMadeShop.Domain.Interfaces;

namespace HandMadeShop.Domain.Entities
{
  public class OrderState : IEntity
  {
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public int Position { get; set; }
  }
}
