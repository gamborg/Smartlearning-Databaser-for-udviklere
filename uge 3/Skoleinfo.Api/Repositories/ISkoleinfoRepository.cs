using Skoleinfo.Api.Endpoints;
using System.Linq.Expressions;

public interface ISkoleinfoRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>>? includeProperty = null);
    Task<T?> GetByIdAsync(Guid id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<TrivselDataDto>> GetTrivselDataAsync(int institutionsnummer);
}

