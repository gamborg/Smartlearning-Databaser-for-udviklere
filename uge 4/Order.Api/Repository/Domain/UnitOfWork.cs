using OrderApi.Data;
using OrderApi.Repository;
using OrderApi.Repository.Domain.Interfaces;

namespace OrderApi.Repository.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderDbContext _context;

        public ICustomerRepository Customers { get; private set; }

        public IOrderRepository Orders { get; private set; }

        public IOrderItemRepository OrderItems { get; private set; }

        public IProductRepository Products { get; private set; }

        public ISupplierRepository Suppliers { get; private set; }

        public UnitOfWork(OrderDbContext context)
        {
            _context = context;

            Customers = new CustomerRepository(_context);
            Orders = new OrderRepository(_context);
            OrderItems = new OrderItemRepository(_context);
            Products = new ProductRepository(_context);
            Suppliers = new SupplierRepository(_context);
        }

        public int Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
