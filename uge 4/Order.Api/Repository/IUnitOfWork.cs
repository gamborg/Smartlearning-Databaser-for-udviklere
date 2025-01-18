using OrderApi.Repository.Domain.Interfaces;

namespace OrderApi.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        
        IOrderRepository Orders { get; }
        
        IOrderItemRepository OrderItems { get; }
        
        IProductRepository Products { get; }
        ISupplierRepository Suppliers { get; }

        int Complete();
    }
}
