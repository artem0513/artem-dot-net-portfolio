using DotNetExample.Dtos.Dtos;
using DotNextExample.Contracts.Repositories;

namespace DotNetExample.Contracts.Repositories
{
    public interface IOrderItemRepository : IRepository<int, OrderItemDto>
    {
        Task AddItemToOrderAsync(int userId, UpsertOrderItemDto item, CancellationToken cancellationToken = default);
        Task<ICollection<OrderItemDto>> GetByOrderId(int orderId, int userId, CancellationToken cancellationToken = default);
        Task<ICollection<OrderItemDto>> GetByOrderId(int orderId, CancellationToken cancellationToken = default);
    }
}
