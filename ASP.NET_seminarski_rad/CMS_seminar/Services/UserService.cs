using CMS_seminar.Data;
using CMS_seminar.Repositories;
using CMS_seminar.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace CMS_seminar.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            List<ApplicationUser> application_users = _userRepository.GetAll().ToList();

            List <UserViewModel> user_view_models = new List<UserViewModel>();

            application_users.ForEach(app_user =>
            {
                UserViewModel user_view_model = MapModelToViewModel(app_user);

                user_view_models.Add(user_view_model);
            });

            return user_view_models;
        }

        private UserViewModel MapModelToViewModel(ApplicationUser app_user)
        {
            UserViewModel user_view_model = new UserViewModel();
            user_view_model.Id = app_user.Id;
            user_view_model.FirstName = app_user.FirstName;
            user_view_model.LastName = app_user.LastName;
            user_view_model.Address = app_user.Address;
            user_view_model.Email = app_user.Email;

            IdentityRole role = _userRepository.GetRoleForUserByUserId(app_user.Id);
            user_view_model.Role = role.Name;

            return user_view_model;
        }

        public UserViewModel GetUserById(string id)
        {
            ApplicationUser user = _userRepository.GetById(id);

            UserViewModel user_view_model = MapModelToViewModel(user);

            return user_view_model;
        }

        private ApplicationUser MapViewModelToModel(UserViewModel user)
        {
            ApplicationUser applicationUser = new ApplicationUser();
            if(user.Id != null)
            {
                applicationUser.Id = user.Id;
            }
            applicationUser.FirstName = user.FirstName;
            applicationUser.LastName = user.LastName;
            applicationUser.Address = user.Address;
            applicationUser.Email = user.Email;
            applicationUser.UserName = user.Email;
            applicationUser.NormalizedUserName = user.Email.ToUpper();
            applicationUser.PasswordHash = GetHashedPassword(user.Password);

            return applicationUser;
        }

        public void CreateNewUser(UserViewModel user)
        {
            ApplicationUser applicationUser = MapViewModelToModel(user);

            _userRepository.CreateNew(applicationUser, user.Role);
        }

        public void UpdateUser(UserViewModel user)
        {
            ApplicationUser user_to_update = _userRepository.GetById(user.Id);

            user_to_update.FirstName = user.FirstName;
            user_to_update.LastName = user.LastName;
            user_to_update.Address = user.Address;
            user_to_update.Email = user.Email;
            user_to_update.UserName = user.Email;
            user_to_update.NormalizedUserName = user.Email.ToUpper();

            _userRepository.Update(user_to_update, user.Role);
        }

        public string GetHashedPassword(string password)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            return hasher.HashPassword(null, password);
        }

        public void UpdateUser(ApplicationUser user, string role_name)
        {
            _userRepository.Update(user, role_name);
        }

        public void DeleteUser(string id)
        {
            _userRepository.Delete(id);
        }

        public IEnumerable<IdentityRole> GetAllRoles()
        {
            return _userRepository.GetRoles();
        }
    }
}
