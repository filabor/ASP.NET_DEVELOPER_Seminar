using CMS_seminar.Models;
using CMS_seminar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS_seminar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }


        // GET: api/Product
        [HttpGet("Products")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            try
            {
                return Ok(_productService.GetAllProducts());
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/Product/5
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetProduct(int id)
        {
            try
            {
                var result = _productService.GetProductById(id);

                if (result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Result not found!");
                }

                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to display results, an error occurred!");
            }
        }
    }
}
