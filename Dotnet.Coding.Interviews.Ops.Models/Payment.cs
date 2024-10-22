namespace Dotnet.Coding.Interviews.Ops.Models;

public class Payment
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public decimal Amount { get; set; }
    public bool IsSuccessful { get; set; }
}
