using System;
using Microsoft.EntityFrameworkCore;

namespace HandMadeShop.Domain.Interfaces
{
  public abstract class AuditableEntity<T> : IEntity 
    where T : AuditableEntity<T>
  {
    public int CreatedBy { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime CreatedOn { get; set; } 
    public DateTime ModifiedOn { get; set; }

    public virtual ModelBuilder Configure(ModelBuilder builder) =>
    
      builder.Entity<T>(b =>
      {
        b.Property(p => p.CreatedBy).IsRequired();
        b.Property(p => p.ModifiedBy).IsRequired();
        b.Property(p => p.ModifiedOn).IsRequired().ValueGeneratedOnUpdate().HasDefaultValue(DateTime.Now);
        b.Property(p => p.CreatedOn).IsRequired().ValueGeneratedOnAdd().HasDefaultValue(DateTime.Now);
        b.ToTable(typeof(T).Name);
      });
    
  }
}
