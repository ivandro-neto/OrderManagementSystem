using OrderManagementSystem.Application.Repositories;
using OrderManagementSystem.Infrastructure.Entities;

namespace OrderManagementSystem.Application.UseCases.OrderUseCase;

public class GetOrdersUseCase
{
    private IOrderRepository _repository;

    public GetOrdersUseCase(IOrderRepository orderRepository)
    {
        _repository = orderRepository;
    }

    public async Task<List<Order>> Execute()
    {
        return await _repository.GetOrders();
    }
}