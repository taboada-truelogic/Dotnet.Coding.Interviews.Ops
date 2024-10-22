using Dotnet.Coding.Interviews.Ops.Models;

namespace Dotnet.Coding.Interviews.Ops.Data;

public interface IPaymentRepository
{
    Task<Payment> GetPaymentByIdAsync(int id);
    Task<IEnumerable<Payment>> GetAllPaymentsAsync();
    Task CreatePaymentAsync(Payment payment);
    Task UpdatePaymentAsync(Payment payment);
    Task DeletePaymentAsync(int id);
}
