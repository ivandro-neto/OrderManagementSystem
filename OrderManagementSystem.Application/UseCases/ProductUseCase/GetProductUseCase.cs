using OrderManagementSystem.Application.Repositories;
using OrderManagementSystem.Infrastructure.Entities;

namespace OrderManagementSystem.Application.UseCases.ProductUseCase;

public class GetProductUseCase
{
    private IProductRepository _repository;

    public GetProductUseCase(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> Execute(Guid id)
    {
        return await _repository.GetProductByIdAsync(id);
    }
}
