using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdgisticsShoppingKart.Model
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        // TODO: Check whether I need this or not
//        public ICollection<Offer> Offers { get; set; }
    }
}