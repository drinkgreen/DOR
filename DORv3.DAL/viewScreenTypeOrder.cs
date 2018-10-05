namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viewScreenTypeOrder")]
    public partial class viewScreenTypeOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ScreenId { get; set; }

        [StringLength(100)]
        public string ScreenName { get; set; }

        [StringLength(10)]
        public string ScreenType { get; set; }

        public int? ScreenOrder { get; set; }
    }
}
