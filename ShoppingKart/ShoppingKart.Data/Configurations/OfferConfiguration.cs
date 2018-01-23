using System.Data.Entity.ModelConfiguration;
using ShoppingKart.Model;

namespace ShoppingKart.Data.Configurations
{
    public class OfferConfiguration : EntityTypeConfiguration<Offer>
    {
        public OfferConfiguration()
        {
            ToTable("Offers");

            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
        }
    }
}