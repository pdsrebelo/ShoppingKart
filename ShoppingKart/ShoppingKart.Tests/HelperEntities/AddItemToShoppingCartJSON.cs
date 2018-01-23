using ShoppingKart.WebApp.Models;

namespace ShoppingKart.Tests.HelperEntities
{
    public class AddItemToShoppingCartJSON
    {
        public ShoppingCartItemViewModel NewModel { get; set; }

        public decimal Total { get; set; }
    }
}