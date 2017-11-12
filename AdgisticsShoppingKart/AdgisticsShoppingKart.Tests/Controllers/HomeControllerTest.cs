using System.Web.Mvc;
using AdgisticsShoppingKart.App_Start;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdgisticsShoppingKart.Controllers;
using AdgisticsShoppingKart.Service;
using AdgisticsShoppingKart.Service.Interfaces;

namespace AdgisticsShoppingKart.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private readonly IItemService _itemService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IShoppingCartItemService _shoppingCartItemService;

        public HomeControllerTest(IItemService itemService, IShoppingCartService shoppingCartService, IShoppingCartItemService shoppingCartItemService)
        {
            _itemService = itemService;
            _shoppingCartService = shoppingCartService;
            _shoppingCartItemService = shoppingCartItemService;
        }

        [TestInitialize]
        public void Setup()
        {
            Bootstrapper.Run();
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(_itemService, _shoppingCartService, _shoppingCartItemService);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
