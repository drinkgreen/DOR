namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DORLienHolder")]
    public partial class DORLienHolder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DORLienHolderId { get; set; }

        [Column("DORLienHolder")]
        [StringLength(100)]
        public string DORLienHolder1 { get; set; }

        public int? Dealer { get; set; }

        public DateTime? DisableDate { get; set; }

        [StringLength(50)]
        public string AddUser { get; set; }

        [StringLength(50)]
        public string UpdUser { get; set; }

        public DateTime? AddDate { get; set; }
    }
}
