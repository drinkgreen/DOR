namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SalesCategory")]
    public partial class SalesCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SalesCategoryId { get; set; }

        [Column("SalesCategory")]
        [StringLength(50)]
        public string SalesCategoryName { get; set; }

        public DateTime? DisableDate { get; set; }

        [StringLength(50)]
        public string AddUser { get; set; }

        [StringLength(50)]
        public string UpdUser { get; set; }

        public DateTime? AddDate { get; set; }
    }
}
