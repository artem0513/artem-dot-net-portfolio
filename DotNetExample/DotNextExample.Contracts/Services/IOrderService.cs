using DotNetExample.Dtos.Dtos;
using DotNextExample.Contracts.Services;

namespace DotNetExample.Contracts.Services
{
    public interface IOrderService : IService<int, OrderDto>
    {
        Task Update(int userId, UpdateOrderDto order, CancellationToken cancellationToken = default);
    }
}
