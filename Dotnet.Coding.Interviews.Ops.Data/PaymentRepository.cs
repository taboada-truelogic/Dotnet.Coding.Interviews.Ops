using Dotnet.Coding.Interviews.Ops.Models;

namespace Dotnet.Coding.Interviews.Ops.Data;

public class PaymentRepository : IPaymentRepository
{
    public Task CreatePaymentAsync(Payment payment)
    {
        throw new NotImplementedException();
    }

    public Task DeletePaymentAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Payment>> GetAllPaymentsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Payment> GetPaymentByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePaymentAsync(Payment payment)
    {
        throw new NotImplementedException();
    }
}
