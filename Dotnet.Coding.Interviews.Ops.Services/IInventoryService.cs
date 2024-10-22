using Dotnet.Coding.Interviews.Ops.Models;

namespace Dotnet.Coding.Interviews.Ops.Services;

public interface IInventoryService
{
    Task<bool> CheckStockAsync(int productId);
    Task<bool> ReduceStockAsync(int productId, int quantity);
}
