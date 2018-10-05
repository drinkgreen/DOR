using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class DORHistory
    {
        public int HistoryDORId { get; set; }
        public Nullable<int> DORId { get; set; }
        public Nullable<int> DealerId { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public string fname1 { get; set; }
        public string lname1 { get; set; }
        public string fname2 { get; set; }
        public string lname2 { get; set; }
        public Nullable<int> VehicleId { get; set; }
        public Nullable<int> VehicleTypeId { get; set; }
        public Nullable<int> BSourceId { get; set; }
        public string BSOther { get; set; }
        public Nullable<int> SaleCategoryId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<int> IntentId { get; set; }
        public string TurnOption { get; set; }
        public string DealNumber { get; set; }
        public string StockNumber { get; set; }
        public string Make { get; set; }
        public string MakeOther { get; set; }
        public string Model { get; set; }
        public string ModelOther { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<System.DateTime> SaleDate { get; set; }
        public Nullable<decimal> FEGross { get; set; }
        public Nullable<decimal> Holdback { get; set; }
        public Nullable<decimal> payablegross { get; set; }
        public Nullable<int> Trade1 { get; set; }
        public string Trade1Make { get; set; }
        public string Trade1MakeOther { get; set; }
        public string Trade1Model { get; set; }
        public string Trade1ModelOther { get; set; }
        public Nullable<int> Trade1Year { get; set; }
        public string Trade1Intent { get; set; }
        public Nullable<int> Trade1Title { get; set; }
        public string Trade1POLHolder { get; set; }
        public Nullable<decimal> Trade1ACV { get; set; }
        public Nullable<decimal> Trade1PayOff { get; set; }
        public Nullable<decimal> Trade1Equity { get; set; }
        public Nullable<int> Trade2 { get; set; }
        public string Trade2Make { get; set; }
        public string Trade2MakeOther { get; set; }
        public string Trade2Model { get; set; }
        public string Trade2ModelOther { get; set; }
        public Nullable<int> Trade2Year { get; set; }
        public string Trade2Intent { get; set; }
        public Nullable<int> Trade2Title { get; set; }
        public string Trade2POLHolder { get; set; }
        public Nullable<decimal> Trade2ACV { get; set; }
        public Nullable<decimal> Trade2PayOff { get; set; }
        public Nullable<decimal> Trade2Equity { get; set; }
        public Nullable<int> SaleManagerId { get; set; }
        public Nullable<int> SalesPerson1Id { get; set; }
        public Nullable<int> SalesPerson1Perc { get; set; }
        public Nullable<int> SalesPerson2Id { get; set; }
        public Nullable<int> SalesPerson2Perc { get; set; }
        public Nullable<int> FinanceManagerId { get; set; }
        public Nullable<int> FinanceTypeId { get; set; }
        public Nullable<decimal> PaymentIn { get; set; }
        public Nullable<decimal> PaymentOut { get; set; }
        public Nullable<int> TermIn { get; set; }
        public Nullable<int> TermOut { get; set; }
        public Nullable<decimal> CashDown { get; set; }
        public Nullable<int> DORLienHolderId { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public Nullable<int> GradeCreditId { get; set; }
        public Nullable<System.DateTime> AcctDate { get; set; }
        public Nullable<System.DateTime> BookedDate { get; set; }
        public Nullable<System.DateTime> TagDate { get; set; }
        public Nullable<System.DateTime> BankDate { get; set; }
        public Nullable<System.DateTime> PaidDate { get; set; }
        public Nullable<decimal> FinReserve { get; set; }
        public Nullable<decimal> BEGross { get; set; }
        public Nullable<decimal> TotGross { get; set; }
        public Nullable<System.DateTime> BackoutDate { get; set; }
        public Nullable<System.DateTime> UnwindDate { get; set; }
        public string AddUser { get; set; }
        public string MakeCalc { get; set; }
        public Nullable<int> SalesPerson3Perc { get; set; }
        public Nullable<int> SalesPerson3Id { get; set; }
        public Nullable<int> GradeCredit { get; set; }
        public Nullable<System.DateTime> DateToAcct { get; set; }
        public Nullable<int> Mileage { get; set; }
        public Nullable<int> Trade1Mileage { get; set; }
        public Nullable<int> Trade2Mileage { get; set; }
    }
}
