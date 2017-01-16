using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingMockUps.Models.Entity;

namespace UnitTestingMockUps.Interface
{
    public interface ITaskRepository
    {
        List<TaskModel> GetAll();
        TaskModel InsertOrUpdate(TaskModel task);
        TaskModel Find(int? id);
    }
}
