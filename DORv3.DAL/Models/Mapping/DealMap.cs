using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class DealMap : EntityTypeConfiguration<Deal>
    {
        public DealMap()
        {
            // Primary Key
            this.HasKey(t => t.DORId);

            // Properties
            this.Property(t => t.DORId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DealNumber)
                .HasMaxLength(50);

            this.Property(t => t.Vehicle)
                .HasMaxLength(50);

            this.Property(t => t.VehicleType)
                .HasMaxLength(50);

            this.Property(t => t.MakeCalc)
                .HasMaxLength(50);

            this.Property(t => t.FinanceType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Deals");
            this.Property(t => t.DORId).HasColumnName("DORId");
            this.Property(t => t.StatusId).HasColumnName("StatusId");
            this.Property(t => t.DealNumber).HasColumnName("DealNumber");
            this.Property(t => t.AddDate).HasColumnName("AddDate");
            this.Property(t => t.DealerId).HasColumnName("DealerId");
            this.Property(t => t.DeliveryDate).HasColumnName("DeliveryDate");
            this.Property(t => t.Vehicle).HasColumnName("Vehicle");
            this.Property(t => t.VehicleType).HasColumnName("VehicleType");
            this.Property(t => t.MakeCalc).HasColumnName("MakeCalc");
            this.Property(t => t.FinanceType).HasColumnName("FinanceType");
            this.Property(t => t.payablegross).HasColumnName("payablegross");
            this.Property(t => t.FinReserve).HasColumnName("FinReserve");
        }
    }
}
