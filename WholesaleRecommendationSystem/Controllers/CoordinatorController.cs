//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;
//using WholesaleRecommendationSystem.Services;

//namespace OnlineStore.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class CoordinatorController : ControllerBase
//    {
//        private readonly ICatalogService _productCatalogService;
//        private readonly RecommendationService _recommendationService;
//        private readonly OrderService _orderManagementService;
//        private readonly PaymentService _paymentService;

//        public CoordinatorController(
//            ICatalogService productCatalogService,
//            RecommendationService recommendationService,
//            OrderService orderManagementService,
//            PaymentService paymentService)
//        {
//            _productCatalogService = productCatalogService;
//            _recommendationService = recommendationService;
//            _orderManagementService = orderManagementService;
//            _paymentService = paymentService;
//        }

//        [HttpPost("process-order")]
//        public async Task<IActionResult> ProcessOrder([FromBody] OrderRequest orderRequest)
//        {
//            // Step 1: Check product availability and update stock
//            var isAvailable = await _productCatalogService.CheckAndUpdateStock(orderRequest.Items);
//            if (!isAvailable)
//            {
//                return BadRequest("One or more items are out of stock.");
//            }

//            // Step 2: Generate product recommendations
//            var recommendations = await _recommendationService.GetRecommendations(orderRequest.UserId);

//            // Step 3: Register the order
//            var orderId = await _orderManagementService.CreateOrder(orderRequest);
//            if (orderId == null)
//            {
//                return StatusCode(500, "Failed to create the order.");
//            }

//            // Step 4: Process payment
//            var paymentResult = await _paymentService.ProcessPayment(orderRequest.PaymentDetails, orderId);
//            if (!paymentResult.IsSuccess)
//            {
//                // Optionally rollback the order creation if payment fails
//                await _orderManagementService.CancelOrder(orderId);
//                return BadRequest("Payment failed: " + paymentResult.ErrorMessage);
//            }

//            // Step 5: Return confirmation
//            return Ok(new
//            {
//                OrderId = orderId,
//                Message = "Order successfully processed.",
//                Recommendations = recommendations
//            });
//        }
//    }
//    public class OrderRequest
//    {
//        public string UserId { get; set; }
//        public OrderItem[] Items { get; set; }
//        public PaymentDetails PaymentDetails { get; set; }
//    }

//    public class OrderItem
//    {
//        public string ProductId { get; set; }
//        public int Quantity { get; set; }
//    }

//    public class PaymentDetails
//    {
//        public string PaymentMethod { get; set; }
//        public string CardNumber { get; set; }
//        public string ExpiryDate { get; set; }
//    }
//}
