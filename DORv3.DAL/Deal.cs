namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Deal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DORId { get; set; }

        public int? StatusId { get; set; }

        [StringLength(50)]
        public string DealNumber { get; set; }

        public DateTime? AddDate { get; set; }

        public int? DealerId { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [StringLength(50)]
        public string Vehicle { get; set; }

        [StringLength(50)]
        public string VehicleType { get; set; }

        [StringLength(50)]
        public string MakeCalc { get; set; }

        [StringLength(50)]
        public string FinanceType { get; set; }

        [Column(TypeName = "money")]
        public decimal? payablegross { get; set; }

        [Column(TypeName = "money")]
        public decimal? FinReserve { get; set; }
    }
}
