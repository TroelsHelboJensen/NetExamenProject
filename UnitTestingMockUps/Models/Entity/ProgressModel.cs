using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitTestingMockUps.Models.Entity
{
    public class ProgressModel
    {
        public int ProgressModelId { get; set; }
        public String Name { get; set; }
        public float Process { get; set; } // Procent of progress

        // Multy connection to the TaskModel Table
        public virtual ICollection<TaskModel> Tasks { get; set; }
        // For the view a single task with nothing in it
        public TaskModel Task { get; set; }
    }
}