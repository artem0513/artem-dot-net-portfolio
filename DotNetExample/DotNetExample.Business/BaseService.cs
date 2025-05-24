using DotNextExample.Contracts.Repositories;
using DotNextExample.Contracts.Services;

namespace DotNetExample.Business
{
    public abstract class BaseService<TId, TDto, TRepository> : IService<TId, TDto> where TRepository : IRepository<TId, TDto>
    {
        protected BaseService(TRepository repository)
        {
            Repository = repository;
        }

        public TRepository Repository { get; }

        public virtual async Task AddAsync(IEnumerable<TDto> items, CancellationToken cancellationToken = default)
        {
            await Repository.AddAsync(items, cancellationToken: cancellationToken);
        }

        public virtual async Task AddAsync(TDto item, CancellationToken cancellationToken = default)
        {
            await Repository.AddAsync(item, cancellationToken: cancellationToken);
        }

        public virtual async Task DeleteAsync(TId id, CancellationToken cancellationToken = default)
        {
            await Repository.DeleteAsync(id, cancellationToken: cancellationToken);
        }

        public virtual async Task DeleteAsync(IEnumerable<TId> ids, CancellationToken cancellationToken = default)
        {
            await Repository.DeleteAsync(ids, cancellationToken: cancellationToken);
        }

        public virtual async Task<TDto> GetAsync(TId id, CancellationToken cancellationToken = default)
        {
            return await Repository.GetAsync(id, cancellationToken: cancellationToken);
        }

        public virtual async Task<ICollection<TDto>> GetAsync(IEnumerable<TId> ids, CancellationToken cancellationToken = default)
        {
            return await Repository.GetAsync(ids, cancellationToken: cancellationToken);
        }

        public virtual async Task UpdateAsync(TDto item, CancellationToken cancellationToken = default)
        {
            await Repository.UpdateAsync(item, cancellationToken: cancellationToken);
        }

        public virtual async Task UpdateAsync(IEnumerable<TDto> items, CancellationToken cancellationToken = default)
        {
            await Repository.UpdateAsync(items, cancellationToken: cancellationToken);
        }
    }
}
