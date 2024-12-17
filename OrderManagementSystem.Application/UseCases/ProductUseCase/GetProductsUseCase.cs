using OrderManagementSystem.Application.Repositories;
using OrderManagementSystem.Infrastructure.Entities;

namespace OrderManagementSystem.Application.UseCases.ProductsUseCase;

public class GetProductsUseCase
{
    private IProductRepository _repository;

    public GetProductsUseCase(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> Execute()
    {
        return await _repository.GetProductsAsync();
    }
}
