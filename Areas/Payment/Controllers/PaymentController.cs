using IdentityText.Repository.IRepository;
using IdentityText.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IdentityText.Areas.Payment.Controllers
{
    
    public class PaymentController : Controller
    {
        private readonly PaymentService _paymentService;
        private readonly ICartRepository _cartRepository;

        public PaymentController(PaymentService paymentService, ICartRepository cartRepository)
        {
            _paymentService = paymentService;
            _cartRepository = cartRepository;
        }

        public async Task<IActionResult> Checkout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            var sessionUrl = await _paymentService.CreateCheckoutSessionAsync(cart.Items.ToList());
            return Redirect(sessionUrl);
        }
    }

}
