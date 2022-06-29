using CMS_seminar.Interfaces;
using CMS_seminar.Models;
using CMS_seminar.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CMS_seminar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService;
        private readonly IGenericRepository<ProductCategory> _productCategoryRepository;
        private readonly IGenericRepository<Category> _categoryRepositoy;

        public HomeController(ILogger<HomeController> logger, ProductService productService, IGenericRepository<ProductCategory> productCategoryRepository, IGenericRepository<Category> categoryRepository)
        {
            _logger = logger;
            _productService = productService;
            _productCategoryRepository = productCategoryRepository;
            _categoryRepositoy = categoryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Product(int? category_id)
        {
            var products = new List<Product>();

            if (category_id != null)
            {
                products = _productService.GetAllProducts()
                    .Where(p => _productCategoryRepository.GetAll()
                    .Where(pc => pc.CategoryId == category_id)
                    .Select(pc => pc.ProductId).ToList().Contains(p.Id)).ToList();
            }
            else
            {
                products = _productService.GetAllProducts().ToList();
            }

            ViewBag.Categories = _categoryRepositoy.GetAll();

            return View(products);
        }

        public IActionResult ProductDetails(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return RedirectToAction("Index", new { msg = "Product does not exist!" });
            }

            var categories = _productService.GetProductCategories(id);

            ViewBag.ProductCategories = categories;

            return View(product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}