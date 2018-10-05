using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class viewBackoutsDetailMap : EntityTypeConfiguration<viewBackoutsDetail>
    {
        public viewBackoutsDetailMap()
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

            // Table & Column Mappings
            this.ToTable("viewBackoutsDetail");
            this.Property(t => t.DORId).HasColumnName("DORId");
            this.Property(t => t.DealerId).HasColumnName("DealerId");
            this.Property(t => t.AddDate).HasColumnName("AddDate");
            this.Property(t => t.UpdDate).HasColumnName("UpdDate");
            this.Property(t => t.BackoutDate).HasColumnName("BackoutDate");
            this.Property(t => t.SaleDate).HasColumnName("SaleDate");
            this.Property(t => t.DeliveryDate).HasColumnName("DeliveryDate");
            this.Property(t => t.VehicleTypeId).HasColumnName("VehicleTypeId");
            this.Property(t => t.StatusId).HasColumnName("StatusId");
            this.Property(t => t.DealNumber).HasColumnName("DealNumber");
            this.Property(t => t.StockNumber).HasColumnName("StockNumber");
        }
    }
}
