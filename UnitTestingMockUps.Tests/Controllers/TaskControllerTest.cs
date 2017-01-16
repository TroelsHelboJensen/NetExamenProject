using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTestingMockUps.Models.Entity;
using UnitTestingMockUps.Interface;
using UnitTestingMockUps.Controllers;
using System.Web.Mvc;

namespace UnitTestingMockUps.Tests.Controllers
{
    [TestClass]
    public class TaskControllerTest
    {
        private Mock<ITaskRepository> _mock;
        private TaskController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _mock = new Mock<ITaskRepository>();
            _controller = new TaskController(_mock.Object);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Arrange and Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Arrange and Act
            TaskModel task = new TaskModel()
            {
                Name = "TestTask",
                Procent = 5,
                TaskDone = false
            };
            // Act
            var result = _controller.Create(task) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
