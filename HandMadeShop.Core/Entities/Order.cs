using System;
using System.Collections.Generic;

namespace HandMadeShop.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrderStateId { get; set; }
        public int DeliveryMethodId { get; set; }
        public int DeliveryPrice { get; set; }
        public int PaymentMethodId { get; set; }
        public string Note { get; set; }
        public DateTime? PaymentDate { get; set; }

        public User User { get; set; }
        public OrderState OrderState { get; set; }
        public DeliveryMethod.DeliveryMethod DeliveryMethod { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public ICollection<OrderStateHistory> OrderStateHistories { get; set; }
    }
}