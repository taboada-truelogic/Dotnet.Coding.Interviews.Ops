using Dotnet.Coding.Interviews.Ops.Models;

namespace Dotnet.Coding.Interviews.Ops.Services;

public interface IInventoryService
{
    Task<bool> CheckStockAsync(int inventoryId, int quantity);
    Task<bool> AdjustStockAsync(int inventoryId, int quantity);
}
