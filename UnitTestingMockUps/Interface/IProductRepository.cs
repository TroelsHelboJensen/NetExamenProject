using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitTestingMockUps.Models.Entity;

namespace UnitTestingMockUps.Interface
{
    public interface IProductRepository
    {
        ProductModel InsertOrUpdate(ProductModel product);
        List<ProductModel> GetAll();
        void Delete(int? id);
    }
}