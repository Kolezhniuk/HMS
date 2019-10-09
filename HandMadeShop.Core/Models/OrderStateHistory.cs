namespace HandMadeShop.Core.Models
{
    public class OrderStateHistory
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public User User { get; set; }
        public Order Order { get; set; }
        public OrderState OldOrderState { get; set; }
        public OrderState NewOrderState { get; set; }
    }
}