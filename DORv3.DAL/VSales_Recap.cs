namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VSales_Recap
    {
        [Key]
        public int SalesRecapRecordID { get; set; }

        [StringLength(50)]
        public string dealership { get; set; }

        public int? dealer_id { get; set; }

        public int? new_cars { get; set; }

        public int? new_trucks { get; set; }

        public int? new_suvs { get; set; }

        public int? used_vehicles { get; set; }

        public int? total_vehicles { get; set; }

        public int? cash { get; set; }

        public int? nc_cash_per { get; set; }

        public int? nt_cash_per { get; set; }

        public int? ns_cash_per { get; set; }

        public int? uv_cash_per { get; set; }

        public int? conv { get; set; }

        public int? nc_conv_per { get; set; }

        public int? nt_conv_per { get; set; }

        public int? ns_conv_per { get; set; }

        public int? uv_conv_per { get; set; }

        public int? rbf { get; set; }

        public int? nc_rbf_per { get; set; }

        public int? nt_rbf_per { get; set; }

        public int? ns_rbf_per { get; set; }

        public int? uv_rbf_per { get; set; }

        public int? osf { get; set; }

        public int? nc_osf_per { get; set; }

        public int? nt_osf_per { get; set; }

        public int? ns_osf_per { get; set; }

        public int? uv_osf_per { get; set; }

        public int? ave_nc_front { get; set; }

        public int? ave_nt_front { get; set; }

        public int? ave_ns_front { get; set; }

        public int? ave_nv_front { get; set; }

        public int? ave_uv_front { get; set; }

        public int? ave_nc_back { get; set; }

        public int? ave_nt_back { get; set; }

        public int? ave_ns_back { get; set; }

        public int? ave_nv_back { get; set; }

        public int? ave_uv_back { get; set; }

        public int? tot_income { get; set; }

        public int? avg_front { get; set; }

        public int? avg_fi_gross { get; set; }

        public int? avg_f_b { get; set; }
    }
}
