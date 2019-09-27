using HandMadeShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HandMadeShop.Domain.Entities
{
  public class DeliveryMethod : AuditableEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Position { get; set; }

    public override ModelBuilder Configure(ModelBuilder builder) =>
      builder.Entity<DeliveryMethod>(b =>
      {
        b.HasKey(p => p.Id);
        b.HasIndex(p => p.Id).IsUnique();
        b.Property(p => p.Id).ValueGeneratedOnAdd();
        b.Property(p => p.Name).IsRequired().HasMaxLength(64);
        b.Property(p => p.Position).IsRequired();

        b.ToTable("DeliveryMethods");
      });
  }
}
