// Dotnet.Coding.Interviews.Ops/Data/OpsDbContext.cs

using Dotnet.Coding.Interviews.Ops.Models; // Adjust the namespace according to your project structure
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Coding.Interviews.Ops.Data
{
    public class OpsDbContext : DbContext
    {
        public OpsDbContext(DbContextOptions<OpsDbContext> options) : base(options)
        {
        }

        // DbSet properties for your entities
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships and any additional configurations here
        }
    }
}
