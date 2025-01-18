using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using OrderApi.Data;
using OrderApi.Models;
using OrderApi.Repository.Base;
using OrderApi.Repository.Domain.Interfaces;

namespace OrderApi.Repository.Domain
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OrderDbContext context) : base(context)
        {
            
        }

        public async Task<Customer> GetWithOrdersAsync(int id)
        {
            return await _context.Customers
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
