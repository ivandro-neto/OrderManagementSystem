using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OrderManagementSystem.Infrastructure
{
    public class OrderManagementSystemContextFactory : IDesignTimeDbContextFactory<OrderManagementSystemContext>
    {
        public OrderManagementSystemContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderManagementSystemContext>();
            optionsBuilder.UseSqlServer( "Server=NBUCLDSI-28\\SQLEXPRESS;Database=OrderManagement;Integrated Security=True; TrustServerCertificate=True;");

            return new OrderManagementSystemContext(optionsBuilder.Options);
        }
    }
}
