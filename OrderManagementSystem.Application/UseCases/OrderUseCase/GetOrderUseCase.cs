using OrderManagementSystem.Application.Repositories;
using OrderManagementSystem.Infrastructure.Entities;

namespace OrderManagementSystem.Application.UseCases.OrderUseCase;

public class GetOrderUseCase
{
    private IOrderRepository _repository;

    public GetOrderUseCase(IOrderRepository orderRepository)
    {
        _repository = orderRepository;
    }

    public async Task<Order> Execute(Guid id)
    {
        return await _repository.GetOrderByIdAsync(id);
    }
}