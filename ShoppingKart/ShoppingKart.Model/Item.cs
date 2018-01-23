﻿namespace ShoppingKart.Model
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual Offer Offer { get; set; }
    }
}