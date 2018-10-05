namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OtherIncome")]
    public partial class OtherIncome
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OtherIncomeId { get; set; }

        public int? OtherProductId { get; set; }

        public int? DealerId { get; set; }

        [StringLength(50)]
        public string PType { get; set; }

        [Column(TypeName = "money")]
        public decimal? PAmount { get; set; }

        [StringLength(50)]
        public string fname1 { get; set; }

        [StringLength(50)]
        public string lname1 { get; set; }

        public DateTime? AdjDate { get; set; }

        public DateTime? SaleDate { get; set; }

        [StringLength(250)]
        public string Reason { get; set; }

        [StringLength(50)]
        public string AddDate { get; set; }

        public DateTime? DisableDate { get; set; }

        [StringLength(50)]
        public string AddUser { get; set; }

        [StringLength(50)]
        public string UpdUser { get; set; }

        public int? DealNum { get; set; }

        [StringLength(50)]
        public string VSCOption { get; set; }

        public int? FinanceManagerId { get; set; }

        public DateTime? UpdDate { get; set; }

        public int? VehicleTypeId { get; set; }

        [StringLength(5)]
        public string OtherType { get; set; }

        public int? VehicleId { get; set; }
    }
}
