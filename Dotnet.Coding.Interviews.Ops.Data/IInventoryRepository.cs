using Dotnet.Coding.Interviews.Ops.Models;

namespace Dotnet.Coding.Interviews.Ops.Data;

public interface IInventoryRepository
{
    Task CreateInventoryAsync(Inventory inventory);
    Task<IEnumerable<Inventory>> GetAllInventoriesAsync();
    Task<Inventory> GetInventoryByIdAsync(int id);
    Task UpdateInventoryAsync(Inventory inventory);
    Task DeleteInventoryAsync(int id);
}
