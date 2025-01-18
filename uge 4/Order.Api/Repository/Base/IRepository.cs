using System.Linq.Expressions;

namespace OrderApi.Repository.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task RemoveAsync(TEntity id);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
}
