using HandMadeShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HandMadeShop.Domain.Entities
{
  public class ProductCategory : IEntity
  {
    public int ProductId { get; set; }
    public int CategoryId { get; set; }

    public Product Product { get; set; }
    public Category Category { get; set; }

    public ModelBuilder Configure(ModelBuilder builder) =>
      builder.Entity<ProductCategory>(b =>
      {
        b.HasKey(p => new { p.ProductId, p.CategoryId });
        b.HasIndex(p => new { p.ProductId, p.CategoryId }).IsUnique();
        b.HasOne(p => p.Product).WithMany(p => p.ProductCategories).HasForeignKey(p => p.ProductId);
        b.HasOne(p => p.Category).WithMany(p => p.ProductCategories).HasForeignKey(p => p.CategoryId);

        b.ToTable(GetType().Name);
      });
  }
}
