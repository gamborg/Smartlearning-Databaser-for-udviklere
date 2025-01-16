using Skoleinfo.Api.Models;
using Skoleinfo.Api.Repositories.Domain;

namespace Skoleinfo.Api.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IInstitutioner Institutioner { get; }

        int Complete();
    }
}
