using Microsoft.AspNetCore.Mvc;
using WholesaleRecommendationSystem.Models;
using WholesaleRecommendationSystem.Data; // Замените на ваше пространство имен
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WholesaleRecommendationSystem.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList(); // Получаем все категории из базы
            return View(categories);
        }

        public IActionResult Category(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            var products = _context.Products
                .Where(p => p.CategoryId == id)
                .ToList();

            ViewBag.CategoryName = category.Name;
            return View(products); // ищет Views/Catalog/Category.cshtml
        }

        public IActionResult Product(int id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Manufacturer)
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return View(product); // Views/Catalog/Product.cshtml
        }

    }
}
