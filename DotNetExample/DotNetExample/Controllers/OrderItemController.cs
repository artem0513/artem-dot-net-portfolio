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


        [HttpPost("admin/add-item")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddOrderItem([FromBody] OrderItemDto orderItem, CancellationToken cancellationToken)
        {
            await _orderItemService.AddAsync(orderItem, cancellationToken);
            return Ok();
        }

        [HttpPost("user/add-to-order")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddOrderItemToOrder([FromBody] AddOrderItemDto orderItem, CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            await _orderItemService.AddItemToOrderAsync(userId, orderItem, cancellationToken);
            return Ok();
        }
    }
}