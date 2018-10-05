using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class SalesCategoryMap : EntityTypeConfiguration<SalesCategory>
    {
        public SalesCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.SalesCategoryId);

            // Properties
            this.Property(t => t.SalesCategoryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SalesCategory1)
                .HasMaxLength(50);

            this.Property(t => t.AddUser)
                .HasMaxLength(50);

            this.Property(t => t.UpdUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SalesCategory");
            this.Property(t => t.SalesCategoryId).HasColumnName("SalesCategoryId");
            this.Property(t => t.SalesCategory1).HasColumnName("SalesCategory");
            this.Property(t => t.DisableDate).HasColumnName("DisableDate");
            this.Property(t => t.AddUser).HasColumnName("AddUser");
            this.Property(t => t.UpdUser).HasColumnName("UpdUser");
            this.Property(t => t.AddDate).HasColumnName("AddDate");
        }
    }
}
