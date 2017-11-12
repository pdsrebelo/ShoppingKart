using System.Collections.Generic;
using System.Linq;

namespace AdgisticsShoppingKart.Models
{
    public class ItemsAndCartViewModel
    {
        public IEnumerable<ItemViewModel> Items { get; set; }

        public ShoppingCartViewModel ShoppingCart { get; set; }

        public decimal Total { get; set; }
    }
}