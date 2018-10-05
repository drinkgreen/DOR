namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BUSINESSSOURCE")]
    public partial class BUSINESSSOURCE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BusinessSourceID { get; set; }

        [Column("BusinessSource")]
        [StringLength(50)]
        public string BusinessSource1 { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? DisableDate { get; set; }

        [StringLength(50)]
        public string AddUser { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? AddDate { get; set; }

        [StringLength(50)]
        public string UpdateUser { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? UpdateDate { get; set; }
    }
}
