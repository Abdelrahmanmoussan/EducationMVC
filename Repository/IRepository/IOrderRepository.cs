using IdentityText.Models;

namespace IdentityText.Repository.IRepository
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(string userId, IEnumerable<CartItem> cartItems);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
    }

}
