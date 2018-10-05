using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class SalesManagerMap : EntityTypeConfiguration<SalesManager>
    {
        public SalesManagerMap()
        {
            // Primary Key
            this.HasKey(t => t.SMId);

            // Properties
            this.Property(t => t.SMId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SMName)
                .HasMaxLength(60);

            this.Property(t => t.AddUser)
                .HasMaxLength(50);

            this.Property(t => t.UpdUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SalesManager");
            this.Property(t => t.SMId).HasColumnName("SMId");
            this.Property(t => t.SMName).HasColumnName("SMName");
            this.Property(t => t.Dealer).HasColumnName("Dealer");
            this.Property(t => t.DisableDate).HasColumnName("DisableDate");
            this.Property(t => t.AddUser).HasColumnName("AddUser");
            this.Property(t => t.UpdUser).HasColumnName("UpdUser");
            this.Property(t => t.AddDate).HasColumnName("AddDate");
        }
    }
}
