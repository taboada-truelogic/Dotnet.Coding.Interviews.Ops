using Dotnet.Coding.Interviews.Ops.Models;

namespace Dotnet.Coding.Interviews.Ops.Services;

public interface IPaymentService
{
    Task<bool> ProcessPaymentAsync(int orderId, decimal amount);
}
