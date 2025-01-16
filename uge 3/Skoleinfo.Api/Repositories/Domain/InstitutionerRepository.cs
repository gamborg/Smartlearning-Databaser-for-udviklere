using Microsoft.EntityFrameworkCore;
using Skoleinfo.Api.Models;
using Skoleinfo.Api.Repositories.Base;
using System.Linq.Expressions;

namespace Skoleinfo.Api.Repositories.Domain
{
    public class InstitutionerRepository : Repository<Institutioner>, IInstitutioner
    {
        public InstitutionerRepository(DbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Institutioner>> GetInstitutionerAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Institutioner?> GetInstitutionerByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Institutioner>> GetInstitutionerByKommunenummerAsync(int kommunenummer)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Institutioner>> GetInstitutionerByNavnAsync(string navn)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Institutioner>> GetInstitutionerByNummerAsync(int nummer)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Institutioner>> GetInstitutionerWithKaraktererAsync()
        {
            var result = await _context.Set<Institutioner>().Include(i => i.Karakterers).ToListAsync();
            return result;
        }
    }
}
