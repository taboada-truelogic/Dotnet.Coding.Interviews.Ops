using Dotnet.Coding.Interviews.Ops.Models;

namespace Dotnet.Coding.Interviews.Ops.Data;

public interface IPaymentRepository
{
    Task CreatePaymentAsync(Payment payment);
    Task<Payment> GetPaymentByIdAsync(int id);
    Task<IEnumerable<Payment>> GetAllPaymentsAsync();
    Task UpdatePaymentAsync(Payment payment);
    Task DeletePaymentAsync(int id);
}
