using System.Data.Entity.ModelConfiguration;
using ShoppingKart.Model;

namespace ShoppingKart.Data.Configurations
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