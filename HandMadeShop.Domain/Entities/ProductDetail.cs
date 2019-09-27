using HandMadeShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HandMadeShop.Domain.Entities
{
  public class ProductDetail : IEntity
  {
    public int ProductId { get; set; }
    public int DetailId { get; set; }

    public Product Product { get; set; }
    public Detail Detail { get; set; }

    public ModelBuilder Configure(ModelBuilder builder) =>
      builder.Entity<ProductDetail>(b =>
      {
        b.HasKey(p => new { p.ProductId, p.DetailId });
        b.HasIndex(p => new { p.ProductId, p.DetailId }).IsUnique();
        b.HasOne(p => p.Product).WithMany(p => p.ProductDetails).HasForeignKey(p => p.ProductId);
        b.HasOne(p => p.Detail).WithMany(p => p.ProductDetails).HasForeignKey(p => p.ProductId);

        b.ToTable("ProductDetails");
      });
  }
}
