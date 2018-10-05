namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DORProduct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DORProductId { get; set; }

        public int? DORId { get; set; }

        public int? OtherProductId { get; set; }

        [StringLength(50)]
        public string PType { get; set; }

        [StringLength(50)]
        public string AddDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? PAmount { get; set; }

        public int? Recap { get; set; }

        [StringLength(50)]
        public string VSCOption { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(50)]
        public string AddUser { get; set; }

        [StringLength(50)]
        public string UpdUser { get; set; }
    }
}
