using HandMadeShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HandMadeShop.Domain.Entities
{
  public class User : IEntity
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool? Gender { get; set; }
  }
}
