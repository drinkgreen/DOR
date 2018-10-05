using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class FinanceTypeMap : EntityTypeConfiguration<FinanceType>
    {
        public FinanceTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.FinanceTypeId);

            // Properties
            this.Property(t => t.FinanceTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FinanceType1)
                .HasMaxLength(50);

            this.Property(t => t.AddUser)
                .HasMaxLength(50);

            this.Property(t => t.UpdUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("FinanceType");
            this.Property(t => t.FinanceTypeId).HasColumnName("FinanceTypeId");
            this.Property(t => t.FinanceType1).HasColumnName("FinanceType");
            this.Property(t => t.DisableDate).HasColumnName("DisableDate");
            this.Property(t => t.AddUser).HasColumnName("AddUser");
            this.Property(t => t.UpdUser).HasColumnName("UpdUser");
            this.Property(t => t.AddDate).HasColumnName("AddDate");
        }
    }
}
