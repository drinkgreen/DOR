namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mtd_holder
    {
        public int id { get; set; }

        [StringLength(20)]
        public string deal_id { get; set; }

        [StringLength(50)]
        public string deal_status { get; set; }

        public DateTime? deal_delv_date { get; set; }

        [StringLength(20)]
        public string deal_stck_num { get; set; }

        public int? deal_mileage { get; set; }

        [StringLength(50)]
        public string deal_customer { get; set; }

        public int? deal_year { get; set; }

        [StringLength(20)]
        public string deal_new_used { get; set; }

        [StringLength(50)]
        public string deal_FIMgr { get; set; }

        [StringLength(60)]
        public string deal_sp_1 { get; set; }

        [StringLength(60)]
        public string deal_sp_2 { get; set; }

        [StringLength(50)]
        public string deal_fin_type { get; set; }

        public int? deal_trade_year { get; set; }

        [StringLength(20)]
        public string deal_trade_model { get; set; }

        public int? deal_title_status { get; set; }

        public int? deal_trade_value { get; set; }

        [Column(TypeName = "money")]
        public decimal? deal_dent { get; set; }

        [Column(TypeName = "money")]
        public decimal? deal_cl { get; set; }

        [Column(TypeName = "money")]
        public decimal? deal_warr { get; set; }

        [Column(TypeName = "money")]
        public decimal? deal_gap { get; set; }

        [Column(TypeName = "money")]
        public decimal? deal_etch { get; set; }

        [Column(TypeName = "money")]
        public decimal? deal_tw { get; set; }

        [Column(TypeName = "money")]
        public decimal? deal_enviro { get; set; }

        [Column(TypeName = "money")]
        public decimal? deal_fin { get; set; }

        [Column(TypeName = "money")]
        public decimal? deal_frnt_end { get; set; }
    }
}
