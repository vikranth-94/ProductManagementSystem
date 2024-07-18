using Castle.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ProductManagementAPI.Controllers;
using ProductManagementSystem.Models;
using ProductManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementSystem.Tests.Controller
{
    internal class ProductsControllerTests
    {
        private Mock<IProductService> _mockProductService;
        private ProductsController _controller;

        [SetUp]
        public void Setup()
        {
            _mockProductService = new Mock<IProductService>();
            _controller = new ProductsController(_mockProductService.Object);
        }

        [Test]
        public async Task GetAll_ReturnsOkResult_WithListOfProducts()
        {
            var products = new List<Product>
        {
            new Product { Id = 1, Name = "Product test1" },
            new Product { Id = 2, Name = "Product tset2" }
        };
            _mockProductService.Setup(s => s.GetAllProductDetailsAsync()).ReturnsAsync(products);
            var result = await _controller.GetProducts();
            Assert.IsInstanceOf<ActionResult<IEnumerable<Product>>>(result);
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(products, okResult.Value);
        }

        [Test]
        public async Task GetById_ReturnsOkResult_WithProduct()
        {
            var product = new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 10, AvailableStock = 100 };
            _mockProductService.Setup(s => s.GetProductByIdAsync(product.Id)).ReturnsAsync(product);
            var result = await _controller.GetProduct(product.Id);
            Assert.IsInstanceOf<ActionResult<Product>>(result);
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(product, okResult.Value);
        }

        [Test]
        public async Task GetById_ReturnsNotFound_WhenProductDoesNotExist()
        {
            _mockProductService.Setup(s => s.GetProductByIdAsync(It.IsAny<int>())).ReturnsAsync((Product)null);
            var result = await _controller.GetProduct(1);
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

  
    }
}
