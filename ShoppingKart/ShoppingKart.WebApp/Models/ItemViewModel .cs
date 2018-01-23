namespace ShoppingKart.WebApp.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public OfferViewModel  OfferView { get; set; }
    }
}