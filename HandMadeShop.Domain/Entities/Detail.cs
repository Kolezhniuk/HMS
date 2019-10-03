using HandMadeShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HandMadeShop.Domain.Entities
{
  public class Detail : AuditableEntity<Detail>
  {
    public int Id { get; set; }
    public int? DetailId { get; set; }
    public string Name { get; set; }
    public int Position { get; set; }

    public Detail Parent { get; set; }
    public ICollection<Detail> Details { get; set; }
    public ICollection<ProductDetail> ProductDetails { get; set; }

    public override ModelBuilder Configure(ModelBuilder builder) =>
      base.Configure(builder).Entity<Detail>(b =>
      {
        b.HasKey(p => p.Id);
        b.HasIndex(p => p.Id).IsUnique();
        b.Property(p => p.Id).ValueGeneratedOnAdd();
        b.Property(p => p.Name).IsRequired().HasMaxLength(64);
        b.Property(p => p.Position).IsRequired();
        b.HasOne(p => p.Parent).WithMany(p => p.Details).HasForeignKey(p => p.DetailId).OnDelete(DeleteBehavior.Restrict);
      });
  }
}
