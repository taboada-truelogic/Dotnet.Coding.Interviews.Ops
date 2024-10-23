using Dotnet.Coding.Interviews.Ops.Models;

namespace Dotnet.Coding.Interviews.Ops.Services;

public class InventoryService : IInventoryService
{
    public Task<bool> CheckStockAsync(int inventoryId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ReduceStockAsync(int inventoryId, int quantity)
    {
        throw new NotImplementedException();
    }
}
