using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class FinanceManagerMap : EntityTypeConfiguration<FinanceManager>
    {
        public FinanceManagerMap()
        {
            // Primary Key
            this.HasKey(t => t.FMId);

            // Properties
            this.Property(t => t.FMId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FMName)
                .HasMaxLength(60);

            this.Property(t => t.AddUser)
                .HasMaxLength(50);

            this.Property(t => t.UpdUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("FinanceManager");
            this.Property(t => t.FMId).HasColumnName("FMId");
            this.Property(t => t.FMName).HasColumnName("FMName");
            this.Property(t => t.Dealer).HasColumnName("Dealer");
            this.Property(t => t.DisableDate).HasColumnName("DisableDate");
            this.Property(t => t.AddUser).HasColumnName("AddUser");
            this.Property(t => t.UpdUser).HasColumnName("UpdUser");
            this.Property(t => t.AddDate).HasColumnName("AddDate");
        }
    }
}
