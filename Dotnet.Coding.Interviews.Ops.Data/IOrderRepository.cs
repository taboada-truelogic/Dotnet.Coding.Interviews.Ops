using Dotnet.Coding.Interviews.Ops.Models;

namespace Dotnet.Coding.Interviews.Ops.Data;

public interface IOrderRepository
{
    Task AddOrderAsync(Order order);
    Task<IEnumerable<Order>> ListOrdersAsync();
    Task<Order> FindOrderByIdAsync(int id);
    Task UpdateOrderAsync(Order order);
    Task RemoveOrderAsync(int id);
}
