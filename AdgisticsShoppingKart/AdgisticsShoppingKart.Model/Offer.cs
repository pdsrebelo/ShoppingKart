using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdgisticsShoppingKart.Model
{
    public class Offer
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public decimal Value { get; set; }

        public virtual Item Item { get; set; }
    }
}