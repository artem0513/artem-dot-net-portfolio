using AutoMapper;
using DotNetExample.Contracts.Repositories;
using DotNetExample.DataAccessLayer;
using DotNetExample.DataAccessLayer.Entities;
using DotNetExample.Dtos.Dtos;

namespace DotNetExample.Business.Repositories
{
    internal class CategoryRepository : BaseRepository<int, CategoryDto, CategoryEntity, ApplicationDbContext>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
