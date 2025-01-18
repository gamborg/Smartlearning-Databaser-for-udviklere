using OrderApi.Data;
using OrderApi.Models;
using OrderApi.Repository.Base;
using OrderApi.Repository.Domain.Interfaces;

namespace OrderApi.Repository.Domain
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(OrderDbContext context) : base(context)
        {

        }
    }
}
