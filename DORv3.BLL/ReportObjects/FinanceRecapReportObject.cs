using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DORv3.BLL.ReportObjects
{
    public class FinanceRecapReportObject
    {
        [Display(Name = "Dealership")]
        public string dealer_name { get;  set; }
        [Display(Name = "Cash Deals")]
        public Nullable<int> cash_deals { get;  set; }
        [DisplayFormat(DataFormatString = "{0:0%}")]
        [Display(Name = "Cash Deals %")]
        public Nullable<double> cash_deals_per { get;  set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name="Per Deal Income (Cash)")]
        public Nullable<decimal> per_deal_income_cash { get;  set; }
        [Display(Name="Conv Deals")]
        public Nullable<int> conv_deals { get;  set; }
        [DisplayFormat(DataFormatString = "{0:0%}")]
        [Display(Name="Conv Deals %")]
        public Nullable<double> conv_deals_per { get;  set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name="Per Deal Income (Conv)")]
        public Nullable<decimal> per_deal_income_conv { get;  set; }
        [Display(Name="RBF Deals")]
        public Nullable<int> RBF_deals { get;  set; }
        [DisplayFormat(DataFormatString = "{0:0%}")]
        [Display(Name="RBF Deals %")]
        public Nullable<double> RBF_deals_per { get;  set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name="Per Deal Income (RBF)")]
        public Nullable<decimal> per_deal_income_RBF { get;  set; }
        [Display(Name="OSF Deals")]
        public Nullable<int> OSF_deals { get;  set; }
        [DisplayFormat(DataFormatString = "{0:0%}")]
        [Display(Name="OSF Deals %")]
        public Nullable<double> OSF_deals_per { get;  set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name="Per Deal Income (OSF)")]
        public Nullable<decimal> per_deal_income_OSF { get;  set; }
        [Display(Name="Warranties")]
        public Nullable<decimal> warr { get;  set; }
        [Display(Name="Warranties %")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> warr_per { get;  set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name="Per Warr Income")]
        public Nullable<double> warr_income { get;  set; }
        [Display(Name="Warr Count")]
        public Nullable<int> warr_count { get;  set; }
        [Display(Name="Dent")]
        public Nullable<decimal> dent { get;  set; }
        [Display(Name="Dent %")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> dent_per { get;  set; } [Display(Name="Per Dent Income")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> dent_income { get;  set; } [Display(Name="Dent Count")]
        public Nullable<int> dent_count { get;  set; } [Display(Name="Windshield")]
        public Nullable<decimal> maint { get;  set; } [Display(Name="Windsh %")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> maint_per { get;  set; } [Display(Name="Per Windsh Income")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> maint_income { get;  set; } [Display(Name="Windsh Count")]
        public Nullable<int> maint_count { get;  set; } [Display(Name="Credit Life")]
        public Nullable<decimal> cl { get;  set; } [Display(Name="Credit Life %")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> cl_per { get;  set; } [Display(Name="Per Credit Life Income")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> cl_income { get;  set; } [Display(Name="Credit Life Count")]
        public Nullable<int> cl_count { get;  set; } [Display(Name="A&H")]
        public Nullable<decimal> ah { get;  set; } [Display(Name="A&H %")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> ah_per { get;  set; } [Display(Name="A&H Per Income")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> ah_income { get;  set; } [Display(Name="A&H Count")]
        public Nullable<int> ah_count { get;  set; } [Display(Name="Env")]
        public Nullable<decimal> env { get;  set; } [Display(Name="Env %")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> env_per { get;  set; } [Display(Name="Per Env Income")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> env_income { get;  set; } [Display(Name="Env Count")]
        public Nullable<int> env_count { get;  set; } [Display(Name="Etch")]
        public Nullable<decimal> etch { get;  set; } [Display(Name="Etch %")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> etch_per { get;  set; } [Display(Name="Per Etch Income")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> etch_income { get;  set; } [Display(Name="Etch Count")]
        public Nullable<int> etch_count { get;  set; } [Display(Name="GAP")]
        public Nullable<decimal> gap { get;  set; } [Display(Name="GAP %")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> gap_per { get;  set; } [Display(Name="Per GAP Income")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> gap_income { get;  set; } [Display(Name="GAP Count")]
        public Nullable<int> gap_count { get;  set; } [Display(Name="TIREWHEEL")]
        public Nullable<decimal> tw { get;  set; } [Display(Name="TIREWHEEL %")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> tw_per { get;  set; } [Display(Name="Per TIREWHEEL Income ")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> tw_income { get;  set; } [Display(Name="TIREWHEEL Count")]
        public Nullable<int> tw_count { get;  set; } [Display(Name="Cash Income")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> cash_tot { get;  set; } [Display(Name="Conv Income")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> conv_tot { get;  set; } [Display(Name="RBF Income")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> rbf_tot { get;  set; } [Display(Name="OSF Income")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> osf_tot { get;  set; } [Display(Name="Total Income")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> tot_tot { get;  set; } [Display(Name="AVG Front")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> avg_fe { get;  set; } [Display(Name="AVG Back ")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> avg_be { get;  set; } [Display(Name="AVG Total")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> avg_tot { get;  set; } [Display(Name="Total Counts")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<int> tot_vehicle { get;  set; }
    }
}