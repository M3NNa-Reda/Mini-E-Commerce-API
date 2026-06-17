namespace Mini_E_Commerce_API.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime PlacedAt { get; set; }
        public DateTime? ShippedAt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
    public enum OrderStatus
    {
        Pending,
        Shipped,
        Delivered,
        Cancelled,
        Refunded
    }
}
