namespace DotNextExample.Contracts.Repositories
{
    public interface IRepository<TId, TDto>
    {
        public Task<TDto> GetAsync(TId id, bool saveChangesAsync = true, CancellationToken cancellationToken = default);
        public Task<ICollection<TDto>> GetAsync(IEnumerable<TId> ids, bool saveChangesAsync = true, CancellationToken cancellationToken = default);
        public Task AddAsync(IEnumerable<TDto> items, bool saveChangesAsync = true, CancellationToken cancellationToken = default);
        public Task AddAsync(TDto item, bool saveChangesAsync = true, CancellationToken cancellationToken = default);
        public Task DeleteAsync(TId id, bool saveChangesAsync = true, CancellationToken cancellationToken = default);
        public Task DeleteAsync(IEnumerable<TId> ids, bool saveChangesAsync = true, CancellationToken cancellationToken = default);
        public Task UpdateAsync(TDto item, bool saveChangesAsync = true, CancellationToken cancellationToken = default);
        public Task UpdateAsync(IEnumerable<TDto> items, bool saveChangesAsync = true, CancellationToken cancellationToken = default);
    }
}
