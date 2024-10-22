using Dotnet.Coding.Interviews.Ops.Models;

namespace Dotnet.Coding.Interviews.Ops.Data;

public interface IInventoryRepository
{
    Task<Inventory> GetInventoryByIdAsync(int id);
    Task<IEnumerable<Inventory>> GetAllInventoriesAsync();
    Task CreateInventoryAsync(Inventory inventory);
    Task UpdateInventoryAsync(Inventory inventory);
    Task DeleteInventoryAsync(int id);
}
