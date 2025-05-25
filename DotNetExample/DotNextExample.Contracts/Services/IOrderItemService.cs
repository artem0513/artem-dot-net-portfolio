using DotNetExample.Dtos.Dtos;
using DotNextExample.Contracts.Services;

namespace DotNetExample.Contracts.Services
{
    public interface IOrderItemService : IService<int, OrderItemDto>
    {
        Task AddItemToOrderAsync(int userId, AddOrderItemDto item, CancellationToken cancellationToken = default);
    }
}
