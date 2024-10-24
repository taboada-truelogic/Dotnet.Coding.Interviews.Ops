using Dotnet.Coding.Interviews.Ops.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Coding.Interviews.Ops.Data;

public class OrderRepository : IOrderRepository
{
    private readonly OpsDbContext _dbContext;

    public OrderRepository(OpsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateOrderAsync(Order order)
    {
        await _dbContext.Orders.AddAsync(order);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteOrderAsync(int id)
    {
        var order = await _dbContext.Orders.FindAsync(id);
        if (order != null)
        {
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _dbContext.Orders.ToListAsync();
    }

public async Task<Order> GetOrderByIdAsync(int id)
{
    var order = await _dbContext.Orders.FindAsync(id) ?? throw new KeyNotFoundException($"Order with id {id} not found.");
        return order;
}

    public async Task UpdateOrderAsync(Order order)
    {
        _dbContext.Orders.Update(order);
        await _dbContext.SaveChangesAsync();
    }
}
