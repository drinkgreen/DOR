namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class viewCashDealswithFinRe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DORId { get; set; }

        [StringLength(50)]
        public string DealNumber { get; set; }

        public int? DealerId { get; set; }

        public int? FinanceTypeId { get; set; }

        [Column(TypeName = "money")]
        public decimal? FinReserve { get; set; }

        public DateTime? DeliveryDate { get; set; }
    }
}
