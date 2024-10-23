using Dotnet.Coding.Interviews.Ops.Models;

namespace Dotnet.Coding.Interviews.Ops.Services;

public interface IInventoryService
{
    Task<bool> CheckStockAsync(int inventoryId);
    Task<bool> ReduceStockAsync(int inventoryId, int quantity);
}
