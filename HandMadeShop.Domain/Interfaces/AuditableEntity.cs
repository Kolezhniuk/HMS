using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HandMadeShop.Domain.Interfaces
{
  public abstract class AuditableEntity : IEntity
  {
    [Required]
    public int CreatedBy { get; set; }
    [Required]
    public int ModifiedBy { get; set; }
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime ModifiedOn { get; set; } = DateTime.Now;

    public virtual ModelBuilder Configure(ModelBuilder builder) => builder;
  }
}
