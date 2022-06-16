using CMS_seminar.Data;
using CMS_seminar.Interfaces;
using CMS_seminar.Models;

namespace CMS_seminar.Repositories
{
    public class ProductCategoryRepository : IGenericRepository<ProductCategory>
    {

        private readonly ApplicationDbContext _context;

        public ProductCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _context.ProductCategories.ToList();
        }

        public ProductCategory GetById(int id)
        {
            return _context.ProductCategories.FirstOrDefault(c => c.Id == id);
        }

        public void CreateNew(ProductCategory new_product_category)
        {
            _context.ProductCategories.Add(new_product_category);

            _context.SaveChanges();
        }

        public void Update(ProductCategory product_category)
        {
            _context.ProductCategories.Update(product_category);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product_category_to_remove = _context.ProductCategories.SingleOrDefault(c => c.Id == id);
            _context.Remove(product_category_to_remove);

            _context.SaveChanges();
        }
    }
}
