using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class MonthlyHistoryMap : EntityTypeConfiguration<MonthlyHistory>
    {
        public MonthlyHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.MonthlyHistId);

            // Properties
            this.Property(t => t.MonthlyHistId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MonthlyHistory");
            this.Property(t => t.MonthlyHistId).HasColumnName("MonthlyHistId");
            this.Property(t => t.DealerId).HasColumnName("DealerId");
            this.Property(t => t.HistDate).HasColumnName("HistDate");
            this.Property(t => t.NewCount).HasColumnName("NewCount");
            this.Property(t => t.UsedCount).HasColumnName("UsedCount");
            this.Property(t => t.TotalCount).HasColumnName("TotalCount");
        }
    }
}
