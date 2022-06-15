using CMS_seminar.Data;
using CMS_seminar.Interfaces;
using CMS_seminar.Models;

namespace CMS_seminar.Repositories
{
    public class ProductRepository : IGenericRepository<Product>
    {

        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void CreateNew(Product new_product)
        {
            _context.Products.Add(new_product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product_to_remove = _context.Products.SingleOrDefault(p => p.Id == id);
            _context.Remove(product_to_remove);

            _context.SaveChanges();
        }

    }
}
