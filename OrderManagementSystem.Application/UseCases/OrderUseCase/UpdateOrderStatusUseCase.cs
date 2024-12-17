using OrderManagementSystem.Application.Repositories;
using OrderManagementSystem.Infrastructure.Entities;

namespace OrderManagementSystem.Application.UseCases.OrderUseCase;
public class UpdateOrderStatusUseCase
{
    private IOrderRepository _orderRepository;

    public UpdateOrderStatusUseCase(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order> Execute(Guid id, string status)
    {
       return await _orderRepository.UpdateOrderStatusAsync(id, status);
    }
}
