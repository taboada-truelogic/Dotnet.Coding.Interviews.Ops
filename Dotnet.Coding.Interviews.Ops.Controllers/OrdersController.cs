using Dotnet.Coding.Interviews.Ops.Models;
using Dotnet.Coding.Interviews.Ops.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.Coding.Interviews.Ops.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        // GET: api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        // GET: api/orders/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST: api/orders
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(int inventoryId, int quantity, decimal paymentAmount)
        {
            // Check inventory before creating order
            if (!await _inventoryService.CheckStockAsync(inventoryId))
            {
                return BadRequest("Insufficient stock for the requested product.");
            }

            var createdOrder = await _orderService.CreateOrderAsync(inventoryId, quantity);

            // Process payment after creating the order
            var paymentSuccessful = await _paymentService.ProcessPaymentAsync(createdOrder.Id, paymentAmount);
            if (!paymentSuccessful)
            {
                return BadRequest("Payment processing failed.");
            }

            // Reduce stock after successful payment
            await _inventoryService.ReduceStockAsync(inventoryId, quantity);

            return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.Id }, createdOrder);
        }

        // PUT: api/orders/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            var updatedOrder = await _orderService.UpdateOrderAsync(order);
            if (updatedOrder == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/orders/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
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
