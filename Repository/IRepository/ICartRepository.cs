using IdentityText.Models;

namespace IdentityText.Repository.IRepository
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByUserIdAsync(string userId);
        Task AddToCartAsync(string userId, int ClassGroupId, int quantity);
        Task RemoveFromCartAsync(string userId, int ClassGroupId);
        Task ClearCartAsync(string userId);
    }

}
