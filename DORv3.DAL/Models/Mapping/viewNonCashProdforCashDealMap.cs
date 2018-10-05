using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class viewNonCashProdforCashDealMap : EntityTypeConfiguration<viewNonCashProdforCashDeal>
    {
        public viewNonCashProdforCashDealMap()
        {
            // Primary Key
            this.HasKey(t => t.DORId);

            // Properties
            this.Property(t => t.DORId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DealNumber)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("viewNonCashProdforCashDeals");
            this.Property(t => t.DORId).HasColumnName("DORId");
            this.Property(t => t.DealNumber).HasColumnName("DealNumber");
            this.Property(t => t.DealerId).HasColumnName("DealerId");
            this.Property(t => t.StatusId).HasColumnName("StatusId");
            this.Property(t => t.DeliveryDate).HasColumnName("DeliveryDate");
            this.Property(t => t.FinanceTypeId).HasColumnName("FinanceTypeId");
            this.Property(t => t.Recap).HasColumnName("Recap");
            this.Property(t => t.PAmount).HasColumnName("PAmount");
            this.Property(t => t.OtherProductId).HasColumnName("OtherProductId");
        }
    }
}
