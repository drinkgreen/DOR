using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DORv3.DAL.Models.Mapping
{
    public class DOR_importMap : EntityTypeConfiguration<DOR_import>
    {
        public DOR_importMap()
        {
            // Primary Key
            this.HasKey(t => t.DORId);

            // Properties
            this.Property(t => t.DORId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.fname1)
                .HasMaxLength(50);

            this.Property(t => t.lname1)
                .HasMaxLength(50);

            this.Property(t => t.fname2)
                .HasMaxLength(50);

            this.Property(t => t.lname2)
                .HasMaxLength(50);

            this.Property(t => t.BSOther)
                .HasMaxLength(50);

            this.Property(t => t.TurnOption)
                .HasMaxLength(50);

            this.Property(t => t.DealNumber)
                .HasMaxLength(50);

            this.Property(t => t.StockNumber)
                .HasMaxLength(50);

            this.Property(t => t.Make)
                .HasMaxLength(50);

            this.Property(t => t.MakeOther)
                .HasMaxLength(50);

            this.Property(t => t.Model)
                .HasMaxLength(50);

            this.Property(t => t.ModelOther)
                .HasMaxLength(50);

            this.Property(t => t.Trade1Make)
                .HasMaxLength(50);

            this.Property(t => t.Trade1MakeOther)
                .HasMaxLength(50);

            this.Property(t => t.Trade1Model)
                .HasMaxLength(50);

            this.Property(t => t.Trade1ModelOther)
                .HasMaxLength(50);

            this.Property(t => t.Trade1Intent)
                .HasMaxLength(50);

            this.Property(t => t.Trade1POLHolder)
                .HasMaxLength(50);

            this.Property(t => t.Trade2Make)
                .HasMaxLength(50);

            this.Property(t => t.Trade2MakeOther)
                .HasMaxLength(50);

            this.Property(t => t.Trade2Model)
                .HasMaxLength(50);

            this.Property(t => t.Trade2ModelOther)
                .HasMaxLength(50);

            this.Property(t => t.Trade2Intent)
                .HasMaxLength(50);

            this.Property(t => t.Trade2POLHolder)
                .HasMaxLength(50);

            this.Property(t => t.AddUser)
                .HasMaxLength(50);

            this.Property(t => t.UpdUser)
                .HasMaxLength(50);

            this.Property(t => t.MakeCalc)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DOR_import");
            this.Property(t => t.DORId).HasColumnName("DORId");
            this.Property(t => t.DealerId).HasColumnName("DealerId");
            this.Property(t => t.AddDate).HasColumnName("AddDate");
            this.Property(t => t.UpdDate).HasColumnName("UpdDate");
            this.Property(t => t.fname1).HasColumnName("fname1");
            this.Property(t => t.lname1).HasColumnName("lname1");
            this.Property(t => t.fname2).HasColumnName("fname2");
            this.Property(t => t.lname2).HasColumnName("lname2");
            this.Property(t => t.VehicleId).HasColumnName("VehicleId");
            this.Property(t => t.VehicleTypeId).HasColumnName("VehicleTypeId");
            this.Property(t => t.BSourceId).HasColumnName("BSourceId");
            this.Property(t => t.BSOther).HasColumnName("BSOther");
            this.Property(t => t.SaleCategoryId).HasColumnName("SaleCategoryId");
            this.Property(t => t.StatusId).HasColumnName("StatusId");
            this.Property(t => t.IntentId).HasColumnName("IntentId");
            this.Property(t => t.TurnOption).HasColumnName("TurnOption");
            this.Property(t => t.DealNumber).HasColumnName("DealNumber");
            this.Property(t => t.StockNumber).HasColumnName("StockNumber");
            this.Property(t => t.Make).HasColumnName("Make");
            this.Property(t => t.MakeOther).HasColumnName("MakeOther");
            this.Property(t => t.Model).HasColumnName("Model");
            this.Property(t => t.ModelOther).HasColumnName("ModelOther");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.SaleDate).HasColumnName("SaleDate");
            this.Property(t => t.FEGross).HasColumnName("FEGross");
            this.Property(t => t.Holdback).HasColumnName("Holdback");
            this.Property(t => t.payablegross).HasColumnName("payablegross");
            this.Property(t => t.Trade1).HasColumnName("Trade1");
            this.Property(t => t.Trade1Make).HasColumnName("Trade1Make");
            this.Property(t => t.Trade1MakeOther).HasColumnName("Trade1MakeOther");
            this.Property(t => t.Trade1Model).HasColumnName("Trade1Model");
            this.Property(t => t.Trade1ModelOther).HasColumnName("Trade1ModelOther");
            this.Property(t => t.Trade1Year).HasColumnName("Trade1Year");
            this.Property(t => t.Trade1Intent).HasColumnName("Trade1Intent");
            this.Property(t => t.Trade1Title).HasColumnName("Trade1Title");
            this.Property(t => t.Trade1POLHolder).HasColumnName("Trade1POLHolder");
            this.Property(t => t.Trade1ACV).HasColumnName("Trade1ACV");
            this.Property(t => t.Trade1PayOff).HasColumnName("Trade1PayOff");
            this.Property(t => t.Trade1Equity).HasColumnName("Trade1Equity");
            this.Property(t => t.Trade2).HasColumnName("Trade2");
            this.Property(t => t.Trade2Make).HasColumnName("Trade2Make");
            this.Property(t => t.Trade2MakeOther).HasColumnName("Trade2MakeOther");
            this.Property(t => t.Trade2Model).HasColumnName("Trade2Model");
            this.Property(t => t.Trade2ModelOther).HasColumnName("Trade2ModelOther");
            this.Property(t => t.Trade2Year).HasColumnName("Trade2Year");
            this.Property(t => t.Trade2Intent).HasColumnName("Trade2Intent");
            this.Property(t => t.Trade2Title).HasColumnName("Trade2Title");
            this.Property(t => t.Trade2POLHolder).HasColumnName("Trade2POLHolder");
            this.Property(t => t.Trade2ACV).HasColumnName("Trade2ACV");
            this.Property(t => t.Trade2PayOff).HasColumnName("Trade2PayOff");
            this.Property(t => t.Trade2Equity).HasColumnName("Trade2Equity");
            this.Property(t => t.SaleManagerId).HasColumnName("SaleManagerId");
            this.Property(t => t.SalesPerson1Id).HasColumnName("SalesPerson1Id");
            this.Property(t => t.SalesPerson1Perc).HasColumnName("SalesPerson1Perc");
            this.Property(t => t.SalesPerson2Id).HasColumnName("SalesPerson2Id");
            this.Property(t => t.SalesPerson2Perc).HasColumnName("SalesPerson2Perc");
            this.Property(t => t.FinanceManagerId).HasColumnName("FinanceManagerId");
            this.Property(t => t.FinanceTypeId).HasColumnName("FinanceTypeId");
            this.Property(t => t.PaymentIn).HasColumnName("PaymentIn");
            this.Property(t => t.PaymentOut).HasColumnName("PaymentOut");
            this.Property(t => t.TermIn).HasColumnName("TermIn");
            this.Property(t => t.TermOut).HasColumnName("TermOut");
            this.Property(t => t.CashDown).HasColumnName("CashDown");
            this.Property(t => t.DORLienHolderId).HasColumnName("DORLienHolderId");
            this.Property(t => t.DeliveryDate).HasColumnName("DeliveryDate");
            this.Property(t => t.GradeCreditId).HasColumnName("GradeCreditId");
            this.Property(t => t.AcctDate).HasColumnName("AcctDate");
            this.Property(t => t.BookedDate).HasColumnName("BookedDate");
            this.Property(t => t.TagDate).HasColumnName("TagDate");
            this.Property(t => t.BankDate).HasColumnName("BankDate");
            this.Property(t => t.PaidDate).HasColumnName("PaidDate");
            this.Property(t => t.FinReserve).HasColumnName("FinReserve");
            this.Property(t => t.BEGross).HasColumnName("BEGross");
            this.Property(t => t.TotGross).HasColumnName("TotGross");
            this.Property(t => t.BackoutDate).HasColumnName("BackoutDate");
            this.Property(t => t.UnwindDate).HasColumnName("UnwindDate");
            this.Property(t => t.AddUser).HasColumnName("AddUser");
            this.Property(t => t.UpdUser).HasColumnName("UpdUser");
            this.Property(t => t.MakeCalc).HasColumnName("MakeCalc");
            this.Property(t => t.SalesPerson3Perc).HasColumnName("SalesPerson3Perc");
            this.Property(t => t.SalesPerson3Id).HasColumnName("SalesPerson3Id");
            this.Property(t => t.GradeCredit).HasColumnName("GradeCredit");
            this.Property(t => t.DateToAcct).HasColumnName("DateToAcct");
            this.Property(t => t.Mileage).HasColumnName("Mileage");
            this.Property(t => t.Trade1Mileage).HasColumnName("Trade1Mileage");
            this.Property(t => t.Trade2Mileage).HasColumnName("Trade2Mileage");
            this.Property(t => t.DaysInStock).HasColumnName("DaysInStock");
        }
    }
}
