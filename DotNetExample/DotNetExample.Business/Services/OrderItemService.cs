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
    }
}
