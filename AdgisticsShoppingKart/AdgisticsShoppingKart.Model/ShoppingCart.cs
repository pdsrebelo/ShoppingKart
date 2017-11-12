﻿using System.Collections.Generic;
using System.Linq;

namespace AdgisticsShoppingKart.Model
{
    public class ShoppingCart
    {
        public string Guid { get; set; }

        public virtual List<ShoppingCartItem> Items { get; set; }

        public decimal Total(IEnumerable<Offer> currentOffers)
        {
            if (Items == null || !Items.Any())
                return 0;

            decimal total = 0;

            foreach (var item in Items)
            {
                // Check if there's a promotion for this item

            }

            return total;
        }
    }
}
