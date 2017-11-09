using System.ComponentModel.DataAnnotations;

namespace AdgisticsShoppingKart.Model
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public virtual Offer Offer { get; set; }
    }
}