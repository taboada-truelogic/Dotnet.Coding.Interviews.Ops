using Dotnet.Coding.Interviews.Ops.Models;

namespace Dotnet.Coding.Interviews.Ops.Data;

public interface IPaymentRepository
{
    Task AddPaymentAsync(Payment payment);
    Task<IEnumerable<Payment>> ListPaymentsAsync();
    Task<Payment> FindPaymentByIdAsync(int id);
    Task UpdatePaymentAsync(Payment payment);
    Task RemovePaymentAsync(int id);
}
