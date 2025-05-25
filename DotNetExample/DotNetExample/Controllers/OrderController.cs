using DotNetExample.Contracts.Services;
using DotNetExample.Dtos.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpPut("user/update")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderDto updateOrderDto, CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            await _orderService.Update(userId, updateOrderDto, cancellationToken);

            return Ok();
        }

        [HttpGet("admin/get/{orderId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get([FromRoute] int orderId, CancellationToken cancellationToken)
        {
            return Ok(await _orderService.GetAsync(orderId, cancellationToken));
        }

        [HttpDelete("admin/create/{orderId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateOrder([FromRoute] int orderId, CancellationToken cancellationToken)
        {
            await _orderService.DeleteAsync(orderId, cancellationToken);
            return Ok();
        }
    }
}
