using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTestingMockUps.Interface;
using UnitTestingMockUps.Models.Entity;
using UnitTestingMockUps.Models.Repository;

namespace UnitTestingMockUps.Controllers
{
    public class TaskController : Controller
    {
        private ITaskRepository taskRepo;

        public TaskController()
        {
            taskRepo = new TaskRepository();
        }

        public TaskController(ITaskRepository tr)
        {
            taskRepo = tr;
        }

        // GET: Task
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TaskModel task)
        {
            return View();
        }
    }
}