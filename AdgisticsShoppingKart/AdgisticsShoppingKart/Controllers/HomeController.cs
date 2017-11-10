using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdgisticsShoppingKart.Model;
using AdgisticsShoppingKart.Models;
using AdgisticsShoppingKart.Service;
using AutoMapper;

namespace AdgisticsShoppingKart.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemService _itemService;
        private HttpCookie _shoppingCartCookie;

        public HomeController()
        {
            _shoppingCartCookie = SetShoppingCartCookie();
        }

        public HomeController(IItemService itemService) : this()
        {
            _itemService = itemService;
        }

        public ActionResult Index()
        {
            // Add the cookie
            Response.Cookies.Add(_shoppingCartCookie);

            IEnumerable<Item> items = _itemService.GetItems().ToList();

            IEnumerable<ItemViewModel> modelItems = Mapper.Map<IEnumerable<Item>, IEnumerable<ItemViewModel>>(items);

            return View(new ItemsAndCartViewModel
            {
                Items = modelItems,
                ShoppingCart = new ShoppingCartViewModel()
            });
        }

        public JsonResult AddItem(string name, int quantity)
        {
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveItem(string name)
        {
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        private HttpCookie SetShoppingCartCookie()
        {
            HttpCookie shoppingCartCookie = new HttpCookie("shoppingCartCookie");
            DateTime now = DateTime.Now;

            // Set the cookie value.
            shoppingCartCookie.Value = now.ToString();

            // Set the cookie expiration date.
            shoppingCartCookie.Expires = now.AddYears(50);

            return shoppingCartCookie;
        }
    }
}