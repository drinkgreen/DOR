using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class FindUnwidDealMap : EntityTypeConfiguration<FindUnwidDeal>
    {
        public FindUnwidDealMap()
        {
            // Primary Key
            this.HasKey(t => t.DORId);

            // Properties
            this.Property(t => t.DORId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.StockNumber)
                .HasMaxLength(50);

            this.Property(t => t.DealNumber)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("FindUnwidDeals");
            this.Property(t => t.DORId).HasColumnName("DORId");
            this.Property(t => t.StockNumber).HasColumnName("StockNumber");
            this.Property(t => t.DealerId).HasColumnName("DealerId");
            this.Property(t => t.DealNumber).HasColumnName("DealNumber");
            this.Property(t => t.DeliveryDate).HasColumnName("DeliveryDate");
            this.Property(t => t.UnwindDate).HasColumnName("UnwindDate");
            this.Property(t => t.payablegross).HasColumnName("payablegross");
            this.Property(t => t.FinReserve).HasColumnName("FinReserve");
            this.Property(t => t.BEGross).HasColumnName("BEGross");
            this.Property(t => t.TotGross).HasColumnName("TotGross");
            this.Property(t => t.FinanceTypeId).HasColumnName("FinanceTypeId");
        }
    }
}