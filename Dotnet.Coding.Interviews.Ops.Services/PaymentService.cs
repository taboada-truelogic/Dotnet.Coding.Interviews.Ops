using Dotnet.Coding.Interviews.Ops.Models;

namespace Dotnet.Coding.Interviews.Ops.Services;

public class PaymentService : IPaymentService
{
    public Task<bool> ProcessPaymentAsync(int orderId, decimal amount)
    {
        throw new NotImplementedException();
    }
}
