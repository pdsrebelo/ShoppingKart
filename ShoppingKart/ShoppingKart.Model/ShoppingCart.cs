using System.Collections.Generic;

namespace ShoppingKart.Model
{
    public class ShoppingCart
    {
        public string Guid { get; set; }

        public virtual ICollection<ShoppingCartItem> Items { get; set; }
    }
}
