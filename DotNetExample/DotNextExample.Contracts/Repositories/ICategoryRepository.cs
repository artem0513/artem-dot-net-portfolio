using DotNetExample.Dtos.Dtos;
using DotNextExample.Contracts.Repositories;

namespace DotNetExample.Contracts.Repositories
{
    public interface ICategoryRepository : IRepository<int, CategoryDto>
    {
    }
}
