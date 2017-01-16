using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitTestingMockUps.Models.Entity;

namespace UnitTestingMockUps.Models.Views
{
    public class ProductCategoryProgressView
    {
        public List<ProductModel> Products { get; set; }
        public ProductModel ProductModel = new ProductModel();
        public List<CategoryHeaderModel> CategoryHeaders { get; set; }
        public CategoryHeaderModel CategoryHeaderModel = new CategoryHeaderModel();
        public ProgressModel Progress { get; set; }
    }
}