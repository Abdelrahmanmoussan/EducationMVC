using IdentityText.Models;

namespace IdentityText.Repository.IRepository
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<decimal> GetTodaySalesAsync();
       Task<decimal> GetTotalRevenueAsync();
    }
}
