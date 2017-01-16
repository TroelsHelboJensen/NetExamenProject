using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitTestingMockUps.Interface;
using UnitTestingMockUps.Models.Entity;

namespace UnitTestingMockUps.Models.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public TaskModel Find(int? id)
        {
            if (id == null)
            {
                throw new Exception("Inside TaskRepository -> Find(int? id)");
            }
            else
            {
                return db.Tasks.Find(id);
            }
        }

        public List<TaskModel> GetAll()
        {
            return db.Tasks.ToList();
        }

        public TaskModel InsertOrUpdate(TaskModel task)
        {
            if (task == null)
            {
                throw new Exception("No Task");
            }
            else if (task.TaskModelId <= 0)
            {
                db.Tasks.Add(task);
            }
            else
            {
                db.Entry(task).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();

            return task;
        }
    }
}