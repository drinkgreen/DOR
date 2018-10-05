using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class VSales_Recap
    {
        public int SalesRecapRecordID { get; set; }
        public string dealership { get; set; }
        public Nullable<int> dealer_id { get; set; }
        public Nullable<int> new_cars { get; set; }
        public Nullable<int> new_trucks { get; set; }
        public Nullable<int> new_suvs { get; set; }
        public Nullable<int> used_vehicles { get; set; }
        public Nullable<int> total_vehicles { get; set; }
        public Nullable<int> cash { get; set; }
        public Nullable<int> nc_cash_per { get; set; }
        public Nullable<int> nt_cash_per { get; set; }
        public Nullable<int> ns_cash_per { get; set; }
        public Nullable<int> uv_cash_per { get; set; }
        public Nullable<int> conv { get; set; }
        public Nullable<int> nc_conv_per { get; set; }
        public Nullable<int> nt_conv_per { get; set; }
        public Nullable<int> ns_conv_per { get; set; }
        public Nullable<int> uv_conv_per { get; set; }
        public Nullable<int> rbf { get; set; }
        public Nullable<int> nc_rbf_per { get; set; }
        public Nullable<int> nt_rbf_per { get; set; }
        public Nullable<int> ns_rbf_per { get; set; }
        public Nullable<int> uv_rbf_per { get; set; }
        public Nullable<int> osf { get; set; }
        public Nullable<int> nc_osf_per { get; set; }
        public Nullable<int> nt_osf_per { get; set; }
        public Nullable<int> ns_osf_per { get; set; }
        public Nullable<int> uv_osf_per { get; set; }
        public Nullable<int> ave_nc_front { get; set; }
        public Nullable<int> ave_nt_front { get; set; }
        public Nullable<int> ave_ns_front { get; set; }
        public Nullable<int> ave_nv_front { get; set; }
        public Nullable<int> ave_uv_front { get; set; }
        public Nullable<int> ave_nc_back { get; set; }
        public Nullable<int> ave_nt_back { get; set; }
        public Nullable<int> ave_ns_back { get; set; }
        public Nullable<int> ave_nv_back { get; set; }
        public Nullable<int> ave_uv_back { get; set; }
        public Nullable<int> tot_income { get; set; }
        public Nullable<int> avg_front { get; set; }
        public Nullable<int> avg_fi_gross { get; set; }
        public Nullable<int> avg_f_b { get; set; }
    }
}
