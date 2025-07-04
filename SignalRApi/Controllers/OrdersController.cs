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
        // GET: api/orders/totalcount
        [HttpGet("GetTotalOrderCount")]
        public IActionResult GetTotalOrderCount()
        {
            try
            {
                var totalCount = _orderService.TGetTotalOrderCount();
                return Ok(totalCount);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving total order count: {ex.Message}");
            }
        }
        [HttpGet("ActiveOrderCount")]
        public IActionResult GetActiveOrderCount()
        {
            try
            {
                var activeCount = _orderService.TGetActiveOrderCount();
                return Ok(activeCount);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving active order count: {ex.Message}");
            }
        }
        [HttpGet("LastOrderPrice")]
        public IActionResult GetLastOrderPrice()
        {
            try
            {
                var lastPrice = _orderService.TGetLastOrderPrice();
                return Ok(lastPrice);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving last order price: {ex.Message}");
            }
        }

        [HttpGet("TTodayTotalPrice")]
        public IActionResult TTodayTotalPrice()
        {
            return Ok(_orderService.TTodayTotalPrice());
        }
    }
}
