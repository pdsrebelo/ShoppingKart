using System.Collections.Generic;

namespace AdgisticsShoppingKart.Models
{
    public class ShoppingCartViewModel
    {
        public IDictionary<string, ItemViewModel> Items { get; set; }

        public ShoppingCartViewModel()
        {
            Items = new Dictionary<string, ItemViewModel>();
        }
    }
}