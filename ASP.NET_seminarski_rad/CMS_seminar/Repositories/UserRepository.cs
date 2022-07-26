using CMS_seminar.Data;
using CMS_seminar.Interfaces;
using Microsoft.AspNetCore.Identity;

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

        public void CreateNew(ApplicationUser new_user, string role_name)
        {
            _context.Users.Add(new_user);
            _context.SaveChanges();

            IdentityRole role = GetRoleByName(role_name);

            IdentityUserRole<string> identityUserRole = new IdentityUserRole<string>();
            identityUserRole.RoleId = role.Id;
            identityUserRole.UserId = new_user.Id;

            _context.UserRoles.Add(identityUserRole);
            _context.SaveChanges();
        }

        public void Update(ApplicationUser user, string role_name)
        {
            _context.Users.Update(user);
            _context.SaveChanges();

            var user_role = GetUserRoleByUserId(user.Id);

            _context.UserRoles.Remove(user_role);
            _context.SaveChanges();

            IdentityRole role = GetRoleByName(role_name);

            IdentityUserRole<string> identityUserRole = new IdentityUserRole<string>();
            identityUserRole.RoleId = role.Id;
            identityUserRole.UserId = user.Id;

            _context.UserRoles.Add(identityUserRole);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var user_to_remove = _context.Users.SingleOrDefault(u => u.Id == id);
            _context.Users.Remove(user_to_remove);
            _context.SaveChanges();
        }

        public IEnumerable<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public IdentityRole GetRoleByName(string name)
        {
            return _context.Roles.FirstOrDefault(role => role.Name.ToLower() == name.ToLower());
        }

        public IdentityRole GetRoleForUserByUserId(string user_id)
        {
            IdentityUserRole<string> user_role = _context.UserRoles.FirstOrDefault(ir => ir.UserId == user_id);

            IdentityRole role = _context.Roles.FirstOrDefault(r => r.Id == user_role.RoleId);

            return role;
        }

        public IdentityUserRole<string> GetUserRoleByUserId(string user_id)
        {
            return _context.UserRoles.FirstOrDefault(ir => ir.UserId == user_id);
        }
    }
}
