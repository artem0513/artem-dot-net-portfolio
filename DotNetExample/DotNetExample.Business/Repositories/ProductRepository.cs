using AutoMapper;
using DotNetExample.Contracts.Repositories;
using DotNetExample.DataAccessLayer;
using DotNetExample.DataAccessLayer.Entities;
using DotNetExample.Dtos.Dtos;

namespace DotNetExample.Business.Repositories
{
    internal class ProductRepository : BaseRepository<int, ProductDto, ProductEntity, ApplicationDbContext>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
