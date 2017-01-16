using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitTestingMockUps.Interface;
using UnitTestingMockUps.Models.Entity;

namespace UnitTestingMockUps.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<ProductModel> GetAll()
        {
            return db.Products.ToList();
        }

        public ProductModel InsertOrUpdate(ProductModel product)
        {
            if(product == null)
            {
                throw new Exception("No Product");
            }
            else if(product.ProductModelId <= 0)
            {
                db.Products.Add(product);
            }
            else
            {
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();

            return product;
        }

        private ProductModel Find(int? id)
        {
            ProductModel product = null;
            if (id == null)
            {
                throw new Exception("id = null, use a id?");
            }
            else if(id <= 0)
            {
                throw new Exception("id to small");
            }
            else
            {
                product = db.Products.Find(id);
            }
            return product;
        }

        public void Delete(int? id)
        {
            ProductModel p = Find(id);
            db.Products.Remove(p);
        }
    }
}