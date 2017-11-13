using AdgisticsShoppingKart.Models;

namespace AdgisticsShoppingKart.Tests.HelperEntities
{
    public class AddItemToShoppingCartJSON
    {
        public ShoppingCartItemViewModel NewModel { get; set; }

        public decimal Total { get; set; }
    }
}