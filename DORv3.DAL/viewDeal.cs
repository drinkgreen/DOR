namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viewDeal")]
    public partial class viewDeal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DORId { get; set; }

        public int? DealerId { get; set; }

        public int? VehicleTypeId { get; set; }

        public int? FinanceTypeId { get; set; }

        public int? VehicleId { get; set; }

        [StringLength(50)]
        public string DealNumber { get; set; }

        [StringLength(50)]
        public string StockNumber { get; set; }

        [StringLength(50)]
        public string lname1 { get; set; }

        public int? StatusId { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? payablegross { get; set; }

        [Column(TypeName = "money")]
        public decimal? BEGross { get; set; }

        [StringLength(50)]
        public string MakeCalc { get; set; }
    }
}
