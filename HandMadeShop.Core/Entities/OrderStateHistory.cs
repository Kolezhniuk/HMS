namespace HandMadeShop.Core.Entities
{
    public class OrderStateHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int? OldOrderStateId { get; set; }
        public int? NewOrderStateId { get; set; }
        public string Text { get; set; }

        public User User { get; set; }
        public Order Order { get; set; }
        public OrderState OldOrderState { get; set; }
        public OrderState NewOrderState { get; set; }
    }
}