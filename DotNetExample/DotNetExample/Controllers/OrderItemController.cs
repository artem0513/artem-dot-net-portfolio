using DotNetExample.Contracts.Services;
using DotNetExample.Dtos.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DotNetExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpPost("user/get-items/{orderId}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetUserOrderItems([FromRoute] int orderId, CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            return Ok(await _orderItemService.GetByOrderId(orderId, userId, cancellationToken));
        }

        [HttpPost("admin/get-items/{orderId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetOrderItems([FromRoute] int orderId, CancellationToken cancellationToken)
        {
            return Ok(await _orderItemService.GetByOrderId(orderId, cancellationToken));
        }

        [HttpPost("user/add-to-order")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddOrderItemToOrder([FromBody] UpsertOrderItemDto orderItem, CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            await _orderItemService.AddItemToOrderAsync(userId, orderItem, cancellationToken);
            return Ok();
        }
    }
}