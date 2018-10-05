using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class DealsbyFinMgrMap : EntityTypeConfiguration<DealsbyFinMgr>
    {
        public DealsbyFinMgrMap()
        {
            // Primary Key
            this.HasKey(t => t.DORId);

            // Properties
            this.Property(t => t.DORId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("DealsbyFinMgr");
            this.Property(t => t.DORId).HasColumnName("DORId");
            this.Property(t => t.StatusId).HasColumnName("StatusId");
            this.Property(t => t.DealerId).HasColumnName("DealerId");
            this.Property(t => t.FinanceManagerId).HasColumnName("FinanceManagerId");
            this.Property(t => t.DeliveryDate).HasColumnName("DeliveryDate");
            this.Property(t => t.BEGross).HasColumnName("BEGross");
        }
    }
}
