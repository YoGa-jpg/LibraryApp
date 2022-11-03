using LibraryApp.Domain.Core;
using LibraryApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public readonly IOrderService _orderService;
        public readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrderService orderService, ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <remarks>Sample request: GET /orders</remarks>
        /// <returns>Returns IEnumerable of orders</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Order not found</response>
        /// <response code="500">Any exception</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllOrders()
        {
            var response = await _orderService.GetOrders();
            if (response.Result.Succeeded)
            {
                return Ok(response.Orders);
            }

            return StatusCode((int)response.Result.Error.Key);
        }

        /// <summary>
        /// Get order by ID
        /// </summary>
        /// <remarks>Sample request: GET /orders/{5}</remarks>
        /// <returns>Returns order object</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Order not found</response>
        /// <response code="422">Bad ID</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> GetOrder(int id)
        {
            var response = await _orderService.GetOrder(id);
            if (response.Result.Succeeded)
            {
                return Ok(response.Order);
            }

            return StatusCode((int)response.Result.Error.Key);
        }

        /// <summary>
        /// Create order by object
        /// </summary>
        /// <remarks>Sample request: POST /orders {
        ///  "orderDate": "2022-11-03T19:46:39.019Z",
        ///  "expireDate": "2022-11-03T19:46:39.019Z",
        ///  "readerId": 1,
        ///  "bookId": 2
        ///}</remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Incorrect data provided</response>
        /// <response code="500">Any exception</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            var response = await _orderService.CreateOrder(order);
            if (response.Result.Succeeded)
            {
                _logger.LogWarning($"Created order: {order.Id}");
                return Ok(response.Id);
            }

            return StatusCode((int)response.Result.Error.Key);
        }

        /// <summary>
        /// Update order by another
        /// </summary>
        /// <remarks>Sample request: PUT /orders {
        /// "id": 2,
        ///  "orderDate": "2022-11-03T19:46:39.019Z",
        ///  "expireDate": "2022-11-03T19:46:39.019Z",
        ///  "readerId": 1,
        ///  "bookId": 2
        ///}</remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Incorrect data provided</response>
        /// <response code="404">Order for updating not found</response>
        /// <response code="500">Any exception</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateOrder([FromBody] Order order)
        {
            var response = await _orderService.UpdateOrder(order);
            if (response.Result.Succeeded)
            {
                _logger.LogWarning($"Updated order: ID({order.Id})");
                return Ok();
            }

            return StatusCode((int)response.Result.Error.Key);
        }

        /// <summary>
        /// Delete order by ID
        /// </summary>
        /// <remarks>Sample request: DELETE /orders/{6}</remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Incorrect data provided</response>
        /// <response code="404">Order for deletion not found</response>
        /// <response code="500">Any exception</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var response = await _orderService.DeleteOrder(id);
            if (response.Result.Succeeded)
            {
                _logger.LogWarning($"Deleted order: ({id})");
                return Ok();
            }

            return StatusCode((int)response.Result.Error.Key);
        }
    }
}
