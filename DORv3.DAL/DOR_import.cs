namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DOR_import
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DORId { get; set; }

        public int? DealerId { get; set; }

        public DateTime? AddDate { get; set; }

        public DateTime? UpdDate { get; set; }

        [StringLength(50)]
        public string fname1 { get; set; }

        [StringLength(50)]
        public string lname1 { get; set; }

        [StringLength(50)]
        public string fname2 { get; set; }

        [StringLength(50)]
        public string lname2 { get; set; }

        public int? VehicleId { get; set; }

        public int? VehicleTypeId { get; set; }

        public int? BSourceId { get; set; }

        [StringLength(50)]
        public string BSOther { get; set; }

        public int? SaleCategoryId { get; set; }

        public int? StatusId { get; set; }

        public int? IntentId { get; set; }

        [StringLength(50)]
        public string TurnOption { get; set; }

        [StringLength(50)]
        public string DealNumber { get; set; }

        [StringLength(50)]
        public string StockNumber { get; set; }

        [StringLength(50)]
        public string Make { get; set; }

        [StringLength(50)]
        public string MakeOther { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(50)]
        public string ModelOther { get; set; }

        public int? Year { get; set; }

        public DateTime? SaleDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? FEGross { get; set; }

        [Column(TypeName = "money")]
        public decimal? Holdback { get; set; }

        [Column(TypeName = "money")]
        public decimal? payablegross { get; set; }

        public int? Trade1 { get; set; }

        [StringLength(50)]
        public string Trade1Make { get; set; }

        [StringLength(50)]
        public string Trade1MakeOther { get; set; }

        [StringLength(50)]
        public string Trade1Model { get; set; }

        [StringLength(50)]
        public string Trade1ModelOther { get; set; }

        public int? Trade1Year { get; set; }

        [StringLength(50)]
        public string Trade1Intent { get; set; }

        public int? Trade1Title { get; set; }

        [StringLength(50)]
        public string Trade1POLHolder { get; set; }

        [Column(TypeName = "money")]
        public decimal? Trade1ACV { get; set; }

        [Column(TypeName = "money")]
        public decimal? Trade1PayOff { get; set; }

        [Column(TypeName = "money")]
        public decimal? Trade1Equity { get; set; }

        public int? Trade2 { get; set; }

        [StringLength(50)]
        public string Trade2Make { get; set; }

        [StringLength(50)]
        public string Trade2MakeOther { get; set; }

        [StringLength(50)]
        public string Trade2Model { get; set; }

        [StringLength(50)]
        public string Trade2ModelOther { get; set; }

        public int? Trade2Year { get; set; }

        [StringLength(50)]
        public string Trade2Intent { get; set; }

        public int? Trade2Title { get; set; }

        [StringLength(50)]
        public string Trade2POLHolder { get; set; }

        [Column(TypeName = "money")]
        public decimal? Trade2ACV { get; set; }

        [Column(TypeName = "money")]
        public decimal? Trade2PayOff { get; set; }

        [Column(TypeName = "money")]
        public decimal? Trade2Equity { get; set; }

        public int? SaleManagerId { get; set; }

        public int? SalesPerson1Id { get; set; }

        public int? SalesPerson1Perc { get; set; }

        public int? SalesPerson2Id { get; set; }

        public int? SalesPerson2Perc { get; set; }

        public int? FinanceManagerId { get; set; }

        public int? FinanceTypeId { get; set; }

        [Column(TypeName = "money")]
        public decimal? PaymentIn { get; set; }

        [Column(TypeName = "money")]
        public decimal? PaymentOut { get; set; }

        public int? TermIn { get; set; }

        public int? TermOut { get; set; }

        [Column(TypeName = "money")]
        public decimal? CashDown { get; set; }

        public int? DORLienHolderId { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public int? GradeCreditId { get; set; }

        public DateTime? AcctDate { get; set; }

        public DateTime? BookedDate { get; set; }

        public DateTime? TagDate { get; set; }

        public DateTime? BankDate { get; set; }

        public DateTime? PaidDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? FinReserve { get; set; }

        [Column(TypeName = "money")]
        public decimal? BEGross { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotGross { get; set; }

        public DateTime? BackoutDate { get; set; }

        public DateTime? UnwindDate { get; set; }

        [StringLength(50)]
        public string AddUser { get; set; }

        [StringLength(50)]
        public string UpdUser { get; set; }

        [StringLength(50)]
        public string MakeCalc { get; set; }

        public int? SalesPerson3Perc { get; set; }

        public int? SalesPerson3Id { get; set; }

        public int? GradeCredit { get; set; }

        public DateTime? DateToAcct { get; set; }

        public int? Mileage { get; set; }

        public int? Trade1Mileage { get; set; }

        public int? Trade2Mileage { get; set; }
    }
}
