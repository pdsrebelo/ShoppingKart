namespace AdgisticsShoppingKart.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public OfferViewModel  OfferView { get; set; }
    }
}