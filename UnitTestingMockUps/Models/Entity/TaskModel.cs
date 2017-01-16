using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitTestingMockUps.Models.Entity
{
    public class TaskModel
    {
        public int TaskModelId { get; set; }
        public String Name { get; set; }
        public bool TaskDone { get; set; }
        // Procent is this Task worth
        public float Procent { get; set; } 

        // Ref to Progress
        public int ProgressModelId { get; set; }
        public virtual ProgressModel Progress { get; set; }
    }
}