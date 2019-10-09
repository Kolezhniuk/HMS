using System;

namespace HandMadeShop.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int DeliveryPrice { get; set; }
        public string Note { get; set; }
        public DateTime? PaymentDate { get; set; }

        public User User { get; set; }
        public OrderState OrderState { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}