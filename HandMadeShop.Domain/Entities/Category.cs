using HandMadeShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HandMadeShop.Domain.Entities
{
  public class Category : IEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}
