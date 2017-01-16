using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTestingMockUps.Interface;
using UnitTestingMockUps.Models.Entity;
using UnitTestingMockUps.Models.Repository;

namespace UnitTestingMockUps.Controllers
{
    public class ProgressController : Controller
    {
        private IProgressRepository progRepo;
        private ITaskRepository taskRepo;
        private bool underTest = false;

        public ProgressController()
        {
            progRepo = new ProgressRepository();
            taskRepo = new TaskRepository();
        }

        public ProgressController(IProgressRepository ipr)
        {
            progRepo = ipr;
            taskRepo = new TaskRepository();
        }

        public ProgressController(IProgressRepository ipr, ITaskRepository itr, bool test)
        {
            underTest = test;
            progRepo = ipr;
            taskRepo = itr;
        }

        // GET: Progress
        [HttpGet]
        public ActionResult Index()
        {
            List<TaskModel> tasks = null;
            // Tasks table GetAll
            if (taskRepo.GetAll() == null)
            {
                tasks = new List<TaskModel>();
            } else { 
                tasks = taskRepo.GetAll();
            }
            List<ProgressModel> progress = progRepo.GetAll();
            if(progress == null)
            {
                progress = new List<ProgressModel>();
            }
            ProgressModel progm = progress.FirstOrDefault();
            // this will be for test only i hope
            if (progm == null)
            {
                progm = new ProgressModel()
                {
                    Name = "Test Index",
                    Process = 100,
                    Task = new TaskModel(),
                    Tasks = tasks
                };
            }

            //Debug.WriteLine("progress id" + progm.ProgressModelId);
            //Debug.WriteLine("First Task id" + tasks.FirstOrDefault());
            if (progm == null)
            {
                string gatherInfo = taskRepo.GetAll().ToString();
                throw new Exception("In: ProgressController -> Index()\n" + gatherInfo);
            }
            progm.Tasks = tasks;
            return View(progm);
        }

        // POST: Progress
        //[HttpPost]
        public ActionResult EditTask(int? id)
        {
            if (id == null)
            {
                //string gatherInfo = taskRepo.GetAll().ToString();
                //throw new Exception("ProgressController -> EditTask(int? id)\n");// + gatherInfo);
                return new HttpNotFoundResult();
            }
            // Get the TaskModel
            // For the Test
            TaskModel task = null;
            if(taskRepo.Find(id) == null)
            {
                task = new TaskModel()
                {
                    TaskModelId = 1,
                    Name = "Task1",
                    TaskDone = true
                };
            }
            else
            {
                task = taskRepo.Find(id);
            }
            if(task == null)
            {
                return new HttpNotFoundResult();
            }
            // If Task should change 
            if (task.TaskDone)
            {
                task.TaskDone = false;
                ProgressModel p = progRepo.Find(task.ProgressModelId);
                if(p == null)
                {
                    return new HttpNotFoundResult();
                }
                p.Process -= task.Procent;
                progRepo.InsertOrUpdate(p);
            }
            else
            {
                task.TaskDone = true;
                ProgressModel p = progRepo.Find(task.ProgressModelId);
                if (p == null)
                {
                    return new HttpNotFoundResult();
                }
                p.Process += task.Procent;
                progRepo.InsertOrUpdate(p);
            }

            taskRepo.InsertOrUpdate(task);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(ProgressModel progress)
        {
            if (progress == null)
            {
                throw new Exception("In: ProgressController -> Create");
            }
            else
            {
                progRepo.InsertOrUpdate(progress);
            }

            return RedirectToAction("Index");
        }

        // For Test Purpose
        // Dev Can be deleted
        [HttpPost]
        public ActionResult CreateTask(TaskModel task)
        {
            if (task == null)
            {
                throw new Exception("In: ProgressController -> CreateTask");
            }
            else
            {
                taskRepo.InsertOrUpdate(task);
            }

            return RedirectToAction("Index");
        }
    }
}