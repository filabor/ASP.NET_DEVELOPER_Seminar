using CMS_seminar.Interfaces;
using CMS_seminar.Models;

namespace CMS_seminar.Services
{
    public class ProductService
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductCategory> _productCategoryRepository;
        private readonly IGenericRepository<Category> _categoryRepository;

       
        public ProductService(IGenericRepository<Product> productRepository, IGenericRepository<ProductCategory> productCategoryRepository, IGenericRepository<Category> categoryRepositroy)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _categoryRepository = categoryRepositroy;
        }


        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public IEnumerable<Product> GetRandomProducts()
        {
            return _productRepository.GetAll().OrderBy(rp => Guid.NewGuid()).Take(10).ToList();
        }

        public void CreateNewProduct(Product new_product, int[] category_ids, IFormFile Image)
        {
            UploadImage(new_product, Image);

            _productRepository.CreateNew(new_product);

            int product_id = new_product.Id;

            foreach (var category_id in category_ids)
            {
                ProductCategory ProductCategory = new ProductCategory();
                ProductCategory.ProductId = product_id;
                ProductCategory.CategoryId = category_id;

                _productCategoryRepository.CreateNew(ProductCategory);
            }
        }

        private static void UploadImage(Product new_product, IFormFile Image)
        {
            if (Image != null)
            {
                var image_name = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "-" + Image.FileName.ToLower();

                var save_image_path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", image_name);

                using (var stream = new FileStream(save_image_path, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }

                new_product.ImageName = image_name;
            }
        }

        public void UpdateProduct(Product product, int[] category_ids, IFormFile Image)
        {
            UploadImage(product, Image);

            _productRepository.Update(product);

            
            foreach(var category_id in category_ids)
            {
                ProductCategory ProductCategory = new ProductCategory();
                ProductCategory.ProductId = product.Id;
                ProductCategory.CategoryId = category_id;

                _productCategoryRepository.CreateNew(ProductCategory);
            }
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }

        public IEnumerable<Category> GetProductCategories(int id)
        {
            var product_categories = _productCategoryRepository.GetAll().Where(s => s.ProductId == id).Select(s => s.Category).ToList();

            return product_categories;
        }

    }
}
