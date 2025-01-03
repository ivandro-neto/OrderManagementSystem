using OrderManagementSystem.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace OrderManagementSystem.Infrastructure
{
    public class OrderManagementSystemContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public OrderManagementSystemContext(DbContextOptions<OrderManagementSystemContext> options) : base(options)
        {

        }

        public OrderManagementSystemContext()
        {
        }

    }
}
