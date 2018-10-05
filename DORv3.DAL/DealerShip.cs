namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DealerShip")]
    public partial class DealerShip
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DealerID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string DealerName { get; set; }

        public DateTime? DisableDate { get; set; }

        [StringLength(50)]
        public string AddUser { get; set; }

        [StringLength(50)]
        public string UpdUser { get; set; }

        public DateTime? AddDate { get; set; }

        [StringLength(100)]
        public string DefaultMakes { get; set; }

        [StringLength(7)]
        public string RGBColor { get; set; }

        [StringLength(25)]
        public string Color { get; set; }
    }
}
