using System;
using System.Collections.Generic;

namespace HandMadeShop.Core.Models
{
    public class Order
    {
        public string Id { get; set; }
        public int DeliveryPrice { get; set; }
        public string Note { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string Company { get; set; }
        public string User { get; set; }
        public OrderState OrderState { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        private List<OrderItem> OrderItems { get; set; }
    }
}