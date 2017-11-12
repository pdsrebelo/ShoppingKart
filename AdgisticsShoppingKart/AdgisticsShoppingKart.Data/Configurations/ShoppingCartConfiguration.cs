using System.Data.Entity.ModelConfiguration;
using AdgisticsShoppingKart.Model;

namespace AdgisticsShoppingKart.Data.Configurations
{
    public class ShoppingCartConfiguration : EntityTypeConfiguration<ShoppingCart>
    {
        public ShoppingCartConfiguration()
        {
            ToTable("ShoppingCarts");

            HasKey(c => c.Guid);
            Property(c => c.Guid).IsRequired();
        }
    }
}