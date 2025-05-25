using DotNetExample.Contracts.Repositories;
using DotNetExample.Contracts.Services;
using DotNetExample.Dtos.Dtos;

namespace DotNetExample.Business.Services
{
    internal class OrderItemService : BaseService<int, OrderItemDto, IOrderItemRepository>, IOrderItemService
    {
        public OrderItemService(IOrderItemRepository repository) : base(repository)
        {
        }

        public async Task AddItemToOrderAsync(int userId, UpsertOrderItemDto item, CancellationToken cancellationToken = default)
        {
            await Repository.AddItemToOrderAsync(userId, item, cancellationToken);
        }

        public async Task<ICollection<OrderItemDto>> GetByOrderId(int orderId, int userId, CancellationToken cancellationToken = default)
        {
            return await Repository.GetByOrderId(orderId, userId, cancellationToken);
        }

        public async Task<ICollection<OrderItemDto>> GetByOrderId(int orderId, CancellationToken cancellationToken = default)
        {
            return await Repository.GetByOrderId(orderId, cancellationToken);
        }
    }
}
