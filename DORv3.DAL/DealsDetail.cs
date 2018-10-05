namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DealsDetail")]
    public partial class DealsDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DORId { get; set; }

        public int? FinanceManagerId { get; set; }

        public int? DealerId { get; set; }

        public DateTime? SaleDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [StringLength(50)]
        public string Vehicle { get; set; }

        [StringLength(50)]
        public string VehicleType { get; set; }

        [StringLength(50)]
        public string MakeCalc { get; set; }

        [StringLength(50)]
        public string FinanceType { get; set; }

        [StringLength(50)]
        public string PName { get; set; }

        [Column(TypeName = "money")]
        public decimal? PAmount { get; set; }

        public int? Recap { get; set; }
    }
}
