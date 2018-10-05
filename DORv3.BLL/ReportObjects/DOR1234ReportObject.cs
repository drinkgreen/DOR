using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DORv3.BLL.ReportObjects
{
    public class DOR1234ReportObject
    {
        public string Dealership { get; set; }
        //public int DealerID { get; set; }
        [Display(Name = "New Vehicles")]
        public Nullable<int> NewVehicles { get; set; }
        [Display(Name = "Used Vehicles")]
        public Nullable<int> UsedVehicles { get; set; }
        [Display(Name = "Total Units")]
        public Nullable<int> TotalVehicles { get; set; }
        [Display(Name = "Cash Deals")]
        public Nullable<int> CashDeals { get; set; }
        [DisplayFormat(DataFormatString = "{0:0%}")]
        [Display(Name = "Cash Deals %")]
        public Nullable<decimal> CashDealsPer { get; set; }
        [Display(Name = "Conv Deals")]
        public Nullable<int> ConvDeals { get; set; }
        [DisplayFormat(DataFormatString = "{0:0%}")]
        [Display(Name = "Conv Deals %")]
        public Nullable<decimal> ConvDealsPer { get; set; }
        [Display(Name = "RBF Deals")]
        public Nullable<int> RBFDeals { get; set; }
        [DisplayFormat(DataFormatString = "{0:0%}")]
        [Display(Name = "RBF Deals %")]
        public Nullable<decimal> RBFDealsPer { get; set; }
        [Display(Name = "OSF Deals")]
        public Nullable<int> OSFDeals { get; set; }
        [DisplayFormat(DataFormatString = "{0:0%}")]
        [Display(Name = "OSF Deals %")]
        public Nullable<decimal> OSFDealsPer { get; set; }
        [Display(Name = "M.A.P.")]
        public Nullable<int> MAP { get; set; }
        public Nullable<int> TOTAL { get; set; }
        public Nullable<int> Travel { get; set; }
        [DisplayFormat(DataFormatString = "{0:0%}")]
        [Display(Name = "Warranties %")]
        public Nullable<decimal> WarrantiesPer { get; set; }
        public Nullable<int> Windsh { get; set; }
        [DisplayFormat(DataFormatString = "{0:0%}")]
        [Display(Name = "Windsh %")]
        public Nullable<decimal> WindshPer { get; set; }
        public Nullable<int> Dent { get; set; }
        public Nullable<double> DentPer { get; set; }
        [Display(Name = "Credit Life")]
        public Nullable<int> CreditLife { get; set; }
        [DisplayFormat(DataFormatString = "{0:0%}")]
        [Display(Name = "Credit Life %")]
        public Nullable<decimal> CreditLifePer { get; set; }
        [Display(Name = "A&H")]
        public Nullable<int> AH { get; set; }
        [DisplayFormat(DataFormatString = "{0:0%}")]
        [Display(Name = "A&H %")]
        public Nullable<decimal> AHPer { get; set; }
        public Nullable<int> Enviro { get; set; }
        [DisplayFormat(DataFormatString = "{0:0%}")]
        [Display(Name = "Enviro %")]
        public Nullable<decimal> EnviroPer { get; set; }
        public Nullable<int> ETCH { get; set; }
        [DisplayFormat(DataFormatString = "{0:0%}")]
        [Display(Name = "Etch %")]
        public Nullable<decimal> ETCHPer { get; set; }
        public Nullable<int> GAP { get; set; }
        [DisplayFormat(DataFormatString ="{0:0%}")]
        [Display(Name = "Gap %")]
        public Nullable<decimal> GAPPer { get; set; }
        public Nullable<int> KEY { get; set; }
        [DisplayFormat(DataFormatString = "{0:0%}")]
        [Display(Name = "Key %")]
        public Nullable<decimal> KEYPer { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name = "Conv Reserve")]
        public decimal? CONVReserve { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name = "Conv Res/Unit")]
        public Nullable<decimal> CONVReserveUNIT { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name = "RBF Reserve")]
        public Nullable<decimal> RBFReserve { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name = "RBF Res/Unit")]
        public Nullable<decimal> RBFReserveUNIT { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name = "Total Reserve")]
        public Nullable<int> TotalReserve { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name = "Total Res/UNIT")]
        public Nullable<int> TotalReserve_Per { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name="Cash Income")]
        public Nullable<decimal> CashIncome { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name = "Conv Income")]
        public Nullable<decimal> ConvIncome { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name = "RBF Income")]
        public Nullable<decimal> RBFIncome { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name = "OSF Income")]
        public Nullable<decimal> OSFIncome { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name = "Total Income")]
        public Nullable<decimal> TotalIncome { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name = "Avg Front")]
        public Nullable<decimal> AvgFront { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name = "AVG F&I Gross")]
        public Nullable<decimal> Avg_FI_Gross { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name = "AVG Front & Back")]
        public Nullable<decimal> Avg_Front_Back { get; set; }

    }
}