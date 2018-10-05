namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Security")]
    public partial class Security
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SecurityId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string UserId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string UserPass { get; set; }

        public int? DealerShip { get; set; }

        public DateTime? DisableDate { get; set; }

        public DateTime? AddDate { get; set; }

        public DateTime? UpdDate { get; set; }

        [StringLength(50)]
        public string AddUser { get; set; }

        [StringLength(50)]
        public string UpdUser { get; set; }
    }
}
