using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTestingMockUps.Interface;
using UnitTestingMockUps.Models;
using UnitTestingMockUps.Models.Repository;
using UnitTestingMockUps.Models.Views;

namespace UnitTestingMockUps.Controllers.Views
{
    public class CategoriesViewController : Controller
    {
        private CategoryHeaderRepository _categoryHeaderRepo;
        private CategoryRepository _categoryRepo;
        private CategoeriesViewModel _viewModel;

        public CategoriesViewController()
        {
            _categoryHeaderRepo = new CategoryHeaderRepository();
            _categoryRepo = new CategoryRepository();
            _viewModel = new CategoeriesViewModel();
            PopulationOfView();
        }

        private void PopulationOfView()
        {
            _viewModel.CategoryHeaders = _categoryHeaderRepo.GetAll();
            _viewModel.Categories = _categoryRepo.GetAll();
        }

        // GET: CategoriesView
        public ActionResult Index()
        {
            PopulationOfView();
            foreach(var category in _viewModel.Categories)
            {
                //foreach(var header in _viewModel.CategoryHeaders)
                //{
                /*if(category.CategoryHeaderModelId == header.CategoryHeaderModelId)
                {
                    category.CategoryHeaderModel = header;
                    break;
                }*/
                //}
                category.CategoryHeaderModel = _categoryHeaderRepo.Find(category.CategoryHeaderModelId);
            }
            
            return View(_viewModel);
        }

    }
}