using Microsoft.EntityFrameworkCore;
using Skoleinfo.Api.Models;
using Skoleinfo.Api.Repositories.Domain;
using System.Data;

namespace Skoleinfo.Api.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public IInstitutioner Institutioner { get; }

        public UnitOfWork(SkoleinfoContext dbcontext)
        {
            _context = dbcontext;
            Institutioner = new InstitutionerRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
