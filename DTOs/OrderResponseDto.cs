using Mini_E_Commerce_API.Models;

namespace Mini_E_Commerce_API.DTOs
{
    public class OrderResponseDto
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime PlacedAt { get; set; }
        public List<OrderItemResponseDto> Items { get; set; }
    }
}
