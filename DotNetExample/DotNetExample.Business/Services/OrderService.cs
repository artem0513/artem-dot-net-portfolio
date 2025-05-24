using DotNetExample.Contracts.Repositories;
using DotNetExample.Contracts.Services;
using DotNetExample.Dtos.Dtos;

namespace DotNetExample.Business.Services
{
    internal class OrderService : BaseService<int, OrderDto, IOrderRepository>, IOrderService
    {
        public OrderService(IOrderRepository repository) : base(repository)
        {
        }
    }
}
