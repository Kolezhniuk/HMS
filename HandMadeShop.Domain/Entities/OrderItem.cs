using HandMadeShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HandMadeShop.Domain.Entities
{
  public class OrderItem : AuditableEntity<OrderItem>
  {
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public double Quantity { get; set; }
    public double Discount { get; set; }

    public Order Order { get; set; }
    public Product Product { get; set; }

    public override ModelBuilder Configure(ModelBuilder builder) =>
      base.Configure(builder).Entity<OrderItem>(b =>
      {
        b.HasKey(p => p.Id);
        b.HasIndex(p => p.Id).IsUnique();
        b.Property(p => p.Id).ValueGeneratedOnAdd();
        b.Property(p => p.OrderId).IsRequired();
        b.Property(p => p.ProductId).IsRequired();
        b.Property(p => p.Quantity).IsRequired();
        b.Property(p => p.Discount).IsRequired();
      });
  }
}
