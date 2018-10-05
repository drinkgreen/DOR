using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class viewDealMap : EntityTypeConfiguration<viewDeal>
    {
        public viewDealMap()
        {
            // Primary Key
            this.HasKey(t => t.DORId);

            // Properties
            this.Property(t => t.DORId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DealNumber)
                .HasMaxLength(50);

            this.Property(t => t.StockNumber)
                .HasMaxLength(50);

            this.Property(t => t.lname1)
                .HasMaxLength(50);

            this.Property(t => t.MakeCalc)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("viewDeal");
            this.Property(t => t.DORId).HasColumnName("DORId");
            this.Property(t => t.DealerId).HasColumnName("DealerId");
            this.Property(t => t.VehicleTypeId).HasColumnName("VehicleTypeId");
            this.Property(t => t.FinanceTypeId).HasColumnName("FinanceTypeId");
            this.Property(t => t.VehicleId).HasColumnName("VehicleId");
            this.Property(t => t.DealNumber).HasColumnName("DealNumber");
            this.Property(t => t.StockNumber).HasColumnName("StockNumber");
            this.Property(t => t.lname1).HasColumnName("lname1");
            this.Property(t => t.StatusId).HasColumnName("StatusId");
            this.Property(t => t.DeliveryDate).HasColumnName("DeliveryDate");
            this.Property(t => t.payablegross).HasColumnName("payablegross");
            this.Property(t => t.BEGross).HasColumnName("BEGross");
            this.Property(t => t.MakeCalc).HasColumnName("MakeCalc");
        }
    }
}
