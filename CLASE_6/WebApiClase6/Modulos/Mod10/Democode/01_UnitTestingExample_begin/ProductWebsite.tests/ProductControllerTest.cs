using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsWebsite.Controllers;
using ProductsWebsite.Models;
using ProductsWebsite.Repositories;
using ProductWebsite.tests.FakeRepositories;
using System.Collections.Generic;

namespace ProductWebsite.tests
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void IndexModelShouldContainAllProducts()
        {
            // Arrange
            IProductRepository fakeProductRepository = new FakeProductRepository();
            var productController = new ProductController(fakeProductRepository);
            // Act
            var viewResult = productController.Index() as ViewResult;
            var products = viewResult.Model as List<Product>;
            // Assert
            Assert.AreEqual(products.Count, 3);
        }

        [TestMethod]
        public void GetProductModelShouldContainTheRightProduct()
        {
            // Arrange
            var fakeProductRepository = new FakeProductRepository();
            var productController = new ProductController(fakeProductRepository);
            // Act
            var viewResult = productController.GetProduct(2) as ViewResult;
            Product product = viewResult.Model as Product;
            // Assert
            Assert.AreEqual(product.Id, 2);
        }


    }
}
