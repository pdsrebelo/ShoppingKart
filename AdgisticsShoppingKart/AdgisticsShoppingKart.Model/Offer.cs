using System.ComponentModel.DataAnnotations.Schema;

namespace AdgisticsShoppingKart.Model
{
    public class Offer
    {
        [ForeignKey(nameof(Item.Id))]
        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}