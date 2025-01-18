using OrderApi.Data;
using OrderApi.Models;
using OrderApi.Repository.Base;
using OrderApi.Repository.Domain.Interfaces;

namespace OrderApi.Repository.Domain
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(OrderDbContext context) : base(context)
        {

        }
    }
}
