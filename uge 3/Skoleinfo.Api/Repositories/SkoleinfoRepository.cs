using Microsoft.EntityFrameworkCore;
using Skoleinfo.Api.Endpoints;
using Skoleinfo.Api.Models;
using System.Linq.Expressions;

namespace Skoleinfo.Api.Repositories
{
    public class SkoleinfoRepository<T> : ISkoleinfoRepository<T> where T : class
    {
        private readonly SkoleinfoContext _context;
        private readonly DbSet<T> _dbSet;

        public SkoleinfoRepository(SkoleinfoContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>>? includeProperty = null)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();

            if (includeProperty != null)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            _dbSet.AsNoTracking();
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TrivselDataDto>> GetTrivselDataAsync(int institutionsnummer)
        {
            var result = await (from trivsel in _context.Trivsels
                                join sporgsmaal in _context.Sporgsmaals on trivsel.Sporgsmaalsnummer equals sporgsmaal.Nummer
                                join svar in _context.Svars on new { trivsel.Sporgsmaalsnummer, trivsel.Svarnummer } equals new { svar.Sporgsmaalsnummer, svar.Svarnummer }
                                where trivsel.Institutionsnummer == institutionsnummer
                                select new TrivselDataDto
                                {
                                    TrivselID = trivsel.Id,
                                    Institutionsnummer = trivsel.Institutionsnummer.HasValue ? trivsel.Institutionsnummer.Value : 0,
                                    Koen = trivsel.Koen,
                                    Vaerdi = trivsel.Vaerdi,
                                    SporgsmaalTekst = sporgsmaal.Tekst,
                                    SvarTekst = svar.Tekst
                                }).ToListAsync();

            return result;
        }
    }
}

