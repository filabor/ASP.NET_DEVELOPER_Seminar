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

        public HomeController(ILogger<HomeController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Product()
        {
            var products = _productService.GetAllProducts();
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