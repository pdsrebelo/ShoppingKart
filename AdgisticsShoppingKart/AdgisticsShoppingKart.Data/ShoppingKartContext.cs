using System.Data.Entity;
using AdgisticsShoppingKart.Data.Configurations;
using AdgisticsShoppingKart.Model;

namespace AdgisticsShoppingKart.Data
{
    public class ShoppingKartContext : DbContext
    {
        public ShoppingKartContext() : base("ShoppingKartEntities") { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ItemConfiguration());
            modelBuilder.Configurations.Add(new OfferConfiguration());
            modelBuilder.Configurations.Add(new ShoppingCartConfiguration());
            modelBuilder.Configurations.Add(new ShoppingCartItemConfiguration());
        }
    }
}