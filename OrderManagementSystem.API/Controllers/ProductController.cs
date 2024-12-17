using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Application.UseCases.ProductsUseCase;
using OrderManagementSystem.Application.UseCases.ProductUseCase;

namespace OrderManagementSystem.API.Controllers
{
    public class ProductController : Controller
    {
        private GetProductsUseCase _getProductsUseCase;
        private GetProductUseCase _getProductUseCase;
        public ProductController(GetProductsUseCase getProductsUseCase, GetProductUseCase getProductUseCase)
        {
            _getProductsUseCase = getProductsUseCase;
            _getProductUseCase = getProductUseCase;
        }

        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _getProductsUseCase.Execute();

            return Ok(result);
        }
        
        [HttpGet]
        [Route("products/{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var result = await _getProductUseCase.Execute(id);
            return Ok(result);
        }
    }
}
