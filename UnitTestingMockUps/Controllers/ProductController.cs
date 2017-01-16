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
    [Authorize]
    public class ProductController : Controller
    {
        private IProductRepository prodRepo;

        public ProductController()
        {
            prodRepo = new ProductRepository();
        }

        public ProductController(IProductRepository p)
        {
            prodRepo = p;
        }

        // GET: Product
        [AllowAnonymous]
        public ActionResult Index(string str = "")
        {
            //JsonResult
            //return data as Json (api)
            //return Json(studentRepo.GetAll(), JsonRequestBehavior.AllowGet);

            var results = prodRepo.GetAll();
            if (!String.IsNullOrEmpty(str))
            {
                // Linq 101 search
                var searchedNames = from p in results
                                    where 
                                          p.Name.ToLower()
                                          .Contains(str.ToLower()) ||
                                          p.ProductPrice.ToString()
                                          .Contains(str.ToLower()) ||
                                          p.Instruction.ToLower()
                                          .Contains(str.ToLower())
                                    select p;

                results = searchedNames.ToList();
            }

            return View(results);
        }
        
        // GET: Create
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost] /* Set this to the HttpPost, 
                      so here i wanna catch the Post request 
                      and make a response 
                   */
        [Authorize(Roles = "admin")] /* Only Users with this role can access this method */
        public ActionResult Create(ProductModel product)
        {
            prodRepo.InsertOrUpdate(product);
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpNotFoundResult();
            }
            prodRepo.Delete(id);
            return View();
        }
    }
}