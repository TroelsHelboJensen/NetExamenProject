using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitTestingMockUps.Interface;
using UnitTestingMockUps.Models.Entity;

namespace UnitTestingMockUps.Models.Repository
{
    public class ProgressRepository : IProgressRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<ProgressModel> GetAll()
        {
            return db.Progress.ToList();
        }

        public ProgressModel InsertOrUpdate(ProgressModel progress)
        {
            if (progress == null)
            {
                throw new Exception("No Progress");
            }
            else if (progress.ProgressModelId <= 0)
            {
                db.Progress.Add(progress);
                db.SaveChanges();
            }
            else
            {
                db.Entry(progress).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return progress;
            
        }

        public ProgressModel Find(int? id)
        {
            ProgressModel progress = null;
            if (id == null)
            {
                throw new Exception("id = null, use a id?");
            }
            else if (id <= 0)
            {
                throw new Exception("id to small");
            }
            else
            {
                progress = db.Progress.Find(id);
            }
            return progress;
        }
    }
}