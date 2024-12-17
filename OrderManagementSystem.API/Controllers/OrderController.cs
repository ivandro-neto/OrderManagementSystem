using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Application.UseCases.OrderUseCase;
using OrderManagementSystem.Communication.Requests;

namespace OrderManagementSystem.API.Controllers
{
    public class OrderController : Controller
    {
        private CreateOrderUseCase _createOrderUseCase;
        private UpdateOrderStatusUseCase _updateOrderStatusUseCase;
        private GetOrdersUseCase _getOrdersUseCase;
        private GetOrderUseCase _getOrderUseCase;
        public OrderController(UpdateOrderStatusUseCase updateOrderStatusUseCase, CreateOrderUseCase createOrderUseCase, GetOrdersUseCase getOrdersUseCase, GetOrderUseCase getOrderUseCase)
        {
            _createOrderUseCase = createOrderUseCase;
            _getOrdersUseCase = getOrdersUseCase;
            _getOrderUseCase = getOrderUseCase;
            _updateOrderStatusUseCase = updateOrderStatusUseCase;
        }

        [HttpGet]
        [Route("orders")]
        public async Task<IActionResult> GetOrders()
        {
            var result = await _getOrdersUseCase.Execute();

            return Ok(result);
        }
        [HttpPost]
        [Route("orders")]
        public async Task<IActionResult> AddOrder([FromBody] OrderCreationRequestJson body)
        {
            await _createOrderUseCase.Execute(body);

            return Created();
        }
        [HttpGet]
        [Route("orders/{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var result = await _getOrderUseCase.Execute(id);
            return Ok(result);
        }
        
        [HttpPatch]
        [Route("orders/{id}")]
        public async Task<IActionResult> GetOrderById(Guid id, [FromBody] string status)
        {
            var result = await _updateOrderStatusUseCase.Execute(id, status);
            return Ok(result);
        }
    }
}
