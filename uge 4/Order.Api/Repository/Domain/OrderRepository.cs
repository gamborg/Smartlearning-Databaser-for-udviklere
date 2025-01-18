using OrderApi.Data;
using OrderApi.Models;
using OrderApi.Repository.Base;
using OrderApi.Repository.Domain.Interfaces;

namespace OrderApi.Repository.Domain
{
    public class OrderRepository : Repository<Models.Order>, IOrderRepository
    {
        public OrderRepository(OrderDbContext context) : base(context)
        {

        }

        public Task<Order> GetOrderWithCustomerAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
