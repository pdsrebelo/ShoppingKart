using System.Collections.Generic;
using System.Linq;

namespace AdgisticsShoppingKart.Model
{
    public class ShoppingCart
    {
        public string Guid { get; set; }

        public virtual List<ShoppingCartItem> Items { get; set; }
    }
}
