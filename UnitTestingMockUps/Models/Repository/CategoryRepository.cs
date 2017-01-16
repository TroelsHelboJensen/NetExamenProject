using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using UnitTestingMockUps.Interface;
using UnitTestingMockUps.Models.Entity;

namespace UnitTestingMockUps.Models.Repository
{
    public class CategoryRepository : ICategoryRepository<CategoryModel>
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Delete(int? id)
        {
            // Security for null values
            if (id == null)
            {
                throw new Exception("id = null, use a id?");
            }
            CategoryModel c = db.Categories.Find(id);
            if (c == null)
            {
                throw new Exception("User not found by this id");
            }
            db.Categories.Remove(c);
            db.SaveChanges();
        }

        public CategoryModel Find(int? id)
        {
            if (id == null)
            {
                throw new Exception("id = null, use a id?");
            }
            return db.Categories.Find(id);
        }

        public IEnumerable<CategoryModel> GetAll()
        {
            return db.Categories;
        }

        public CategoryModel InsertOrUpdate(CategoryModel category)
        {
            if (category == null)
            {
                throw new Exception("No Category");
            }
            if (category.CategoryModelId <= 0)
            {
                db.Categories.Add(category);
            }
            else
            {
                db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            }
            
            db.SaveChanges();
           

            return category;
        }
    }
}