using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class BUSINESSSOURCEMap : EntityTypeConfiguration<BUSINESSSOURCE>
    {
        public BUSINESSSOURCEMap()
        {
            // Primary Key
            this.HasKey(t => t.BusinessSourceID);

            // Properties
            this.Property(t => t.BusinessSourceID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.BusinessSource1)
                .HasMaxLength(50);

            this.Property(t => t.AddUser)
                .HasMaxLength(50);

            this.Property(t => t.UpdateUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("BUSINESSSOURCE");
            this.Property(t => t.BusinessSourceID).HasColumnName("BusinessSourceID");
            this.Property(t => t.BusinessSource1).HasColumnName("BusinessSource");
            this.Property(t => t.DisableDate).HasColumnName("DisableDate");
            this.Property(t => t.AddUser).HasColumnName("AddUser");
            this.Property(t => t.AddDate).HasColumnName("AddDate");
            this.Property(t => t.UpdateUser).HasColumnName("UpdateUser");
            this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");
        }
    }
}
