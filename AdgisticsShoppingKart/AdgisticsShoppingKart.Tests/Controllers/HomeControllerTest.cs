using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdgisticsShoppingKart;
using AdgisticsShoppingKart.Controllers;

namespace AdgisticsShoppingKart.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.ShoppingCart() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
