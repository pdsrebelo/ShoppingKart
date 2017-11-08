using System.Web.Mvc;

namespace AdgisticsShoppingKart.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShoppingCart()
        {
            ViewBag.Message = "Your shopping cart.";

            return View();
        }
    }
}