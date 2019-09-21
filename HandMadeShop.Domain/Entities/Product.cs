using HandMadeShop.Domain.Interfaces;
using System;

namespace HandMadeShop.Domain.Entities
{
  public class Product : IEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string PhotoUrl { get; set; }
    public bool IsHidden { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime Created { get; set; }
  }
}
