using Microsoft.EntityFrameworkCore;
using OrderApi.Models;

namespace OrderApi.Data
{
    public class OrderDbContext(DbContextOptions<OrderDbContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Models.Order> Orders => Set<Models.Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-JLTE9PJ\\SQLEXPRESS;Database=OrderApi;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
