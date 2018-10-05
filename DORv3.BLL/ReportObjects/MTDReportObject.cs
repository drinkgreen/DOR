using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DORv3.BLL.ReportObjects
{
    public class MTDReportObject
    {
        [Display(Name="#")]
        public int rownum { get; set; }
        // public int id { get; set; } 
        //[Display(Name="")]
        //public string deal_id { get; set; }

        [Display(Name="DealerID")]
        public int dealerID { get; set; }

        [Display(Name="Status")]
        public string deal_status { get; set; }

        [Display(Name = "Delv Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}",ApplyFormatInEditMode =true)]
        public string deal_delv_date { get; set; }

        [Display(Name="STK#")]
        public string deal_stck_num { get; set; }

        [Display(Name="MLG")]
        public Nullable<int> deal_mileage { get; set; }

        [Display(Name="Customer")]
        public string deal_customer { get; set; }

        [Display(Name="YR")]
        public Nullable<int> deal_year { get; set; }

        [Display(Name="N/U")]
        public string deal_new_used { get; set; }

        [Display(Name="F&I MGR")]
        public string deal_FIMgr { get; set; }

        [Display(Name="S.PERS")]
        public string deal_sp_1 { get; set; }
        //[Display(Name="")]
        //public string deal_sp_2 { get; set; } 

        [Display(Name="FIN TYPE")]
        public string deal_fin_type { get; set; }

        [Display(Name="T/YR")]
        public Nullable<int> deal_trade_year { get; set; }

        [Display(Name="T/MDL")]
        public string deal_trade_model { get; set; }

        [Display(Name="TITLE")]
        public Nullable<int> deal_title_status { get; set; }

        [Display(Name="ACV")]
        public Nullable<decimal> deal_trade_value { get; set; }

        [Display(Name="DNT$")]
        public Nullable<decimal> deal_dent { get; set; }

        [Display(Name = "WND$")]
        public Nullable<decimal> deal_windsh { get; set; }

        [Display(Name="CL$")]
        public Nullable<decimal> deal_cl { get; set; }

        [Display(Name = "A&H$")]
        public Nullable<decimal> deal_ah { get; set; }

        [Display(Name = "MAP$")]
        public Nullable<decimal> deal_map { get; set; }

        [Display(Name="WAR$")]
        public Nullable<decimal> deal_warr { get; set; }

        [Display(Name="GAP$")]
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public Nullable<decimal> deal_gap { get; set; }

        [Display(Name="Etch$")]
        public Nullable<decimal> deal_etch { get; set; }

        [Display(Name="TIREWHL")]
        public Nullable<decimal> deal_tw { get; set; }

        [Display(Name="ENVR$")]
        public Nullable<decimal> deal_enviro { get; set; }

        [Display(Name="Fin$")]
        public Nullable<decimal> deal_fin { get; set; }

        [Display(Name="FRT END$")]
        public Nullable<decimal> deal_frnt_end { get; set; }

        [Display(Name ="BCK END$")]
        public Nullable<decimal> deal_back_end { get; set; }

        [Display(Name ="TOT$")]
        public Nullable<decimal> deal_tot_tot { get; set; }
    }
}