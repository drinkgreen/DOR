using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class OtherProductMap : EntityTypeConfiguration<OtherProduct>
    {
        public OtherProductMap()
        {
            // Primary Key
            this.HasKey(t => t.OtherProductId);

            // Properties
            this.Property(t => t.OtherProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Product)
                .HasMaxLength(50);

            this.Property(t => t.PName)
                .HasMaxLength(50);

            this.Property(t => t.PType)
                .HasMaxLength(50);

            this.Property(t => t.AddUser)
                .HasMaxLength(50);

            this.Property(t => t.UpdUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("OtherProduct");
            this.Property(t => t.OtherProductId).HasColumnName("OtherProductId");
            this.Property(t => t.Product).HasColumnName("Product");
            this.Property(t => t.PName).HasColumnName("PName");
            this.Property(t => t.PType).HasColumnName("PType");
            this.Property(t => t.POrder).HasColumnName("POrder");
            this.Property(t => t.DisableDate).HasColumnName("DisableDate");
            this.Property(t => t.AddUser).HasColumnName("AddUser");
            this.Property(t => t.UpdUser).HasColumnName("UpdUser");
            this.Property(t => t.AddDate).HasColumnName("AddDate");
        }
    }
}
