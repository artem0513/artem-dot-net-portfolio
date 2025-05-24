using DotNetExample.Contracts.Repositories;
using DotNetExample.Contracts.Services;
using DotNetExample.Dtos.Dtos;

namespace DotNetExample.Business.Services
{
    internal class CategoryService : BaseService<int, CategoryDto, ICategoryRepository>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository) : base(repository)
        {
        }
    }
}
