using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            return Ok(_orderService.TTotalOrderCount());
        }
        [HttpGet("ActiveOrder")]
        public IActionResult ActiveOrder()
        {
            return Ok(_orderService.TActiveOrderCount());
        }
        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            return Ok(_orderService.TLastOrderPrice());
        }
    }
}
