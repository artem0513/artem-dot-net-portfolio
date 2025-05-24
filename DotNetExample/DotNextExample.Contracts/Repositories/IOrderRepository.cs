using DotNetExample.Dtos.Dtos;
using DotNextExample.Contracts.Repositories;

namespace DotNetExample.Contracts.Repositories
{
    public interface IOrderRepository : IRepository<int, OrderDto>
    {

    }
}
