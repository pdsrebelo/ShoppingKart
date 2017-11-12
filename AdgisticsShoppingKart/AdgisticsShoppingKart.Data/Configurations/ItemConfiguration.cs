using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using AdgisticsShoppingKart.Model;

namespace AdgisticsShoppingKart.Data.Configurations
{
    public class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
            ToTable("Items");

            HasKey(c => c.Id);
            Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(c1 => c1.Offer).WithRequiredPrincipal(c2 => c2.Item);
            Property(t => t.Name)
                .HasMaxLength(450)
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(new IndexAttribute("IX_Name")
                    {
                        IsUnique = true
                    }));

        }
    }
}