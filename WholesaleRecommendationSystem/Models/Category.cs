using System.ComponentModel.DataAnnotations;

namespace WholesaleRecommendationSystem.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        // Навигационное свойство (один ко многим)
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
