using System.Collections.Generic;

namespace AdgisticsShoppingKart.Models
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<ShoppingCartItemViewModel> Items { get; set; }

        public ShoppingCartViewModel()
        {
            Items = new List<ShoppingCartItemViewModel>();
        }
    }
}