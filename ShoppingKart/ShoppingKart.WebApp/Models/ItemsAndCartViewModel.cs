﻿using System.Collections.Generic;

namespace ShoppingKart.WebApp.Models
{
    public class ItemsAndCartViewModel
    {
        public IEnumerable<ItemViewModel> Items { get; set; }

        public ShoppingCartViewModel ShoppingCart { get; set; }

        public decimal Total { get; set; }
    }
}