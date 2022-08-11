using CMS_seminar.Data;
using CMS_seminar.Services;
using CMS_seminar.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMS_seminar.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserService _userService;
        private UserManager<ApplicationUser> _userManager;

        public ProfileController(UserService userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        public IActionResult GetDetails()
        {
            var user_id = _userManager.GetUserId(User);

            var user_model = _userService.GetUserById(user_id);

            return View(user_model);
        }

        public ActionResult Edit()
        {
            var user_id = _userManager.GetUserId(User);

            var user = _userService.GetUserById(user_id);

            return View(user);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel user)
        {
            try
            {
                _userService.UpdateUserProfile(user);

                return RedirectToAction(nameof(GetDetails));
            }
            catch
            {
                return View();
            }
        }

    }
}
