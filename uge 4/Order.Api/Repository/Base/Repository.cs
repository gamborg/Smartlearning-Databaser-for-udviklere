using Microsoft.EntityFrameworkCore;
using OrderApi.Data;
using System.Linq.Expressions;

namespace OrderApi.Repository.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly OrderDbContext _context;

        public Repository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var query = _context.Set<TEntity>().Where(predicate);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return;
        }

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            return;
        }
    }
}
