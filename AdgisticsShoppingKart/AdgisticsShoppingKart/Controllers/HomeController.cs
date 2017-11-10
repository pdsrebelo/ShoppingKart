using System.Collections.Generic;
using System.Linq;
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

        public HomeController()
        {
        }

        public HomeController(IItemService itemService)
        {
            _itemService = itemService;
        }

        public ActionResult Index()
        {
            IEnumerable<Item> items = _itemService.GetItems().ToList();

            IEnumerable<ItemViewModel> modelItems = Mapper.Map<IEnumerable<Item>, IEnumerable<ItemViewModel>>(items);

            return View(modelItems);
        }
    }
}