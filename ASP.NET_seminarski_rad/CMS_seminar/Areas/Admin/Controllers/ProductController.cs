using CMS_seminar.Models;
using CMS_seminar.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS_seminar.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {

        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }


        // GET: ProductController
        public ActionResult Index(string? msg)
        {
            var get_all_products = _productService.GetAllProducts();

            ViewBag.ProductErrorMessage = msg;

            return View(get_all_products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            var product = _productService.GetProductById(id);

            if(product == null)
            {
                return RedirectToAction("Index", new { msg = "Product does not exist!" });
            }

            var categories = _productService.GetProductCategories(id);

            ViewBag.ProductCategories = categories;

            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create(string? error_message)
        {
            ViewBag.CategoryErrorMessage = error_message;
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, int[] category_id, IFormFile Image)
        {
            if(category_id.Length == 0)
            {
                return RedirectToAction("Create", new { error_message = "Please select at least one category!" });
            }

            try
            {
                _productService.CreateNewProduct(product, category_id, Image);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return RedirectToAction("Create", new { error_message = ex.Message });
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            if(id == 0)
            {
                RedirectToAction("Index");
            }

            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return RedirectToAction("Index", new { msg = "Product does not exist!" });
            }

            var product_categories = _productService.GetProductCategories(id);

            ViewBag.SelectedCategories = product_categories;

            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, int[] category_id, IFormFile Image)
        {
            try
            {
                _productService.UpdateProduct(product, category_id, Image);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            if(id == 0)
            {
                return RedirectToAction("Index");
            }

            var product = _productService.GetProductById(id);

            if(product == null)
            {
                return RedirectToAction("Index", new { msg = "Product does not exist!" });
            }

            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }

            try
            {

                var product_to_delete = _productService.GetProductById(id);

                if(product_to_delete == null)
                {
                    return RedirectToAction("Delete", new { msg = "Product does not exist!" });
                }

                _productService.DeleteProduct(id);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return RedirectToAction("Delete", new { error_message = ex.InnerException.Message});
            }
        }
    }
}
