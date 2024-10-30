using System.Net.Mime;
using Dotnet.Coding.Interviews.Ops.Models;
using Dotnet.Coding.Interviews.Ops.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.Coding.Interviews.Ops.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IInventoryService _inventoryService;
        private readonly IPaymentService _paymentService;

        public OrdersController(IOrderService orderService, IInventoryService inventoryService, IPaymentService paymentService)
        {
            _orderService = orderService;
            _inventoryService = inventoryService;
            _paymentService = paymentService;
        }

        /// <summary>
        /// Creates a new Order after checking Stock and processing Payment
        /// </summary>
        /// <param name="inventoryId">Inventory ID</param>
        /// <param name="quantity">Order Quantity</param>
        /// <param name="paymentAmount">Payment Amount</param>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrderAsync(int inventoryId, int quantity, decimal paymentAmount)
        {
            if (!await _inventoryService.CheckStockAsync(inventoryId, quantity))
            {
                return BadRequest("Insufficient Stock for the requested Quantity.");
            }

            var order = await _orderService.CreateOrderAsync(inventoryId, quantity);

            if (!await _paymentService.ProcessPaymentAsync(order.Id, paymentAmount))
            {
                return BadRequest("Payment processing failed.");
            }

            if (!await _inventoryService.AdjustStockAsync(inventoryId, quantity))
            {
                return BadRequest("Inventory adjustment failed.");
            }


            return CreatedAtAction(nameof(GetOrderAsync), new { id = order.Id }, order);
        }

        /// <summary>
        /// Retrieves all Orders
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersAsync()
        {
            var orders = await _orderService.GetAllOrdersAsync();

            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }

        /// <summary>
        /// Retrieves an Order by ID
        /// </summary>
        /// <param name="id">Order ID</param>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderAsync(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        /// <summary>
        /// Updates an existing Order
        /// </summary>
        /// <param name="id">Order ID</param>
        /// <param name="order">Order</param>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderAsync(int id, [FromBody] Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            var updated = await _orderService.UpdateOrderAsync(order);

            if (updated == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes an Order by ID
        /// </summary>
        /// <param name="id">Order ID</param>
        /// <response code="204">No Content</response>
        /// <response code="404">Not Found</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            var deleted = await _orderService.DeleteOrderAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
