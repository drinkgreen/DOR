using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class mtd_holder
    {
        public int id { get; set; }
        public string deal_id { get; set; }
        public string deal_status { get; set; }
        public Nullable<System.DateTime> deal_delv_date { get; set; }
        public string deal_stck_num { get; set; }
        public Nullable<int> deal_mileage { get; set; }
        public string deal_customer { get; set; }
        public Nullable<int> deal_year { get; set; }
        public string deal_new_used { get; set; }
        public string deal_FIMgr { get; set; }
        public string deal_sp_1 { get; set; }
        public string deal_sp_2 { get; set; }
        public string deal_fin_type { get; set; }
        public Nullable<int> deal_trade_year { get; set; }
        public string deal_trade_model { get; set; }
        public Nullable<int> deal_title_status { get; set; }
        public Nullable<int> deal_trade_value { get; set; }
        public Nullable<decimal> deal_dent { get; set; }
        public Nullable<decimal> deal_cl { get; set; }
        public Nullable<decimal> deal_warr { get; set; }
        public Nullable<decimal> deal_gap { get; set; }
        public Nullable<decimal> deal_etch { get; set; }
        public Nullable<decimal> deal_tw { get; set; }
        public Nullable<decimal> deal_enviro { get; set; }
        public Nullable<decimal> deal_fin { get; set; }
        public Nullable<decimal> deal_frnt_end { get; set; }
    }
}
