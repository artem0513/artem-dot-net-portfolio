using DotNetExample.Dtos.Dtos;
using DotNextExample.Contracts.Services;

namespace DotNetExample.Contracts.Services
{
    public interface IOrderItemService : IService<int, OrderItemDto>
    {
        Task AddItemToOrderAsync(int userId, UpsertOrderItemDto item, CancellationToken cancellationToken = default);
        Task<ICollection<OrderItemDto>> GetByOrderId(int orderId, int userId, CancellationToken cancellationToken = default);
        Task<ICollection<OrderItemDto>> GetByOrderId(int orderId, CancellationToken cancellationToken = default);
    }
}
