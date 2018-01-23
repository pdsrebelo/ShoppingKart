using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ShoppingKart.Model;
using ShoppingKart.Service.Interfaces;
using ShoppingKart.WebApp.Models;

namespace ShoppingKart.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IOfferService _offerService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IShoppingCartItemService _shoppingCartItemService;

        public HomeController(IItemService itemService, IOfferService offerService, IShoppingCartService shoppingCartService, IShoppingCartItemService shoppingCartItemService)
        {
            _itemService = itemService;
            _offerService = offerService;
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
                ShoppingCart = cartModel,
                Total = _offerService.GetTotal(shoppingCart, items)
            });
        }

        // AJAX: /ShoppingCart/AddItemToShoppingCart/
        public JsonResult AddItemToShoppingCart(ShoppingCartItemViewModel itemModel)
        {
            // Check if there's a cart for this session
            ShoppingCart shoppingCart = _shoppingCartService.GetShoppingCart(CookieFactory.GetShoppingCartCookie(Request, Response));

            ShoppingCartItem item = Mapper.Map<ShoppingCartItemViewModel, ShoppingCartItem>(itemModel);
            ShoppingCartItem retItem = _shoppingCartItemService.AddOrUpdateShoppingCartItem(item, shoppingCart.Guid);
            _shoppingCartItemService.SaveShoppingCartItem();

            ShoppingCartItemViewModel newModel = Mapper.Map<ShoppingCartItem, ShoppingCartItemViewModel>(retItem);

            decimal total = _offerService.GetTotal(shoppingCart, _itemService.GetItems());

            return Json(new { newModel, total = total }, JsonRequestBehavior.AllowGet);
        }

        // AJAX: /ShoppingCart/RemoveFromShoppingCart/
        public JsonResult RemoveFromShoppingCart(string name)
        {
            // Check if there's a cart for this session
            ShoppingCart shoppingCart = _shoppingCartService.GetShoppingCart(CookieFactory.GetShoppingCartCookie(Request, Response));

            if (shoppingCart != null)
            {
                bool success = _shoppingCartItemService.DeleteShoppingCartItemByName(name);
                _shoppingCartService.SaveShoppingCart();

                decimal total = _offerService.GetTotal(shoppingCart, _itemService.GetItems());

                return Json(new { success = success, total = total }, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}