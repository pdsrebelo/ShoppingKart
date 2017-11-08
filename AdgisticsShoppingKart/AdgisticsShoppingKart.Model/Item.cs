using System.ComponentModel.DataAnnotations;

namespace AdgisticsShoppingKart.Model
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }
    }
}