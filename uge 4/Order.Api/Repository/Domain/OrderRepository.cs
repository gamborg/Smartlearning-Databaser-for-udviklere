using OrderApi.Data;
using OrderApi.Models;
using OrderApi.Repository.Base;
using OrderApi.Repository.Domain.Interfaces;

namespace OrderApi.Repository.Domain
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderDbContext context) : base(context)
        {

        }
    }
}
