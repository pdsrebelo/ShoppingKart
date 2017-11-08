using System.Data.Entity.ModelConfiguration;
using AdgisticsShoppingKart.Model;

namespace AdgisticsShoppingKart.Data.Configurations
{
    public class OfferConfiguration : EntityTypeConfiguration<Item>
    {
        public OfferConfiguration()
        {
            ToTable("Offers");
            Property(c => c.Id).IsRequired();
        }
    }
}