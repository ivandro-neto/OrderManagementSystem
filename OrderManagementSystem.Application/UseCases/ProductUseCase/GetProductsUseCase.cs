using OrderManagementSystem.Application.Repositories;
using OrderManagementSystem.Application.Services.Caching;
using OrderManagementSystem.Infrastructure.Entities;

namespace OrderManagementSystem.Application.UseCases.ProductsUseCase;

public class GetProductsUseCase
{
    private IProductRepository _repository;
    private readonly IRedisCachingService _cache;
    public GetProductsUseCase(IProductRepository repository, IRedisCachingService cache)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task<List<Product>> Execute()
    {
        var products = _cache.GetData<IEnumerable<Product>>("products");

        if (products is not null){
            return products.ToList();
        }

        products = await _repository.GetProductsAsync();
        _cache.SetData("products", products);

        return products.ToList();
        
    }
}
