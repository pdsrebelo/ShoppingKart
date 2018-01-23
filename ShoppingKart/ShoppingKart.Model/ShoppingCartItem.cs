namespace ShoppingKart.Model
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public string ShoppingCartGuid { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}