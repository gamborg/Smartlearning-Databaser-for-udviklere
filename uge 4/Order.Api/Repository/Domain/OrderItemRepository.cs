using OrderApi.Data;
using OrderApi.Models;
using OrderApi.Repository.Base;
using OrderApi.Repository.Domain.Interfaces;

namespace OrderApi.Repository.Domain
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(OrderDbContext context) : base(context)
        {

        }
    }
}
