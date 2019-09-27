using HandMadeShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HandMadeShop.Domain.Entities
{
  public class User : AuditableEntity
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool? Gender { get; set; }

    public ICollection<OrderStateHistory> OrderStateHistories { get; set; }

    public override ModelBuilder Configure(ModelBuilder builder) =>
      builder.Entity<User>(b =>
      {
        b.HasKey(p => p.Id);
        b.HasIndex(p => p.Id).IsUnique();
        b.Property(p => p.Id).ValueGeneratedOnAdd();
        b.Property(p => p.FirstName).IsRequired().HasMaxLength(64);
        b.Property(p => p.LastName).IsRequired().HasMaxLength(64);
        b.Property(p => p.Email).IsRequired().HasMaxLength(64);
        b.Property(p => p.Phone).IsRequired().HasMaxLength(32);

        b.ToTable("Users");
      });
  }
}
