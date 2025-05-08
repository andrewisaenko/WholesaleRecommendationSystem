using System.ComponentModel.DataAnnotations;

namespace WholesaleRecommendationSystem.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        // Навигационное свойство (один ко многим)
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
