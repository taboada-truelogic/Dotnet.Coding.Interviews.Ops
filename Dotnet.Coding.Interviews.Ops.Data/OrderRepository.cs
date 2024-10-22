using Dotnet.Coding.Interviews.Ops.Models;

namespace Dotnet.Coding.Interviews.Ops.Data;

public class OrderRepository : IOrderRepository
{
    public Task CreateOrderAsync(Order order)
    {
        throw new NotImplementedException();
    }

    public Task DeleteOrderAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Order> GetOrderByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOrderAsync(Order order)
    {
        throw new NotImplementedException();
    }
}
