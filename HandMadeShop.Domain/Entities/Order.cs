using HandMadeShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HandMadeShop.Domain.Entities
{
  public class Order : AuditableEntity
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OrderStateId { get; set; }
    public int DeliveryMethodId { get; set; }
    public int DeliveryPrice { get; set; }
    public int PaymentMethodId { get; set; }
    public string Note { get; set; }
    public DateTime? PaymentDate { get; set; }

    public User User { get; set; }
    public OrderState OrderState { get; set; }
    public DeliveryMethod.DeliveryMethod DeliveryMethod { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public ICollection<OrderStateHistory> OrderStateHistories { get; set; }

    public override ModelBuilder Configure(ModelBuilder builder) =>
      builder.Entity<Order>(b =>
      {
        b.HasKey(p => p.Id);
        b.HasIndex(p => p.Id).IsUnique();
        b.Property(p => p.Id).ValueGeneratedOnAdd();
        b.Property(p => p.UserId).IsRequired();
        b.Property(p => p.OrderStateId).IsRequired();
        b.Property(p => p.DeliveryMethodId).IsRequired();
        b.Property(p => p.DeliveryPrice).IsRequired();
        b.Property(p => p.PaymentMethodId).IsRequired();
        b.Property(p => p.Note).IsRequired().HasMaxLength(512);

        b.ToTable("Orders");
      });
  }
}
