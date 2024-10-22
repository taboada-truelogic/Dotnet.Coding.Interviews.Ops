using Dotnet.Coding.Interviews.Ops.Models;

namespace Dotnet.Coding.Interviews.Ops.Data;

public interface IOrderRepository
{
    Task<Order> GetOrderByIdAsync(int id);
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task CreateOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(int id);

    // Additional order-specific methods can be added here
    Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId);
}
