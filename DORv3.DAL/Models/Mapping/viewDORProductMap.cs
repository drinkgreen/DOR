using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class viewDORProductMap : EntityTypeConfiguration<viewDORProduct>
    {
        public viewDORProductMap()
        {
            // Primary Key
            this.HasKey(t => t.DORProductId);

            // Properties
            this.Property(t => t.DORProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("viewDORProduct");
            this.Property(t => t.DORProductId).HasColumnName("DORProductId");
            this.Property(t => t.DORId).HasColumnName("DORId");
        }
    }
}
