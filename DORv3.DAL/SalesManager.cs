namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SalesManager")]
    public partial class SalesManager
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SMId { get; set; }

        [StringLength(60)]
        public string SMName { get; set; }

        public int? Dealer { get; set; }

        public DateTime? DisableDate { get; set; }

        [StringLength(50)]
        public string AddUser { get; set; }

        [StringLength(50)]
        public string UpdUser { get; set; }

        public DateTime? AddDate { get; set; }
    }
}
