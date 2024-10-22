using Dotnet.Coding.Interviews.Ops.Models;

namespace Dotnet.Coding.Interviews.Ops.Services;

public interface IOrderService
{
    Task<Order> CreateOrderAsync(int productId, int quantity);
    Task<Order> GetOrderByIdAsync(int orderId);
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<Order> UpdateOrderAsync(Order order);
    Task<bool> DeleteOrderAsync(int orderId);
}
