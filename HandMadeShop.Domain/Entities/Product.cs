using HandMadeShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HandMadeShop.Domain.Entities
{
  public class Product : AuditableEntity<Product>
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string PhotoUrl { get; set; }
    public bool IsHidden { get; set; }
    public bool IsAvailable { get; set; }

    public ICollection<ProductCategory> ProductCategories { get; set; }
    public ICollection<ProductDetail> ProductDetails { get; set; }
    public ICollection<ProductMeasure> ProductMeasures { get; set; }

    public override ModelBuilder Configure(ModelBuilder builder) =>
      base.Configure(builder).Entity<Product>(b =>
      {
        b.HasKey(p => p.Id);
        b.HasIndex(p => p.Id).IsUnique();
        b.Property(p => p.Id).ValueGeneratedOnAdd();
        b.Property(p => p.Name).IsRequired().HasMaxLength(64);
        b.Property(p => p.Price).IsRequired();
        b.Property(p => p.PhotoUrl).IsRequired().HasMaxLength(64);
        b.Property(p => p.IsHidden).IsRequired();
        b.Property(p => p.IsAvailable).IsRequired();
      });
  }
}
