using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Exceptions;
using OrderManagementSystem.Infrastructure;
using OrderManagementSystem.Infrastructure.Entities;

namespace OrderManagementSystem.Application.Repositories;

public interface IOrderRepository
{
   Task AddOrderAsync(Order order);
   Task<List<Order>> GetOrders();
   Task<Order> GetOrderByIdAsync(Guid id);
   Task<Order> UpdateOrderStatusAsync(Guid id, string status);
}

public class OrderRepository : IOrderRepository
{
    private OrderManagementSystemContext _context;

    public OrderRepository(OrderManagementSystemContext context)
    {
        _context = context;
    }

    public async Task AddOrderAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task<Order> GetOrderByIdAsync(Guid id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(order => order.Id == id);

        if (order is null)
        {
            throw new NotFoundException("Order not found.");
        }

        return order;
    }

    public async Task<List<Order>> GetOrders()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order> UpdateOrderStatusAsync(Guid id, string status)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(order => order.Id == id);

        if (order is null)
        {
            throw new NotFoundException("Order not found.");
        }

        order.Status = status;
        await _context.SaveChangesAsync();

        return order;
    }
}