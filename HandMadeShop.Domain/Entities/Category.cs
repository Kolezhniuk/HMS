using HandMadeShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HandMadeShop.Domain.Entities
{
  public class Category : AuditableEntity<Category>
  {
    public int Id { get; set; }
    public int? CategoryId { get; set; }
    public string Name { get; set; }

    public Category Parent { get; set; }
    public ICollection<Category> Categories { get; set; }
    public ICollection<ProductCategory> ProductCategories { get; set; }

    public override ModelBuilder Configure(ModelBuilder builder) => 
      base.Configure(builder).Entity<Category>(b =>
      {
        b.HasKey(p => p.Id);
        b.HasIndex(p => p.Id).IsUnique();
        b.Property(p => p.Id).ValueGeneratedOnAdd();
        b.Property(p => p.Name).IsRequired().HasMaxLength(64);
        b.HasOne(p => p.Parent).WithMany(p => p.Categories).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Restrict);
      });
  }
}
