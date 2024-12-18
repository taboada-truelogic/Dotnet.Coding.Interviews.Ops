using Dotnet.Coding.Interviews.Ops.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Coding.Interviews.Ops.Data
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly OpsDbContext _context;

        public PaymentRepository(OpsDbContext context)
        {
            _context = context;
        }

        public async Task AddPaymentAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Payment>> ListPaymentsAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment> FindPaymentByIdAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id) ?? throw new KeyNotFoundException($"Payment with id {id} not found.");
            return payment;
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
        }

        public async Task RemovePaymentAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
