using Dotnet.Coding.Interviews.Ops.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Coding.Interviews.Ops.Data
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly OpsDbContext _context;

        public InventoryRepository(OpsDbContext context)
        {
            _context = context;
        }

        public async Task CreateInventoryAsync(Inventory inventory)
        {
            await _context.Inventories.AddAsync(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Inventory>> GetAllInventoriesAsync()
        {
            return await _context.Inventories.ToListAsync();
        }

        public async Task<Inventory> GetInventoryByIdAsync(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id) ?? throw new KeyNotFoundException($"Inventory with id {id} not found.");
            return inventory;
        }

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            _context.Inventories.Update(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInventoryAsync(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory != null)
            {
                _context.Inventories.Remove(inventory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
