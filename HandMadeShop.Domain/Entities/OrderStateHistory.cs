using HandMadeShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HandMadeShop.Domain.Entities
{
  public class OrderStateHistory : AuditableEntity
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OrderId { get; set; }
    public int? OldOrderStateId { get; set; }
    public int? NewOrderStateId { get; set; }
    public string Text { get; set; }

    public User User { get; set; }
    public Order Order { get; set; }
    public OrderState OldOrderState { get; set; }
    public OrderState NewOrderState { get; set; }

    public override ModelBuilder Configure(ModelBuilder builder) =>
      builder.Entity<OrderStateHistory>(b =>
      {
        b.HasKey(p => p.Id);
        b.HasIndex(p => p.Id).IsUnique();
        b.Property(p => p.Id).ValueGeneratedOnAdd();
        b.Property(p => p.UserId).IsRequired();
        b.Property(p => p.OrderId).IsRequired();
        b.Property(p => p.Text).IsRequired().HasMaxLength(256);

        b.HasOne(p => p.User).WithMany(p => p.OrderStateHistories).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
        b.HasOne(p => p.Order).WithMany(p => p.OrderStateHistories).HasForeignKey(p => p.OrderId).OnDelete(DeleteBehavior.Restrict);
        b.HasOne(p => p.OldOrderState).WithMany().HasForeignKey(p => p.OrderId).OnDelete(DeleteBehavior.Restrict);
        b.HasOne(p => p.NewOrderState).WithMany().HasForeignKey(p => p.OrderId).OnDelete(DeleteBehavior.Restrict);

        b.ToTable("OrderStateHistories");
      });
  }
}
