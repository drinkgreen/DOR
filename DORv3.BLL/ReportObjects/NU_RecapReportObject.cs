﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DORv3.BLL.ReportObjects
{
    public class NU_RecapReportObject
    {
        [Display(Name="Dealership")]
        public string dealer_name { get; set; } [Display(Name="Cash Deals (N)")]
        //public Nullable<int> dealer_id { get; set; } [Display(Name=" ()")]
        public Nullable<int> cash_deals_nv { get; set; } [Display(Name="Cash Deals (U)")]
        public Nullable<int> cash_deals_uv { get; set; } [Display(Name="Cash Deals % (N)")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> cash_deals_per_nv { get; set; } [Display(Name="Cash Deals % (U)")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> cash_deals_per_uv { get; set; } [Display(Name="Per Deal Income-Cash (N)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> per_deal_income_cash_nv { get; set; } [Display(Name="Per Deal Income-Cash (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> per_deal_income_cash_uv { get; set; } [Display(Name="Conv. Deals (N)")]
        public Nullable<int> conv_deals_nv { get; set; } [Display(Name="Conv. Deals (U)")]
        public Nullable<int> conv_deals_uv { get; set; } [Display(Name="Conv Deals % (N")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> conv_deals_per_nv { get; set; } [Display(Name="Conv Deals % (U)")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> conv_deals_per_uv { get; set; } [Display(Name="Per Deal Income-Conv (N")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> per_deal_income_conv_nv { get; set; } [Display(Name="Per Deal Income-Conv (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> per_deal_income_conv_uv { get; set; } [Display(Name="RBF Deals (N")]
        public Nullable<int> RBF_deals_nv { get; set; } [Display(Name="RBF Deals (U)")]
        public Nullable<int> RBF_deals_uv { get; set; } [Display(Name="RBF Deals % (N")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> RBF_deals_per_nv { get; set; } [Display(Name="RBF Deals % (U)")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> RBF_deals_per_uv { get; set; } [Display(Name="Per Deal Income-RBF (N")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> per_deal_income_RBF_nv { get; set; } [Display(Name="Per Deal Income-RBF (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> per_deal_income_RBF_uv { get; set; } [Display(Name="OSF Deals (N")]
        public Nullable<int> OSF_deals_nv { get; set; } [Display(Name="OSF Deals (U)")]
        public Nullable<int> OSF_deals_uv { get; set; } [Display(Name="OSF Deals % (N")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> OSF_deals_per_nv { get; set; } [Display(Name="OSF Deals % (U)")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> OSF_deals_per_uv { get; set; } [Display(Name="Per Deal Income-OSF (N")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> per_deal_income_OSF_nv { get; set; } [Display(Name="Per Deal Income-OSF (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> per_deal_income_OSF_uv { get; set; } [Display(Name="Warranty (N")]
        public Nullable<decimal> warr_nv { get; set; } [Display(Name="Warranty (U)")]
        public Nullable<decimal> warr_uv { get; set; } [Display(Name="Warr Count (N")]
        public Nullable<int> warr_count_nv { get; set; } [Display(Name="Warr Count (U)")]
        public Nullable<int> warr_count_uv { get; set; } [Display(Name="Warr % (N")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> warr_per_nv { get; set; } [Display(Name="Warr % (U)")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> warr_per_uv { get; set; } [Display(Name="Warr Income (N")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> warr_income_nv { get; set; } [Display(Name="Warr Income (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> warr_income_uv { get; set; } [Display(Name="Dent (N")]
        public Nullable<decimal> dent_nv { get; set; } [Display(Name="Dent (U)")]
        public Nullable<decimal> dent_uv { get; set; } [Display(Name="Dent % (N")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> dent_per_nv { get; set; } [Display(Name="Dent % (U)")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> dent_per_uv { get; set; } [Display(Name="Dent Income (N")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> dent_income_nv { get; set; } [Display(Name="Dent Income (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> dent_income_uv { get; set; } [Display(Name="Dent Count (N")]
        public Nullable<int> dent_count_nv { get; set; } [Display(Name="Dent Count (U)")]
        public Nullable<int> dent_count_uv { get; set; } [Display(Name="Maint (N")]
        public Nullable<decimal> maint_nv { get; set; } [Display(Name="Maint (U)")]
        public Nullable<decimal> maint_uv { get; set; } [Display(Name="Maint % (N")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> maint_per_nv { get; set; } [Display(Name="Maint % (U)")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> maint_per_uv { get; set; } [Display(Name="Maint Income (N")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> maint_income_nv { get; set; } [Display(Name="Maint Income (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> maint_income_uv { get; set; } [Display(Name="Maint Count (N")]
        public Nullable<int> maint_count_nv { get; set; } [Display(Name="Maint Count (U)")]
        public Nullable<int> maint_count_uv { get; set; } [Display(Name="Credit Life (N")]
        public Nullable<decimal> cl_nv { get; set; } [Display(Name="Credit Life (U)")]
        public Nullable<decimal> cl_uv { get; set; } [Display(Name="Credit Life % (N")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> cl_per_nv { get; set; } [Display(Name="Credit Life % (U)")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> cl_per_uv { get; set; } [Display(Name="Credit Life Income (N")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> cl_income_nv { get; set; } [Display(Name="Credit Life Income (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> cl_income_uv { get; set; } [Display(Name="Credit Life Count (N")]
        public Nullable<int> cl_count_nv { get; set; } [Display(Name="Credit Life Count (U)")]
        public Nullable<int> cl_count_uv { get; set; } [Display(Name="A&H (N")]
        public Nullable<decimal> ah_nv { get; set; } [Display(Name="A&H (U)")]
        public Nullable<decimal> ah_uv { get; set; } [Display(Name="A&H % (N")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> ah_per_nv { get; set; } [Display(Name="A&H % (U)")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> ah_per_uv { get; set; } [Display(Name="A&H Income (N")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> ah_income_nv { get; set; } [Display(Name="A&H Income (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> ah_income_uv { get; set; } [Display(Name="A&H Count (N")]
        public Nullable<int> ah_count_nv { get; set; } [Display(Name="A&H Count (U)")]
        public Nullable<int> ah_count_uv { get; set; } [Display(Name="Enviro (N")]
        public Nullable<decimal> env_nv { get; set; } [Display(Name="Enviro (U)")]
        public Nullable<decimal> env_uv { get; set; } [Display(Name="Enviro % (N")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> env_per_nv { get; set; } [Display(Name="Enviro % (U)")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> env_per_uv { get; set; } [Display(Name="Enviro Income (N")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> env_income_nv { get; set; } [Display(Name="Enviro Income (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> env_income_uv { get; set; } [Display(Name="Enviro Count (N")]
        public Nullable<int> env_count_nv { get; set; } [Display(Name="Enviro Count (U)")]
        public Nullable<int> env_count_uv { get; set; } [Display(Name="Etch (N")]
        public Nullable<decimal> etch_nv { get; set; } [Display(Name="Etch (U)")]
        public Nullable<decimal> etch_uv { get; set; } [Display(Name="Etch % (N")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> etch_per_nv { get; set; } [Display(Name="Etch % (U)")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> etch_per_uv { get; set; } [Display(Name="Etch Income (N")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> etch_income_nv { get; set; } [Display(Name="Etch Income (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> etch_income_uv { get; set; } [Display(Name="Etch Count (N")]
        public Nullable<int> etch_count_nv { get; set; } [Display(Name="Etch Count (U)")]
        public Nullable<int> etch_count_uv { get; set; } [Display(Name="GAP (N")]
        public Nullable<decimal> gap_nv { get; set; } [Display(Name="GAP (U)")]
        public Nullable<decimal> gap_uv { get; set; } [Display(Name="GAP % (N")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> gap_per_nv { get; set; } [Display(Name="GAP % (U)")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> gap_per_uv { get; set; } [Display(Name="GAP Income (N")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> gap_income_nv { get; set; } [Display(Name="GAP Income (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> gap_income_uv { get; set; } [Display(Name="GAP Count (N")]
        public Nullable<int> gap_count_nv { get; set; } [Display(Name="GAP Count (U)")]
        public Nullable<int> gap_count_uv { get; set; } [Display(Name="TIREWHEEL (N")]
        public Nullable<decimal> tw_nv { get; set; } [Display(Name="TIREWHEEL (U)")]
        public Nullable<decimal> tw_uv { get; set; } [Display(Name="TIREWHEEL % (N")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> tw_per_nv { get; set; } [Display(Name="TIREWHEEL % (U)")]
        [DisplayFormat(DataFormatString = "{0:0%}")]
        public Nullable<double> tw_per_uv { get; set; } [Display(Name="TIREWHEEL Income (N")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> tw_income_nv { get; set; } [Display(Name="TIREWHEEL Income (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> tw_income_uv { get; set; } [Display(Name="TIREWHEEL Count (N")]
        public Nullable<int> tw_count_nv { get; set; } [Display(Name="TIREWHEEL Count (U)")]
        public Nullable<int> tw_count_uv { get; set; } [Display(Name="Cash Income (N")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> cash_tot_nv { get; set; } [Display(Name="Cash Income (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> cash_tot_uv { get; set; } [Display(Name="Conv Income (N")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> conv_tot_nv { get; set; } [Display(Name="Conv Income (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> conv_tot_uv { get; set; } [Display(Name="RBF Income (N")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> rbf_tot_nv { get; set; } [Display(Name="RBF Income (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> rbf_tot_uv { get; set; } [Display(Name="OSF Income (N")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> osf_tot_nv { get; set; } [Display(Name="OSF Income (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> osf_tot_uv { get; set; } [Display(Name="Total Income (N")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> tot_tot_nv { get; set; } [Display(Name="Total Income (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> tot_tot_uv { get; set; } [Display(Name="AVG Front (N")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> avg_fe_nv { get; set; } [Display(Name="AVG Front (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> avg_fe_uv { get; set; } [Display(Name="AVG Back (N")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> avg_be_nv { get; set; } [Display(Name="AVG Back (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<double> avg_be_uv { get; set; } [Display(Name="AVG Total (N")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> avg_tot_nv { get; set; } [Display(Name="AVG Total (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> avg_tot_uv { get; set; }
        [Display(Name="Total Count (N")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<int> tot_vehicle_nv { get; set; }
        [Display(Name="Total Count (U)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<int> tot_vehicle_uv { get; set; } 
    }
}