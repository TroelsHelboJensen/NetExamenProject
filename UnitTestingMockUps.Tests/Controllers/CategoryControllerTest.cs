using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using UnitTestingMockUps.Models.Entity;
using Moq;
using UnitTestingMockUps.Controllers;
using UnitTestingMockUps.Interface;

namespace UnitTestingMockUps.Tests.Controllers
{
    [TestClass]
    public class CategoryControllerTest
    {
        private Mock<ICategoryRepository<CategoryModel>> _mock;
        private CategoryController _controller;

        [TestInitialize()]
        public void Initialize()
        {
            _mock = new Mock<ICategoryRepository<CategoryModel>>();
            _controller = new CategoryController(_mock.Object);
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
        public void CreateTestGet()
        {
            // Arrange
            // Act
            var result = _controller.Create() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void CreateTestPost()
        {
            // Arrange
            // Adding new Category
            CategoryModel category = new CategoryModel()
            {
                Name = "Test Category",
                CategoryHeaderModelId = 1
            };
            // Act
            var result = _controller.Create(category) as ViewResult;
            // Assert
            _mock.Verify(r => r.InsertOrUpdate(category));
        }

        [TestMethod()]
        public void EditTest()
        {
            // Arrange
            // Adding new Category
            CategoryModel category = new CategoryModel()
            {
                Name = "Test Category",
                CategoryHeaderModelId = 1
            };

            // Act
            _controller.Edit(category);

            // Assert
            _mock.Verify(c => c.InsertOrUpdate(category));
        }
    }
}
