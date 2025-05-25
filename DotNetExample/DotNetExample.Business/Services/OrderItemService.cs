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

        public async Task AddItemToOrderAsync(int userId, AddOrderItemDto item, CancellationToken cancellationToken = default)
        {
            await Repository.AddItemToOrderAsync(userId, item, cancellationToken);
        }
    }
}
