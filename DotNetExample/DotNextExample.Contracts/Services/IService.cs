namespace DotNextExample.Contracts.Services
{
    public interface IService<TId, TDto>
    {
        public Task<TDto> GetAsync(TId id, CancellationToken cancellationToken = default);
        public Task<ICollection<TDto>> GetAsync(IEnumerable<TId> ids, CancellationToken cancellationToken = default);
        public Task AddAsync(IEnumerable<TDto> items, CancellationToken cancellationToken = default);
        public Task AddAsync(TDto item, CancellationToken cancellationToken = default);
        public Task DeleteAsync(TId id, CancellationToken cancellationToken = default);
        public Task DeleteAsync(IEnumerable<TId> ids, CancellationToken cancellationToken = default);
        public Task UpdateAsync(TDto item, CancellationToken cancellationToken = default);
        public Task UpdateAsync(IEnumerable<TDto> items, CancellationToken cancellationToken = default);
    }
}
