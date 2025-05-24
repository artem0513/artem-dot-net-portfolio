using DotNetExample.Contracts.Services;
using DotNetExample.Dtos.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DotNetExample.Controllers
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

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto order, CancellationToken cancellationToken)
        {
            await _orderService.AddAsync(order, cancellationToken);
            return Ok();
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> Get([FromRoute] int orderId, CancellationToken cancellationToken)
        {
            return Ok(await _orderService.GetAsync(orderId, cancellationToken));
        }
    }
}
