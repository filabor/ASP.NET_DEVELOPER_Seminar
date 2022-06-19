using CMS_seminar.Data;
using CMS_seminar.Interfaces;
using CMS_seminar.Models;

namespace CMS_seminar.Services
{
    public class ProductService
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductCategory> _productCategoryRepository;

       
        public ProductService(IGenericRepository<Product> productRepository, IGenericRepository<ProductCategory> productCategoryRepository)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
        }


        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void CreateNewProduct(Product new_product, int[] category_id, IFormFile Image)
        {
            var image_name = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "-" + Image.FileName.ToLower();

            var save_image_path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", image_name);

            using(var stream = new FileStream(save_image_path, FileMode.Create))
            {
                Image.CopyTo(stream);
            }

            new_product.ImageName = image_name;

            _productRepository.CreateNew(new_product);

            int product_id = new_product.Id;

            foreach(var category in category_id)
            {
                ProductCategory ProductCategory = new ProductCategory();
                ProductCategory.ProductId = product_id;
                ProductCategory.CategoryId = category;

                _productCategoryRepository.CreateNew(ProductCategory);
            }
        }

        public void UpdateProduct(Product product, int[] category_id)
        {
            _productRepository.Update(product);

            
            foreach(var category in category_id)
            {
                ProductCategory ProductCategory = new ProductCategory();
                ProductCategory.ProductId = product.Id;
                ProductCategory.CategoryId = category;

                _productCategoryRepository.CreateNew(ProductCategory);
            }
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }

        public IEnumerable<Category> GetProductCategories(int id)
        {
            var categories = _productCategoryRepository.GetAll().Where(s => s.ProductId == id).Select(s => s.Category).ToList();

            return categories;
        }
    }
}
