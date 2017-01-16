using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitTestingMockUps.Interface;
using UnitTestingMockUps.Models.Entity;

namespace UnitTestingMockUps.Models.Repository
{
    public class CategoryHeaderRepository : ICategoryRepository<CategoryHeaderModel>
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Delete(int? id)
        {
            // Security for null values
            if(id == null)
            {
                throw new Exception("id = null, use a id?");
            }
            CategoryHeaderModel ch = db.CategoryHeaders.Find(id);
            if (ch == null)
            {
                throw new Exception("User not found by this id");
            }
            db.CategoryHeaders.Remove(ch);
            db.SaveChanges();
        }

        public CategoryHeaderModel Find(int? id)
        {
            if(id == null)
            {
                throw new Exception("id = null, use a id?");
            }
            return db.CategoryHeaders.Find(id);
        }

        public IEnumerable<CategoryHeaderModel> GetAll()
        {
            return db.CategoryHeaders;
        }

        public CategoryHeaderModel InsertOrUpdate(CategoryHeaderModel category)
        {
            if(category == null) 
            {
                throw new Exception("No Category");
            }
            if(category.CategoryHeaderModelId <= 0)
            {
                db.CategoryHeaders.Add(category);
            } else
            {
                db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return category;
        }
    }
}