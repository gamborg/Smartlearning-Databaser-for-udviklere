using Skoleinfo.Api.Endpoints;
using Skoleinfo.Api.Models;

namespace Skoleinfo.Api.Repositories.Domain
{
    public interface IInstitutioner : IRepository<Institutioner>
    {

        Task<IEnumerable<Institutioner>> GetInstitutionerAsync();

        Task<Institutioner?> GetInstitutionerByIdAsync(Guid id);

        Task<IEnumerable<Institutioner>> GetInstitutionerWithKaraktererAsync();

        Task<IEnumerable<Institutioner>> GetInstitutionerByKommunenummerAsync(int kommunenummer);

        Task<IEnumerable<Institutioner>> GetInstitutionerByNavnAsync(string navn);

        Task<IEnumerable<Institutioner>> GetInstitutionerByNummerAsync(int nummer);

    }
}
