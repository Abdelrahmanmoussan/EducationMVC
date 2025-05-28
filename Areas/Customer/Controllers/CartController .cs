using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using IdentityText.Models;

namespace IdentityText.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(ICartRepository cartRepository, UserManager<ApplicationUser> userManager)
        {
            _cartRepository = cartRepository;
             _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            
            var currentUser = await _userManager.GetUserAsync(User);
            var userId = currentUser.Id;
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
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
