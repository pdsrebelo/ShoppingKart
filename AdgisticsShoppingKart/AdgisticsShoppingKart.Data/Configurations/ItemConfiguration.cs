using System.Data.Entity.ModelConfiguration;
using AdgisticsShoppingKart.Model;

namespace AdgisticsShoppingKart.Data.Configurations
{
    public class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
            ToTable("Items");
            Property(c => c.Id).IsRequired();
        }
    }
}