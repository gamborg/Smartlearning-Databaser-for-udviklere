using OrderApi.Models;
using OrderApi.Repository.Base;

namespace OrderApi.Repository.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Models.Order>
    {
        Task<Order> GetOrderWithCustomerAsync(int id);
    }
}
