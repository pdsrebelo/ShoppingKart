using System.Data.Entity;
using AdgisticsShoppingKart.Data.Configurations;
using AdgisticsShoppingKart.Model;

namespace AdgisticsShoppingKart.Data
{
    public class ShoppingKartEntities : DbContext
    {
        public ShoppingKartEntities() : base("ShoppingKartEntities") { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Offer> Offers { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ItemConfiguration());
            modelBuilder.Configurations.Add(new OfferConfiguration());
        }
    }
}
