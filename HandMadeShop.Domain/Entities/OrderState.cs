using HandMadeShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HandMadeShop.Domain.Entities
{
  public class OrderState : AuditableEntity<OrderState>
  {
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public int Position { get; set; }

    public override ModelBuilder Configure(ModelBuilder builder) =>
      base.Configure(builder).Entity<OrderState>(b =>
      {
        b.HasKey(p => p.Id);
        b.HasIndex(p => p.Id).IsUnique();
        b.Property(p => p.Id).ValueGeneratedOnAdd();
        b.Property(p => p.Code).IsRequired().HasMaxLength(64);
        b.Property(p => p.Name).IsRequired().HasMaxLength(64);
        b.Property(p => p.Position).IsRequired();
      });
  }
}
