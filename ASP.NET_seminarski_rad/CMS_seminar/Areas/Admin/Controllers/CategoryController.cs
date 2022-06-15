using CMS_seminar.Interfaces;
using CMS_seminar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS_seminar.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {

        private readonly IGenericRepository<Category> _categoryRepository;

        public CategoryController(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }



        // GET: CategoryController
        public ActionResult Index()
        {
            var get_all_categories = _categoryRepository.GetAll();

            return View(get_all_categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = _categoryRepository.GetById(id);

            if(category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                _categoryRepository.CreateNew(category);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _categoryRepository.GetById(id);

            if(id == 0)
            {
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            try
            {
                _categoryRepository.Update(category);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            if(id == 0)
            {
                return RedirectToAction("Index");
            }

            var category = _categoryRepository.GetById(id);

            if(category == null)
            {
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if(id == 0)
                {
                    return RedirectToAction("Index");
                }

                _categoryRepository.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
