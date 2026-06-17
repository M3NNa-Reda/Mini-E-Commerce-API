using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_E_Commerce_API.DTOs;
using Mini_E_Commerce_API.Services;
using System.Security.Claims;

namespace Mini_E_Commerce_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController(IOrderService orderService) : ControllerBase
    {

        [HttpGet]
        [Route("my-orders")]
        [Authorize(Roles = "Customer")]
        public IActionResult GetOrders()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var orders = orderService.GetOrders(userId);
            return Ok(orders);
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public IActionResult PlaceOrder(OrderRequestDto requestDto)
        {
            var userId =int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            
            orderService.PlaceOrder(userId, requestDto);
            
            return Ok("Your order has been confirmed");
        }
        
    }
}
