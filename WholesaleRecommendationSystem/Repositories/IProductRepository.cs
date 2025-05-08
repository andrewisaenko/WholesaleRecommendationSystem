using Microsoft.EntityFrameworkCore;
using WholesaleRecommendationSystem.Models;

namespace WholesaleRecommendationSystem.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        
    }
}
