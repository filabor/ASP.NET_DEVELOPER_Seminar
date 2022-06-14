using CMS_seminar.Data;
using CMS_seminar.Interfaces;
using CMS_seminar.Models;

namespace CMS_seminar.Repositories
{
    public class CategoryRepository : IGenericRepository<Category>
    {

        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void CreateNew(Category new_category)
        {
            _context.Categories.Add(new_category);

            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            var result = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
            result.Title = category.Title;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category_to_remove = _context.Categories.SingleOrDefault(c => c.Id == id);
            _context.Categories.Remove(category_to_remove);

            _context.SaveChanges();
        }

    }
}
