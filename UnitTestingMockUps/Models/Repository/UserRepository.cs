using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitTestingMockUps.Interface;
using UnitTestingMockUps.Models.Entity;

namespace UnitTestingMockUps.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public void Delete(int? id)
        {
            if(id == null)
            {
                throw new Exception("id = null, use a id?");
            }
            ApplicationUser usr = db.Users.Find(id);
            if(usr == null)
            {
                throw new Exception("User not found by this id");
            }
            db.Users.Remove(usr);
            db.SaveChanges();
        }

        public ApplicationUser Find(int? id)
        {
            if(id == null) { throw new Exception("id = null, use a id?"); }
            return db.Users.Find(id);
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return db.Users;
        }

        public ApplicationUser InsertOrUpdate(ApplicationUser user)
        {
            if (user.Id == "0")
            {
                db.Users.Add(user);
            }
            else
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return user;
        }
    }
}