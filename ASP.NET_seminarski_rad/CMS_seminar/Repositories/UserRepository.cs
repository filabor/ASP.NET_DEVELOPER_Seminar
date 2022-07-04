using CMS_seminar.Data;
using CMS_seminar.Interfaces;

namespace CMS_seminar.Repositories
{
    public class UserRepository
    {

        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<ApplicationUser> GetAll()
        {
           return _context.Users.ToList();
        }

        public ApplicationUser GetById(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public void CreateNew(ApplicationUser new_user)
        {
            _context.Users.Add(new_user);
            _context.SaveChanges();
        }

        public void Update(ApplicationUser user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var user_to_remove = _context.Users.SingleOrDefault(u => u.Id == id);
            _context.Users.Remove(user_to_remove);
            _context.SaveChanges();
        }
    }
}
