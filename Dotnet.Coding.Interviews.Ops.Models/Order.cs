namespace Dotnet.Coding.Interviews.Ops.Models;

public class Order
{
    public int Id { get; set; }
    public int InventoryId { get; set; }
    public int Quantity { get; set; }
    public bool IsPaid { get; set; }
}
