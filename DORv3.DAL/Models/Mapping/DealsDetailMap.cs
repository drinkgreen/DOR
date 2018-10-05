using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class DealsDetailMap : EntityTypeConfiguration<DealsDetail>
    {
        public DealsDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.DORId);

            // Properties
            this.Property(t => t.DORId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Vehicle)
                .HasMaxLength(50);

            this.Property(t => t.VehicleType)
                .HasMaxLength(50);

            this.Property(t => t.MakeCalc)
                .HasMaxLength(50);

            this.Property(t => t.FinanceType)
                .HasMaxLength(50);

            this.Property(t => t.PName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DealsDetail");
            this.Property(t => t.DORId).HasColumnName("DORId");
            this.Property(t => t.FinanceManagerId).HasColumnName("FinanceManagerId");
            this.Property(t => t.DealerId).HasColumnName("DealerId");
            this.Property(t => t.SaleDate).HasColumnName("SaleDate");
            this.Property(t => t.DeliveryDate).HasColumnName("DeliveryDate");
            this.Property(t => t.Vehicle).HasColumnName("Vehicle");
            this.Property(t => t.VehicleType).HasColumnName("VehicleType");
            this.Property(t => t.MakeCalc).HasColumnName("MakeCalc");
            this.Property(t => t.FinanceType).HasColumnName("FinanceType");
            this.Property(t => t.PName).HasColumnName("PName");
            this.Property(t => t.PAmount).HasColumnName("PAmount");
            this.Property(t => t.Recap).HasColumnName("Recap");
        }
    }
}
