using Mini_E_Commerce_API.Data;
using Mini_E_Commerce_API.DTOs;
using Mini_E_Commerce_API.Models;

namespace Mini_E_Commerce_API.Services
{
    public class OrderService(ApplicationDbContext context) : IOrderService
    {
        public IEnumerable<OrderResponseDto> GetOrders(int userId)
        {
            var orders = context.Orders
                .Where(x => x.UserId == userId).
                Select(o => new OrderResponseDto
                {
                    OrderId = o.OrderId,
                    PlacedAt = o.PlacedAt,
                    Status = o.Status.ToString(),
                    TotalAmount = o.TotalAmount,
                    Items = o.OrderItems.Select(oi => new OrderItemResponseDto
                    {
                        ProductId = oi.ProductId,
                        ProductName = oi.Product.Name,
                        Quantity = oi.Quantity,
                        UnitPrice = oi.UnitPrice
                    }).ToList()
                }).ToList();

            return orders;
        }

        public void PlaceOrder(int userId,OrderRequestDto orderRequestDto)
        {
            decimal TotalAmount = 0;
            var order = new Order
            {
                UserId = userId,
                Status = OrderStatus.Pending,
                PlacedAt = DateTime.UtcNow,
                OrderItems = new List<OrderItem>()
            };

            foreach (var item in orderRequestDto.Items)

            {
                var product = context.Products.FirstOrDefault(x => x.ProductId == item.ProductId);
                if (product == null || product.StockQuantity < item.Quantity)
                    throw new Exception($"Product {product?.Name} not available");
                var orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                };
                TotalAmount += product.Price * item.Quantity;
                product.StockQuantity -= item.Quantity;
                order.OrderItems.Add(orderItem);
            }
            order.TotalAmount = TotalAmount;
            context.Orders.Add(order);
            context.SaveChanges();
        }
    }
}
