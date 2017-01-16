using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitTestingMockUps.Models.Entity;

namespace UnitTestingMockUps.Models.Views
{
    public class CategoeriesViewModel
    {
        public IEnumerable<CategoryHeaderModel> CategoryHeaders { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
        public CategoryHeaderModel CategoryHeaderModel = new CategoryHeaderModel() { Name = "Category Headers" };
        public CategoryModel CategoryModel = new CategoryModel() { Name = "Categories"};
    }
}