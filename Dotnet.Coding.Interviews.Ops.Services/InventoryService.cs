using Dotnet.Coding.Interviews.Ops.Models;

namespace Dotnet.Coding.Interviews.Ops.Services;

public class InventoryService : IInventoryService
{
    public Task<bool> CheckStockAsync(int productId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ReduceStockAsync(int productId, int quantity)
    {
        throw new NotImplementedException();
    }
}
