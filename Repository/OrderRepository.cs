using IdentityText.Data;
using IdentityText.Models;
using IdentityText.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace IdentityText.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(string userId, IEnumerable<CartItem> cartItems)
        {
            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                PaymentStatus = "Pending",
                TotalAmount = cartItems.Sum(i => i.ClassGroup.Price * i.Quantity),
                Items = cartItems.Select(i => new OrderItem
                {
                    ClassGroupId = i.ClassGroupId,
                    Quantity = i.Quantity,
                    UnitPrice = i.ClassGroup.Price
                }).ToList()
            };

            _context.orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
        {
            return await _context.orders
                .Where(o => o.UserId == userId)
                .Include(o => o.Items)
                    .ThenInclude(i => i.ClassGroup)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }
    }

}
