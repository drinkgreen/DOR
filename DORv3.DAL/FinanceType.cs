namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FinanceType")]
    public partial class FinanceType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FinanceTypeId { get; set; }

        [Column("FinanceType")]
        [StringLength(50)]
        public string FinanceType1 { get; set; }

        public DateTime? DisableDate { get; set; }

        [StringLength(50)]
        public string AddUser { get; set; }

        [StringLength(50)]
        public string UpdUser { get; set; }

        public DateTime? AddDate { get; set; }
    }
}
