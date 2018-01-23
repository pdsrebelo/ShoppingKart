using System.Data.Entity;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ShoppingKart.Data;
using ShoppingKart.Service.Interfaces;
using ShoppingKart.Tests.HelperEntities;
using ShoppingKart.Tests.IoC;
using ShoppingKart.WebApp.Controllers;
using ShoppingKart.WebApp.Mappings;
using ShoppingKart.WebApp.Models;

namespace ShoppingKart.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest : IoCSupportedTest<BusinessLogicModule>
    {
        private IItemService _itemService;
        private IOfferService _offerService;
        private IShoppingCartService _shoppingCartService;
        private IShoppingCartItemService _shoppingCartItemService;

        [TestInitialize]
        public void Setup()
        {
            // Resolve autofac dependencies
            _itemService = Resolve<IItemService>();
            _offerService = Resolve<IOfferService>();
            _shoppingCartService = Resolve<IShoppingCartService>();
            _shoppingCartItemService = Resolve<IShoppingCartItemService>();

            // Init Database
            Database.SetInitializer(new CreateDatabase());

            // Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }

        [TestCleanup]
        public void TearDown()
        {
            _itemService = null;
            _offerService = null;
            _shoppingCartService = null;
            _shoppingCartItemService = null;
            ShutdownIoC();

            // Cleanup the database
            using (ShoppingKartContext db = new ShoppingKartContext())
            {
                db.Database.Delete();
            }
        }

        [TestMethod]
        public void Index_Test()
        {
            // Arrange
            HomeController controller = new HomeController(_itemService, _offerService, _shoppingCartService, _shoppingCartItemService);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Refresh it again to see if we're given another shopping cart if needed
            result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

            ItemsAndCartViewModel jsonData =
                JsonConvert.DeserializeObject<ItemsAndCartViewModel>(JsonConvert.SerializeObject(result.Model));

            // Check if we have a new shopping cart assigned
            Assert.IsNotNull(jsonData.ShoppingCart);
            Assert.AreEqual(jsonData.Total, 0);
        }

        [TestMethod]
        public void AddItemToTheShoppingCart_Test()
        {
            HomeController controller = new HomeController(_itemService, _offerService, _shoppingCartService, _shoppingCartItemService);

            JsonResult result = controller.AddItemToShoppingCart(new ShoppingCartItemViewModel
            {
                Id = 1,
                Name = "A",
                Quantity = 2
            });

            Assert.IsNotNull(result);

            AddItemToShoppingCartJSON jsonData = 
                JsonConvert.DeserializeObject<AddItemToShoppingCartJSON>(JsonConvert.SerializeObject(result.Data));

            // Check if everything was added correctly
            Assert.AreEqual(jsonData.Total, 10);
            Assert.IsNotNull(jsonData.NewModel);
            Assert.AreEqual(jsonData.NewModel.Id, 1);
            Assert.AreEqual(jsonData.NewModel.Name, "A");
            Assert.AreEqual(jsonData.NewModel.Quantity, 2);
        }

        [TestMethod]
        public void AddItemToTheShoppingCart_Promotion_Test()
        {
            HomeController controller = new HomeController(_itemService, _offerService, _shoppingCartService, _shoppingCartItemService);

            JsonResult result = controller.AddItemToShoppingCart(new ShoppingCartItemViewModel
            {
                Id = 1,
                Name = "A",
                Quantity = 3
            });

            // Assert
            Assert.IsNotNull(result);

            AddItemToShoppingCartJSON jsonData = JsonConvert.DeserializeObject<AddItemToShoppingCartJSON>(JsonConvert.SerializeObject(result.Data));

            // Check if everything was added correctly an the promotion was correctly applied
            Assert.AreEqual(jsonData.Total, 13);
            Assert.IsNotNull(jsonData.NewModel);
            Assert.AreEqual(jsonData.NewModel.Id, 1);
            Assert.AreEqual(jsonData.NewModel.Name, "A");
            Assert.AreEqual(jsonData.NewModel.Quantity, 3);
        }

        [TestMethod]
        public void RemoveFromShoppingCart_Test()
        {
            HomeController controller = new HomeController(_itemService, _offerService, _shoppingCartService, _shoppingCartItemService);

            // Remove without any item in the shopping cart
            JsonResult result = controller.RemoveFromShoppingCart("A");

            // Assert
            Assert.IsNotNull(result);

            RemoveFromShoppingCartJSON jsonData =
                JsonConvert.DeserializeObject<RemoveFromShoppingCartJSON>(JsonConvert.SerializeObject(result.Data));

            // Check if deletetion went as expected
            Assert.AreEqual(jsonData.Total, 0);
            Assert.AreEqual(jsonData.Success, false);

            #region Add Items
            result = controller.AddItemToShoppingCart(new ShoppingCartItemViewModel
            {
                Id = 1,
                Name = "A",
                Quantity = 7
            });
            Assert.IsNotNull(result);
            result = controller.AddItemToShoppingCart(new ShoppingCartItemViewModel
            {
                Id = 2,
                Name = "B",
                Quantity = 2
            });
            Assert.IsNotNull(result);
            #endregion

            // Remove with items in the shopping cart
            result = controller.RemoveFromShoppingCart("A");
            Assert.IsNotNull(result);

            jsonData =
                JsonConvert.DeserializeObject<RemoveFromShoppingCartJSON>(JsonConvert.SerializeObject(result.Data));

            // Check if everything was deleted correctly
            Assert.AreEqual(jsonData.Total, 4.5m);
            Assert.AreEqual(jsonData.Success, true);

            // Remove with items in the shopping cart
            result = controller.RemoveFromShoppingCart("B");
            Assert.IsNotNull(result);

            jsonData =
                JsonConvert.DeserializeObject<RemoveFromShoppingCartJSON>(JsonConvert.SerializeObject(result.Data));

            // Check if everything was deleted correctly
            Assert.AreEqual(jsonData.Total, 0);
            Assert.AreEqual(jsonData.Success, true);
        }
    }
}
