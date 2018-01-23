using System.Collections.Generic;

namespace ShoppingKart.WebApp.Models
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