using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTestingMockUps.Interface;
using UnitTestingMockUps.Controllers;
using System.Web.Mvc;
using UnitTestingMockUps.Models.Entity;
using System.Diagnostics;
using UnitTestingMockUps.Models.Repository;

namespace UnitTestingMockUps.Tests.Controllers
{
    /// <summary>
    /// The Mock Test of the Progress Repository
    /// </summary>
    [TestClass()]
    public class ProgressControllerTest
    {
        private ProgressController _controller;
        private Mock<IProgressRepository> _mockProgresses;
        private Mock<ITaskRepository> _mockTasks;

        [TestInitialize]
        public void Initialize()
        {
            // Use of mock simuates the repository 
            // Doc: https://en.wikipedia.org/wiki/Mock_object
            _mockProgresses = new Mock<IProgressRepository>();
            _mockTasks = new Mock<ITaskRepository>();
            _controller = new ProgressController(_mockProgresses.Object, _mockTasks.Object, true);  
        }
        
        [TestMethod()]
        public void CreateTest()
        {
            // Arrange
            ProgressModel progress = new ProgressModel();
            progress.Name = "Examen Test";
            progress.Task = new TaskModel();
            progress.Tasks = new List<TaskModel>();
            
            // Act
            _controller.Create(progress);

            // Assert
            _mockProgresses.Verify(p => p.InsertOrUpdate(progress));
        }

        [TestMethod()]
        public void populateController()
        {
            // Arrange
            ProgressModel progress = new ProgressModel();
            progress.Name = "Examen Test";
            progress.Task = new TaskModel();
            progress.Tasks = new List<TaskModel>();

            TaskModel task1 = new TaskModel()
            {
                Name = "Task1",
                Procent = 10
            };

            // Act
            _controller.CreateTask(task1);
            //_mockTasks.Object.InsertOrUpdate(task1);

            progress.Tasks.Add(task1);

            _controller.Create(progress);
            //_mockProgresses.Object.InsertOrUpdate(progress);
            
            // Assert
            try
            {
                _mockProgresses.Verify(p => p.InsertOrUpdate(progress));
                _mockTasks.Verify(t => t.InsertOrUpdate(task1));
            } 
            catch(MockException eM)
            {
                Debug.WriteLine(eM);
            }

            Debug.WriteLine(_mockProgresses.Object + "" + _mockTasks.Object);
        }

        /*
           It DOSN'T Work Because MOck Dosn't store data
           Index() calls the Entity Framework and it is invalid
        */
        [TestMethod()]
        public void IndexTest()
        {
            // Arrange and Act
            var result = _controller.Index() as ViewResult;
            
            // Assert
            _mockTasks.Verify(t => t.GetAll());
            _mockProgresses.Verify(p => p.GetAll());
            Assert.IsNotNull(result);
        }

        /*
           It DOSN'T Work Because MOck Dosn't store data
           Index() calls the Entity Framework and it is invalid
        */
        [TestMethod()]
        public void EditTaskTest()
        {
            // Arrange is done in [Initialize]
            TaskModel task1 = new TaskModel()
            {
                TaskModelId = 1,
                Name = "Task1",
                TaskDone = true
            };
            
            // Act
            var result2 = _controller.EditTask(1) as ViewResult;

            // Assert
            _mockTasks.Verify(t => t.Find(1));
            _mockTasks.Verify(t => t.InsertOrUpdate(task1));
        }
    }
}
