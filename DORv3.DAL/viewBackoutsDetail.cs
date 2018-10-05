namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viewBackoutsDetail")]
    public partial class viewBackoutsDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DORId { get; set; }

        public int? DealerId { get; set; }

        public DateTime? AddDate { get; set; }

        public DateTime? UpdDate { get; set; }

        public DateTime? BackoutDate { get; set; }

        public DateTime? SaleDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public int? VehicleTypeId { get; set; }

        public int? StatusId { get; set; }

        [StringLength(50)]
        public string DealNumber { get; set; }

        [StringLength(50)]
        public string StockNumber { get; set; }
    }
}
