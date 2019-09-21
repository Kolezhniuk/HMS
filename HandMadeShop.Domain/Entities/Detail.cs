using HandMadeShop.Domain.Interfaces;

namespace HandMadeShop.Domain.Entities
{
  public class Detail : IEntity
  {
    public int Id { get; set; }
    public int? ProductDetailId { get; set; }
    public string Name { get; set; }
    public int Position { get; set; }
  }
}
