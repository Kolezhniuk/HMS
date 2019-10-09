using System.Collections.Generic;

namespace HandMadeShop.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? Gender { get; set; }

        public ICollection<OrderStateHistory> OrderStateHistories { get; set; }
    }
}