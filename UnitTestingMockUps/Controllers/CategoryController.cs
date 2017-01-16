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
    public class CategoryController : Controller
    {
        private ICategoryRepository<CategoryModel> categoryRepository;
        public CategoryController(ICategoryRepository<CategoryModel> icr)
        {
            categoryRepository = icr;
        }

        public CategoryController()
        {
            categoryRepository = new CategoryRepository();
        }
        // GET: Category
        public ActionResult Index()
        {
            return View(categoryRepository.GetAll());
        }

        // Get: Category -> Create
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CategoryHeaderModelId = new SelectList(new CategoryHeaderRepository().GetAll(), "CategoryHeaderModelId", "Name");
            return View();
        }

        // Post: Category -> Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryModelId,Name,CategoryHeaderModelId")] CategoryModel category)
        {
            if(ModelState.IsValid)
            { 
                categoryRepository.InsertOrUpdate(category);
            }
            return RedirectToAction("Index", "CategoriesView");
        }

        // Get: Category -> Edit
        [HttpGet]
        // Only logged in users can do this
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpNotFoundResult();
            }

            CategoryModel category = categoryRepository.Find(id);

            if(category == null)
            {
                return new HttpNotFoundResult();
            }
            ViewBag.CategoryHeaderModelId = new SelectList(new CategoryHeaderRepository().GetAll(), "CategoryHeaderModelId", "Name");
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "CategoryModelId,Name,CategoryHeaderModelId")] CategoryModel category)
        {
            if(ModelState.IsValid)
            {
                if(category.CategoryHeaderModelId == 0)
                {
                    return RedirectToAction("Index", "CategoriesView");
                }
                
                categoryRepository.InsertOrUpdate(category);
                return RedirectToAction("Index", "CategoriesView");
            }
            return View("Thanks for editing");
        }

        // Delete a Category
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            categoryRepository.Delete(id);
            return RedirectToAction("Index", "CategoriesView");
        }
    }
}