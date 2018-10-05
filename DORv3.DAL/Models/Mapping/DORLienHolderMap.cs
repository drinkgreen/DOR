using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class DORLienHolderMap : EntityTypeConfiguration<DORLienHolder>
    {
        public DORLienHolderMap()
        {
            // Primary Key
            this.HasKey(t => t.DORLienHolderId);

            // Properties
            this.Property(t => t.DORLienHolderId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DORLienHolder1)
                .HasMaxLength(100);

            this.Property(t => t.AddUser)
                .HasMaxLength(50);

            this.Property(t => t.UpdUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DORLienHolder");
            this.Property(t => t.DORLienHolderId).HasColumnName("DORLienHolderId");
            this.Property(t => t.DORLienHolder1).HasColumnName("DORLienHolder");
            this.Property(t => t.Dealer).HasColumnName("Dealer");
            this.Property(t => t.DisableDate).HasColumnName("DisableDate");
            this.Property(t => t.AddUser).HasColumnName("AddUser");
            this.Property(t => t.UpdUser).HasColumnName("UpdUser");
            this.Property(t => t.AddDate).HasColumnName("AddDate");
        }
    }
}
