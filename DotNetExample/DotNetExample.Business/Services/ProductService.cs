using DotNetExample.Contracts.Repositories;
using DotNetExample.Contracts.Services;
using DotNetExample.Dtos.Dtos;

namespace DotNetExample.Business.Services
{
    internal class ProductService : BaseService<int, ProductDto, IProductRepository>, IProductService
    {
        public ProductService(IProductRepository repository) : base(repository)
        {
        }
    }
}
