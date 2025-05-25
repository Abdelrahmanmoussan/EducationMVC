using IdentityText.Data;
using IdentityText.Models;
using IdentityText.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace IdentityText.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            return await _context.Carts
                .Include(c => c.Items)
                    .ThenInclude(i => i.ClassGroup)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task AddToCartAsync(string userId, int ClassGroupId, int quantity)
        {
            var cart = await GetCartByUserIdAsync(userId) ?? new Cart { UserId = userId, Items = new List<CartItem>() };

            var existingItem = cart.Items.FirstOrDefault(i => i.ClassGroupId == ClassGroupId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cart.Items.Add(new CartItem { ClassGroupId = ClassGroupId, Quantity = quantity });
            }

            if (cart.Id == 0)
                _context.Carts.Add(cart);
            else
                _context.Carts.Update(cart);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromCartAsync(string userId, int ClassGroupId)
        {
            var cart = await GetCartByUserIdAsync(userId);
            if (cart == null) return;

            var item = cart.Items.FirstOrDefault(i => i.ClassGroupId == ClassGroupId);
            if (item != null)
            {
                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ClearCartAsync(string userId)
        {
            var cart = await GetCartByUserIdAsync(userId);
            if (cart != null)
            {
                _context.CartItems.RemoveRange(cart.Items);
                await _context.SaveChangesAsync();
            }
        }
    }

}
