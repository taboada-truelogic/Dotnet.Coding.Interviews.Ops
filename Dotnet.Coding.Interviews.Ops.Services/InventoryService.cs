using Dotnet.Coding.Interviews.Ops.Models;

namespace Dotnet.Coding.Interviews.Ops.Services;

public class InventoryService : IInventoryService
{
    public Task<bool> CheckStockAsync(int inventoryId, int quantity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AdjustStockAsync(int inventoryId, int quantity)
    {
        throw new NotImplementedException();
    }
}
