using Microsoft.AspNetCore.Mvc;
using WholesaleRecommendationSystem.Models;
using WholesaleRecommendationSystem.Services;

namespace WholesaleRecommendationSystem.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    //public class OrderController : ControllerBase
    //{
    //    private readonly IOrderService _orderService;

    //    public OrderController(IOrderService orderService)
    //    {
    //        _orderService = orderService;
    //    }

    //    [HttpPost("create")]
    //    public async Task<IActionResult> CreateOrder([FromBody] Order order)
    //    {
    //        var createdOrder = await _orderService.CreateOrderAsync(order);
    //        return Ok(createdOrder);
    //    }

    //    [HttpGet("user/{userId}")]
    //    public async Task<IActionResult> GetUserOrders(int userId)
    //    {
    //        var orders = await _orderService.GetOrdersByUserAsync(userId);
    //        return Ok(orders);
    //    }
    //}
}
