using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class OtherIncomeMap : EntityTypeConfiguration<OtherIncome>
    {
        public OtherIncomeMap()
        {
            // Primary Key
            this.HasKey(t => t.OtherIncomeId);

            // Properties
            this.Property(t => t.OtherIncomeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PType)
                .HasMaxLength(50);

            this.Property(t => t.fname1)
                .HasMaxLength(50);

            this.Property(t => t.lname1)
                .HasMaxLength(50);

            this.Property(t => t.Reason)
                .HasMaxLength(250);

            this.Property(t => t.AddDate)
                .HasMaxLength(50);

            this.Property(t => t.AddUser)
                .HasMaxLength(50);

            this.Property(t => t.UpdUser)
                .HasMaxLength(50);

            this.Property(t => t.VSCOption)
                .HasMaxLength(50);

            this.Property(t => t.OtherType)
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("OtherIncome");
            this.Property(t => t.OtherIncomeId).HasColumnName("OtherIncomeId");
            this.Property(t => t.OtherProductId).HasColumnName("OtherProductId");
            this.Property(t => t.DealerId).HasColumnName("DealerId");
            this.Property(t => t.PType).HasColumnName("PType");
            this.Property(t => t.PAmount).HasColumnName("PAmount");
            this.Property(t => t.fname1).HasColumnName("fname1");
            this.Property(t => t.lname1).HasColumnName("lname1");
            this.Property(t => t.AdjDate).HasColumnName("AdjDate");
            this.Property(t => t.SaleDate).HasColumnName("SaleDate");
            this.Property(t => t.Reason).HasColumnName("Reason");
            this.Property(t => t.AddDate).HasColumnName("AddDate");
            this.Property(t => t.DisableDate).HasColumnName("DisableDate");
            this.Property(t => t.AddUser).HasColumnName("AddUser");
            this.Property(t => t.UpdUser).HasColumnName("UpdUser");
            this.Property(t => t.DealNum).HasColumnName("DealNum");
            this.Property(t => t.VSCOption).HasColumnName("VSCOption");
            this.Property(t => t.FinanceManagerId).HasColumnName("FinanceManagerId");
            this.Property(t => t.UpdDate).HasColumnName("UpdDate");
            this.Property(t => t.VehicleTypeId).HasColumnName("VehicleTypeId");
            this.Property(t => t.OtherType).HasColumnName("OtherType");
            this.Property(t => t.VehicleId).HasColumnName("VehicleId");
        }
    }
}
