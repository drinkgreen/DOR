namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viewUnwindDateFix")]
    public partial class viewUnwindDateFix
    {
        public int? DealerId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DORId { get; set; }

        public int? StatusId { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public DateTime? UnwindDate { get; set; }

        [StringLength(50)]
        public string lname1 { get; set; }

        [StringLength(50)]
        public string AddUser { get; set; }

        [StringLength(50)]
        public string UpdUser { get; set; }

        public DateTime? BackoutDate { get; set; }
    }
}
