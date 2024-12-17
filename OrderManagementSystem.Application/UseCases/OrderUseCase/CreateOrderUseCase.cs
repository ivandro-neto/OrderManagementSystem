using OrderManagementSystem.Application.Repositories;
using OrderManagementSystem.Communication.Requests;
using OrderManagementSystem.Infrastructure.Entities;

namespace OrderManagementSystem.Application.UseCases.OrderUseCase;
public class CreateOrderUseCase
{
    private IOrderRepository _orderRepository;
  

    public CreateOrderUseCase(IOrderRepository orderRepository, IProductRepository productRepository, IClientRepository clientRepository)
    {
        _orderRepository = orderRepository;
       
    }

    public async Task Execute(OrderCreationRequestJson orderRequest)
    {
       
        
        Order order = new()
        {
            ClientId = orderRequest.ClientId,
            ProductId = orderRequest.productId,
            Status = orderRequest.Status,
        };

        await _orderRepository.AddOrderAsync(order);


    }
}
