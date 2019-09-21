﻿using HandMadeShop.Domain.Interfaces;

namespace HandMadeShop.Domain.Entities
{
  public class PaymentMethod : IEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}