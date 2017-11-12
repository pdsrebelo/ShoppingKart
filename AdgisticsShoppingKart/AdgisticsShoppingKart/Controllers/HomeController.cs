using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AdgisticsShoppingKart.Model;
using AdgisticsShoppingKart.Models;
using AdgisticsShoppingKart.Service.Interfaces;
using AutoMapper;

namespace AdgisticsShoppingKart.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IShoppingCartItemService _shoppingCartItemService;

        public HomeController(IItemService itemService, IShoppingCartService shoppingCartService, IShoppingCartItemService shoppingCartItemService)
        {
            _itemService = itemService;
            _shoppingCartService = shoppingCartService;
            _shoppingCartItemService = shoppingCartItemService;
        }

        public ActionResult Index()
        {
            IEnumerable<Item> items = _itemService.GetItems().ToList();

            IEnumerable<ItemViewModel> modelItems = Mapper.Map<IEnumerable<Item>, IEnumerable<ItemViewModel>>(items);

            // Check if there's a cart for this session
            ShoppingCart shoppingCart = _shoppingCartService.GetShoppingCart(CookieFactory.GetShoppingCartCookie(Request, Response));
            _shoppingCartService.SaveShoppingCart();

            ShoppingCartViewModel cartModel = Mapper.Map<ShoppingCart, ShoppingCartViewModel>(shoppingCart);

            return View(new ItemsAndCartViewModel
            {
                Items = modelItems,
                ShoppingCart = cartModel
            });
        }

        public JsonResult AddItemToShoppingCart(ShoppingCartItemViewModel itemModel)
        {
            // Check if there's a cart for this session
            ShoppingCart shoppingCart = _shoppingCartService.GetShoppingCart(CookieFactory.GetShoppingCartCookie(Request, Response));

            ShoppingCartItem item = Mapper.Map<ShoppingCartItemViewModel, ShoppingCartItem>(itemModel);
            ShoppingCartItem retItem = _shoppingCartItemService.AddOrUpdateShoppingCartItem(item, shoppingCart.Guid);
            _shoppingCartItemService.SaveShoppingCartItem();

            ShoppingCartItemViewModel newModel = Mapper.Map<ShoppingCartItem, ShoppingCartItemViewModel>(retItem);

            return Json(newModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveFromShoppingCart(string name)
        {
            // Check if there's a cart for this session
            ShoppingCart shoppingCart = _shoppingCartService.GetShoppingCart(CookieFactory.GetShoppingCartCookie(Request, Response));

            if (shoppingCart != null)
            {
                bool success = _shoppingCartItemService.DeleteShoppingCartItemByName(name);
                _shoppingCartService.SaveShoppingCart();

                return Json(new { success = success }, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}