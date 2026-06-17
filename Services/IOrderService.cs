using Mini_E_Commerce_API.DTOs;
using Mini_E_Commerce_API.Models;

namespace Mini_E_Commerce_API.Services
{
    public interface IOrderService
    {
        IEnumerable<OrderResponseDto> GetOrders(int userId);   
        void PlaceOrder (int userId, OrderRequestDto orderRequestDto);

    }
}
