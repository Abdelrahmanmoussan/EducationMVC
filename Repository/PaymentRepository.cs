using IdentityText.Data;
using IdentityText.Models;
using IdentityText.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace IdentityText.Repository
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PaymentRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
            _dbContext = appDbContext;
        }


        public async Task<decimal> GetTodaySalesAsync()
        {
            var today = DateTime.Today;
            return await _dbContext.Payments
                .Where(p => p.PaymentDate == today)
                .SumAsync(p => p.Amount);
        }

        public async Task<decimal> GetTotalRevenueAsync()
        {
            return await _dbContext.Payments.SumAsync(p => p.Amount);
        }
    }
}
