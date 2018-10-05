namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonthlyHistory")]
    public partial class MonthlyHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MonthlyHistId { get; set; }

        public int? DealerId { get; set; }

        public DateTime? HistDate { get; set; }

        public int? NewCount { get; set; }

        public int? UsedCount { get; set; }

        public int? TotalCount { get; set; }
    }
}
