using WholesaleRecommendationSystem.Models;

namespace WholesaleRecommendationSystem.Services
{
    public interface ICatalogService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);

        Task DeleteProductAsync(int id);
    }
}
