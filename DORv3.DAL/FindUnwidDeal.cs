namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FindUnwidDeal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DORId { get; set; }

        [StringLength(50)]
        public string StockNumber { get; set; }

        public int? DealerId { get; set; }

        [StringLength(50)]
        public string DealNumber { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public DateTime? UnwindDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? payablegross { get; set; }

        [Column(TypeName = "money")]
        public decimal? FinReserve { get; set; }

        [Column(TypeName = "money")]
        public decimal? BEGross { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotGross { get; set; }

        public int? FinanceTypeId { get; set; }
    }
}
