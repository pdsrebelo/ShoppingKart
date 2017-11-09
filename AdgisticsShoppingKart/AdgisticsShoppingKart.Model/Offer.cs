using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdgisticsShoppingKart.Model
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public decimal Value { get; set; }

        public Item Item { get; set; }
    }
}