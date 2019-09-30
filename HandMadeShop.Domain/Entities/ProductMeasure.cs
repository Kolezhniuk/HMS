using HandMadeShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HandMadeShop.Domain.Entities
{
  public class ProductMeasure : IEntity
  {
    public int ProductId { get; set; }
    public int MeasureId { get; set; }

    public Product Product { get; set; }
    public Measure Measure { get; set; }

    public ModelBuilder Configure(ModelBuilder builder) =>
      builder.Entity<ProductMeasure>(b =>
      {
        b.HasKey(p => new { p.ProductId, p.MeasureId });
        b.HasIndex(p => new { p.ProductId, p.MeasureId }).IsUnique();
        b.HasOne(p => p.Product).WithMany(p => p.ProductMeasures).HasForeignKey(p => p.ProductId);
        b.HasOne(p => p.Measure).WithMany(p => p.ProductMeasures).HasForeignKey(p => p.MeasureId);
      });
  }
}
