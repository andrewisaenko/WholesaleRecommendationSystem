using Microsoft.AspNetCore.Mvc;
using WholesaleRecommendationSystem.Services;

namespace WholesaleRecommendationSystem.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            var cart = _cartService.GetCart();
            return View(cart);
        }

        public async Task<IActionResult> Add(int id)
        {
            await _cartService.AddToCartAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            _cartService.RemoveFromCart(id);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            _cartService.ClearCart();
            return RedirectToAction("Index");
        }
    }
}
