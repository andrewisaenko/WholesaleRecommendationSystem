using Newtonsoft.Json;
using WholesaleRecommendationSystem.Models;
using WholesaleRecommendationSystem.Repository;

namespace WholesaleRecommendationSystem.Services
{
    public class CartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductRepository _productRepository;
        private const string SessionKey = "Cart";

        public CartService(IHttpContextAccessor httpContextAccessor, IProductRepository productRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _productRepository = productRepository;
        }

        public List<CartItem> GetCart()
        {
            var session = _httpContextAccessor.HttpContext!.Session;
            var cartJson = session.GetString(SessionKey);
            return cartJson != null
                ? JsonConvert.DeserializeObject<List<CartItem>>(cartJson)!
                : new List<CartItem>();
        }

        public void SaveCart(List<CartItem> cart)
        {
            var session = _httpContextAccessor.HttpContext!.Session;
            var cartJson = JsonConvert.SerializeObject(cart);
            session.SetString(SessionKey, cartJson);
        }

        public async Task AddToCartAsync(int productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            if (product == null) return;

            var cart = GetCart();
            var existing = cart.FirstOrDefault(c => c.ProductId == product.Id);

            if (existing != null)
            {
                existing.Quantity++;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    Quantity = 1
                });
            }

            SaveCart(cart);
        }

        public void RemoveFromCart(int productId)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(c => c.ProductId == productId);
            if (item != null)
            {
                cart.Remove(item);
                SaveCart(cart);
            }
        }

        public void ClearCart()
        {
            SaveCart(new List<CartItem>());
        }
    }
}
