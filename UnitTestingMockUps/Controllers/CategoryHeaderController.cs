using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTestingMockUps.Interface;
using UnitTestingMockUps.Models.Entity;
using UnitTestingMockUps.Models.Repository;

namespace UnitTestingMockUps.Controllers
{
    public class CategoryHeaderController : Controller
    {
        private ICategoryRepository<CategoryHeaderModel> categoryHeaderRepository;
        public CategoryHeaderController(ICategoryRepository<CategoryHeaderModel> ichr)
        {
            categoryHeaderRepository = ichr;
        }

        public CategoryHeaderController()
        {
            categoryHeaderRepository = new CategoryHeaderRepository();
        }

        // GET: cHeader
        public ActionResult Index()
        {
            return View(categoryHeaderRepository.GetAll());
        }

        // Get: cHeader -> Create
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // Post: cHeader -> Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryHeaderModel cHeader)
        {
            if (ModelState.IsValid)
            {
                categoryHeaderRepository.InsertOrUpdate(cHeader);
            }
            return RedirectToAction("Index", "CategoriesView");
        }

        // Get: cHeader -> Edit
        [HttpGet]
        // Only logged in users can do this
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpNotFoundResult();
            }

            CategoryHeaderModel cHeader = categoryHeaderRepository.Find(id);

            if (cHeader == null)
            {
                return new HttpNotFoundResult();
            }

            return View(cHeader);
        }

        [HttpPost]
        public ActionResult Edit(CategoryHeaderModel cHeader)
        {
            if (ModelState.IsValid)
            {
                categoryHeaderRepository.InsertOrUpdate(cHeader);
            }
            return RedirectToAction("Index", "CategoriesView");
        }

        // Delete a Category
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            categoryHeaderRepository.Delete(id);
            return RedirectToAction("Index", "CategoriesView");
        }
    }
}