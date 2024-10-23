using Dotnet.Coding.Interviews.Ops.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotnet.Coding.Interviews.Ops.Services
{
    public class OrderService : IOrderService
    {
        public Task<Order> CreateOrderAsync(int inventoryId, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
