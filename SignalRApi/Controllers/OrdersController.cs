using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("TotalOrderCount")]
        public async Task<IActionResult> TotalOrderCount() => Ok(await _orderService.TTotalOrderCount());


        [HttpGet("ActiveOrderCount")]
        public async Task<IActionResult> ActiveOrderCount() => Ok(await _orderService.TActiveOrderCount());

        [HttpGet("LastOrderPrice")]
        public async Task<IActionResult> LastOrderPrice() => Ok(await _orderService.TLastOrderPrice());

        [HttpGet("TodayTotalPrice")]
        public async Task<IActionResult> TodayTotalPrice() => Ok(await _orderService.TTodayTotalPrice());
    }
}
