using System;
using HandMadeShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HandMadeShop.Domain.Entities.DeliveryMethod
{
  public class DeliveryMethod : AuditableEntity<DeliveryMethod>
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Position { get; set; }

    public override ModelBuilder Configure(ModelBuilder builder) =>
      base.Configure(builder).Entity<DeliveryMethod>(b =>
      {
        b.HasKey(p => p.Id);
        b.HasIndex(p => p.Id).IsUnique();
        b.Property(p => p.Id).ValueGeneratedOnAdd();
        b.Property(p => p.Name).IsRequired().HasMaxLength(64);
        b.Property(p => p.Position).IsRequired();
        b.Property(p => p.ModifiedOn).IsRequired().ValueGeneratedOnUpdate().HasDefaultValue(DateTime.Now);
        b.Property(p => p.CreatedOn).IsRequired().ValueGeneratedOnAdd().HasDefaultValue(DateTime.Now);
      });
  }
}