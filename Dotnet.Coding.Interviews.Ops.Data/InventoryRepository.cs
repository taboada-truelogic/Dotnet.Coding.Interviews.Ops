using Dotnet.Coding.Interviews.Ops.Models;

namespace Dotnet.Coding.Interviews.Ops.Data;

public class InventoryRepository : IInventoryRepository
{
    public Task CreateInventoryAsync(Inventory inventory)
    {
        throw new NotImplementedException();
    }

    public Task DeleteInventoryAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Inventory>> GetAllInventoriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Inventory> GetInventoryByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateInventoryAsync(Inventory inventory)
    {
        throw new NotImplementedException();
    }
}
