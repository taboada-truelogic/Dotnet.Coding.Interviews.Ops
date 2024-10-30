using Dotnet.Coding.Interviews.Ops.Models;

namespace Dotnet.Coding.Interviews.Ops.Data;

public interface IInventoryRepository
{
    Task AddInventoryAsync(Inventory inventory);
    Task<IEnumerable<Inventory>> ListInventoriesAsync();
    Task<Inventory> FindInventoryByIdAsync(int id);
    Task UpdateInventoryAsync(Inventory inventory);
    Task RemoveInventoryAsync(int id);
}
