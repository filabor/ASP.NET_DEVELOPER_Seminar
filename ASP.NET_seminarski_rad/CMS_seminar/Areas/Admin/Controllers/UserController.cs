using CMS_seminar.Repositories;
using CMS_seminar.Services;
using CMS_seminar.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS_seminar.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController : Controller
    {

        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // GET: UserController
        public ActionResult Index()
        {
            var users = _userService.GetAllUsers();

            return View(users);
        }

        // GET: UserController/Details/5
        public ActionResult Details(string id)
        {
            var user = _userService.GetUserById(id);
            return View(user);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            ViewBag.Roles = _userService.GetAllRoles();
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel user_view_model, string confirmedPassword)
        {
            try
            {
                if(user_view_model.Password != confirmedPassword)
                {
                    // Dodati error u viewu
                    return RedirectToAction("Create", new { error_message = "Please, enter the same passsword value!" });
                }
                
                _userService.CreateNewUser(user_view_model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var user = _userService.GetUserById(id);

            ViewBag.Roles = _userService.GetAllRoles();

            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel user, IFormCollection collection)
        {
            try
            {
                if (user == null)
                {
                    return RedirectToAction("Index", new { msg = "User does not exist!" });
                }

                _userService.UpdateUser(user);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var user = _userService.GetUserById(id);

            if (user == null)
            {
                return RedirectToAction("Index", new { msg = "User does not exist!" });
            }

            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            try
            {
                var user_to_delete = _userService.GetUserById(id);

                if (user_to_delete == null)
                {
                    return RedirectToAction("Index", new { msg = "User does not exist!" });
                }

                _userService.DeleteUser(id);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return RedirectToAction("Delete", new { error_message = ex.InnerException.Message });
            }
        }
    }
}
