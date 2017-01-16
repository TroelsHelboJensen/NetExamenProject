using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingMockUps.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingMockUps.Models.Entity;
using System.Collections;
using System.Collections.ObjectModel;
using Moq;
using System.Web.Mvc;
using UnitTestingMockUps.Interface;

namespace UnitTestingMockUps.Controllers.Tests
{
    [TestClass()]
    public class ProductControllerTests
    {
        private ProductController _controller;
        private Mock<IProductRepository> _mock;

        // Test Constructor
        [TestInitialize]
        public void Initialize()
        {
            // Use of mock simuates the repository 
            // Doc: https://en.wikipedia.org/wiki/Mock_object
            _mock = new Mock<IProductRepository>();
            _controller = new ProductController(_mock.Object);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Arrange And Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        // Create Post Test
        [TestMethod()]
        public void CreateTest()
        {
            // Assign
            ProductModel product = new ProductModel();
            product.Name = "TestProduct";

            // Act
            //_mock.Object.InsertOrUpdate(product); // Done in the Controller
            var result = _controller.Create(product) as ViewResult;

            // Assert
            _mock.Verify(p => p.InsertOrUpdate(product));
        }

        // Delete Product Test
        [TestMethod()]
        public void DeleteTest()
        {
            // Assign
            ProductModel product = new ProductModel();
            product.ProductModelId = 1;
            // Act
            _controller.Delete(product.ProductModelId);
            // Assert
            _mock.Verify(p => p.Delete(product.ProductModelId));
        }
    }
}