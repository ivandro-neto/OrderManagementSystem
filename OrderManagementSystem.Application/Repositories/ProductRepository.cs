using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Infrastructure;
using OrderManagementSystem.Infrastructure.Entities;

namespace OrderManagementSystem.Application.Repositories;

public interface IProductRepository
{
    Task<Product> GetProductByIdAsync(Guid productId);
    Task<List<Product>> GetProductsAsync();
}

public class ProductRepository : IProductRepository
{
    private OrderManagementSystemContext _context;
    public ProductRepository(OrderManagementSystemContext context)
    {
        _context = context;
    }

    public async Task<Product> GetProductByIdAsync(Guid productId)
    {
        return await _context.Products.FirstOrDefaultAsync((prod) => prod.Id == productId);
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }
}