using DotNetExample.Dtos.Dtos;
using DotNextExample.Contracts.Services;

namespace DotNetExample.Contracts.Services
{
    public interface IProductService : IService<int, ProductDto>
    {
    }
}
