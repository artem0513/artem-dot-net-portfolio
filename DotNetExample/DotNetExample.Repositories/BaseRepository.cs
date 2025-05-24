using AutoMapper;
using DotNetExample.DataAccessLayer;
using DotNetExample.Dtos;
using DotNextExample.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DotNetExample.Repositories
{
    public abstract class BaseRepository<TId, TDto, TEntity, TDbContext> : IRepository<TId, TDto> where TDto : BaseDto<TId> where TEntity : BaseEntity<TId> where TDbContext : DbContext
    {
        protected BaseRepository(TDbContext context, IMapper mapper)
        {
            Mapper = mapper;
            DbContext = context;
        }

        protected IMapper Mapper { get; set; }
        protected TDbContext DbContext { get; set; }


        public async Task<TDto> GetAsync(TId id, bool saveChangesAsync = true, CancellationToken cancellationToken = default)
        {
            var entity = await DbContext.Set<TEntity>().FindAsync([id], cancellationToken);
            return Mapper.Map<TDto>(entity);
        }

        public async Task<ICollection<TDto>> GetAsync(IEnumerable<TId> ids, bool saveChangesAsync = true, CancellationToken cancellationToken = default)
        {
            var entities = await DbContext.Set<TEntity>().Where(e => ids.Contains(e.Id)).ToListAsync(cancellationToken);
            return Mapper.Map<ICollection<TDto>>(entities);
        }

        public async Task AddAsync(TDto item, bool saveChangesAsync = true, CancellationToken cancellationToken = default)
        {
            var entity = Mapper.Map<TEntity>(item);
            await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
            if (saveChangesAsync)
            {
                await DbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task AddAsync(IEnumerable<TDto> items, bool saveChangesAsync = true, CancellationToken cancellationToken = default)
        {
            var entities = Mapper.Map<IEnumerable<TEntity>>(items);
            await DbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
            if (saveChangesAsync)
            {
                await DbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteAsync(TId id, bool saveChangesAsync = true, CancellationToken cancellationToken = default)
        {
            var entity = await DbContext.Set<TEntity>().FindAsync([id], cancellationToken);
            if (entity != null)
            {
                DbContext.Set<TEntity>().Remove(entity);
                if (saveChangesAsync) await DbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteAsync(IEnumerable<TId> ids, bool saveChangesAsync = true, CancellationToken cancellationToken = default)
        {
            var entities = await DbContext.Set<TEntity>().Where(e => ids.Contains(e.Id)).ToListAsync(cancellationToken);
            DbContext.Set<TEntity>().RemoveRange(entities);
            if (saveChangesAsync)
            {
                await DbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task UpdateAsync(TDto item, bool saveChangesAsync = true, CancellationToken cancellationToken = default)
        {
            var entity = Mapper.Map<TEntity>(item);
            DbContext.Set<TEntity>().Update(entity);
            if (saveChangesAsync)
            {
                await DbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task UpdateAsync(IEnumerable<TDto> items, bool saveChangesAsync = true, CancellationToken cancellationToken = default)
        {
            var entities = Mapper.Map<IEnumerable<TEntity>>(items);
            DbContext.Set<TEntity>().UpdateRange(entities);
            if (saveChangesAsync)
            {
                await DbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
