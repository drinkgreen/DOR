using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class DORProductMap : EntityTypeConfiguration<DORProduct>
    {
        public DORProductMap()
        {
            // Primary Key
            this.HasKey(t => t.DORProductId);

            // Properties
            this.Property(t => t.DORProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PType)
                .HasMaxLength(50);

            this.Property(t => t.AddDate)
                .HasMaxLength(50);

            this.Property(t => t.VSCOption)
                .HasMaxLength(50);

            this.Property(t => t.AddUser)
                .HasMaxLength(50);

            this.Property(t => t.UpdUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DORProducts");
            this.Property(t => t.DORProductId).HasColumnName("DORProductId");
            this.Property(t => t.DORId).HasColumnName("DORId");
            this.Property(t => t.OtherProductId).HasColumnName("OtherProductId");
            this.Property(t => t.PType).HasColumnName("PType");
            this.Property(t => t.AddDate).HasColumnName("AddDate");
            this.Property(t => t.PAmount).HasColumnName("PAmount");
            this.Property(t => t.Recap).HasColumnName("Recap");
            this.Property(t => t.VSCOption).HasColumnName("VSCOption");
            this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");
            this.Property(t => t.AddUser).HasColumnName("AddUser");
            this.Property(t => t.UpdUser).HasColumnName("UpdUser");
        }
    }
}
