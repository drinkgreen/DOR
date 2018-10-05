using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DORv3.BLL.ReportObjects
{
    public class SalesRecapReportObject
    {
        [Display(Name = "Dealership")]
        public string dealership { get; set; }
        [Display(Name = "New Cars")]
        public Nullable<int> new_cars { get; set; }
        [Display(Name = "New Trucks")]
        public Nullable<int> new_trucks { get; set; }
        [Display(Name = "New SUVs")]
        public Nullable<int> new_suvs { get; set; }
        [Display(Name = "Used Vehicles")]
        public Nullable<int> used_vehicles { get; set; }
        [Display(Name = "Total Units")]
        public Nullable<int> total_vehicles { get; set; }
        [Display(Name = "Cash Deals")]
        public Nullable<int> cash { get; set; }
        [DisplayFormat(DataFormatString = "{0:0%}")]
        [Display(Name = "Cash Deals %")]
        public Nullable<decimal> cash_per { get; set; }
        [DisplayFormat(DataFormatString = "{0:0;(#)}")]
        [Display(Name = "New Cars /Unit (Cash)")]
        public Nullable<int> nc_cash_per { get; set; }
        [DisplayFormat(DataFormatString = "{0:0;(#)}")]
        [Display(Name = "New Trucks /Unit (Cash)")]
        public Nullable<int> nt_cash_per { get; set; }
        [DisplayFormat(DataFormatString = "{0:0;(#)}")]
        [Display(Name = "New SUVs /Unit (Cash)")]
        public Nullable<int> ns_cash_per { get; set; }
        [DisplayFormat(DataFormatString = "{0:0;(#)}")]
        [Display(Name = "Used Vehicles /Unit (Cash)")]
        public Nullable<int> uv_cash_per { get; set; }
        [Display(Name = "CONV Deals")]
        public Nullable<int> conv { get; set; }
        [DisplayFormat(DataFormatString = "{0:0%}")]
        [Display(Name = "CONV Deals %")]
        public Nullable<decimal> conv_per { get; set; }
        [DisplayFormat(DataFormatString = "{0:0;(#)}")]
        [Display(Name = "New Cars /Unit (Conv)")]
        public Nullable<int> nc_conv_per { get; set; }
        [DisplayFormat(DataFormatString = "{0:0;(#)}")]
        [Display(Name = "New Trucks /Unit (Conv)")]
        public Nullable<int> nt_conv_per { get; set; }
        [DisplayFormat(DataFormatString = "{0:0;(#)}")]
        [Display(Name = "New SUVs /Unit (Conv)")]
        public Nullable<int> ns_conv_per { get; set; }
        [DisplayFormat(DataFormatString = "{0:0;(#)}")]
        [Display(Name = "Used Vehicles /Unit (Conv)")]
        public Nullable<int> uv_conv_per { get; set; }
        [Display(Name = "RBF Deals")]
        public Nullable<int> rbf { get; set; }
        [DisplayFormat(DataFormatString = "{0:0%}")]
        [Display(Name = "RBF Deals %")]
        public Nullable<decimal> rbf_per { get; set; }
        [DisplayFormat(DataFormatString = "{0:0;(#)}")]
        [Display(Name = "New Cars /Unit (RBF)")]
        public Nullable<int> nc_rbf_per { get; set; }
        [DisplayFormat(DataFormatString = "{0:0;(#)}")]
        [Display(Name = "New Trucks /Unit (RBF)")]
        public Nullable<int> nt_rbf_per { get; set; }
        [DisplayFormat(DataFormatString = "{0:0;(#)}")]
        [Display(Name = "New SUVs /Unit (RBF)")]
        public Nullable<int> ns_rbf_per { get; set; }
        [DisplayFormat(DataFormatString = "{0:0;(#)}")]
        [Display(Name = "Used Vehicles /Unit (RBF)")]
        public Nullable<int> uv_rbf_per { get; set; }
        [Display(Name = "OSF Deals")]
        public Nullable<int> osf { get; set; }
        [DisplayFormat(DataFormatString = "{0:0%}")]
        [Display(Name = "OSF Deals %")]
        public Nullable<decimal> osf_per { get; set; }
        [DisplayFormat(DataFormatString = "{0:0;(#)}")]
        [Display(Name = "New Cars /Unit (OSF)")]
        public Nullable<int> nc_osf_per { get; set; }
        [DisplayFormat(DataFormatString = "{0:0;(#)}")]
        [Display(Name = "New Trucks /Unit (OSF)")]
        public Nullable<int> nt_osf_per { get; set; }
        [DisplayFormat(DataFormatString = "{0:0;(#)}")]
        [Display(Name = "New SUVs /Unit (OSF)")]
        public Nullable<int> ns_osf_per { get; set; }
        [DisplayFormat(DataFormatString = "{0:0;(#)}")]
        [Display(Name = "Used Vehicles /Unit (OSF)")]
        public Nullable<int> uv_osf_per { get; set; }
        [Display(Name = "AVE NEW CAR FRONT")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<int> ave_nc_front { get; set; }
        [Display(Name = "AVE NEW TRUCK FRONT")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<int> ave_nt_front { get; set; }
        [Display(Name = "AVE NEW SUV FRONT")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<int> ave_ns_front { get; set; }
        [Display(Name = "AVE NEW VEHICLE FRONT")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<int> ave_nv_front { get; set; }
        [Display(Name = "AVE USED VEHICLE FRONT")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<int> ave_uv_front { get; set; }
        [Display(Name = "AVE NEW CAR BACK")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> ave_nc_back { get; set; }
        [Display(Name = "AVE NEW TRUCK BACK")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> ave_nt_back { get; set; }
        [Display(Name = "AVE NEW SUV BACK")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> ave_ns_back { get; set; }
        [Display(Name = "AVE NEW VEHICLE BACK")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> ave_nv_back { get; set; }
        [Display(Name = "AVE USED VEHICLE BACK")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> ave_uv_back { get; set; }
        [Display(Name = "TOTAL INCOME")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> tot_income { get; set; }
        [Display(Name = "AVG.FRONT")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> avg_front { get; set; }
        [Display(Name = "AVG. F&I GROSS")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> avg_fi_gross { get; set; }
        [Display(Name = "AVG. FRONT & BACK")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<int> avg_f_b { get; set; }
    }
}
