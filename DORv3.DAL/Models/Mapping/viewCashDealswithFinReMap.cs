using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class viewCashDealswithFinReMap : EntityTypeConfiguration<viewCashDealswithFinRe>
    {
        public viewCashDealswithFinReMap()
        {
            // Primary Key
            this.HasKey(t => t.DORId);

            // Properties
            this.Property(t => t.DORId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DealNumber)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("viewCashDealswithFinRes");
            this.Property(t => t.DORId).HasColumnName("DORId");
            this.Property(t => t.DealNumber).HasColumnName("DealNumber");
            this.Property(t => t.DealerId).HasColumnName("DealerId");
            this.Property(t => t.FinanceTypeId).HasColumnName("FinanceTypeId");
            this.Property(t => t.FinReserve).HasColumnName("FinReserve");
            this.Property(t => t.DeliveryDate).HasColumnName("DeliveryDate");
        }
    }
}
