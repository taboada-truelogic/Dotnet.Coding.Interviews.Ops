using Dotnet.Coding.Interviews.Ops.Models;

namespace Dotnet.Coding.Interviews.Ops.Data;

public interface IOrderRepository
{
    Task CreateOrderAsync(Order order);
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<Order> GetOrderByIdAsync(int id);
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(int id);
}
