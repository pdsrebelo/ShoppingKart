using System.Data.Entity.ModelConfiguration;
using AdgisticsShoppingKart.Model;

namespace AdgisticsShoppingKart.Data.Configurations
{
    public class ShoppingCartItemConfiguration : EntityTypeConfiguration<ShoppingCartItem>
    {
        public ShoppingCartItemConfiguration()
        {
            ToTable("ShoppingCartItems");

            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();

            HasRequired(s => s.ShoppingCart)
                .WithMany(g => g.Items)
                .HasForeignKey(s => s.ShoppingCartGuid)
                .WillCascadeOnDelete();
        }
    }
}