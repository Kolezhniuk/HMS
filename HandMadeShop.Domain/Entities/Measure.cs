using HandMadeShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HandMadeShop.Domain.Entities
{
  public class Measure : AuditableEntity<Measure>
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Position { get; set; }

    public ICollection<ProductMeasure> ProductMeasures { get; set; }

    public override ModelBuilder Configure(ModelBuilder builder) =>
      base.Configure(builder).Entity<Measure>(b =>
      {
        b.HasKey(p => p.Id);
        b.HasIndex(p => p.Id).IsUnique();
        b.Property(p => p.Id).ValueGeneratedOnAdd();
        b.Property(p => p.Name).IsRequired().HasMaxLength(64);
        b.Property(p => p.Position).IsRequired();
      });
  }
}
