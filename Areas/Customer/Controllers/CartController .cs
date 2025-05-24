using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityText.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.Identity.Name;
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int classGroupId, int quantity = 1)
        {
            var userId = User.Identity.Name;
            await _cartRepository.AddToCartAsync(userId, classGroupId, quantity);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int classGroupId)
        {
            var userId = User.Identity.Name;
            await _cartRepository.RemoveFromCartAsync(userId, classGroupId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ClearCart()
        {
            var userId = User.Identity.Name;
            await _cartRepository.ClearCartAsync(userId);
            return RedirectToAction(nameof(Index));
        }
    }
}
