namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Screen
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ScreenId { get; set; }

        [StringLength(100)]
        public string ScreenName { get; set; }

        [StringLength(10)]
        public string ScreenType { get; set; }

        [StringLength(50)]
        public string ScreenASP { get; set; }

        public int? ScreenOpt { get; set; }

        [StringLength(50)]
        public string AddUser { get; set; }

        [StringLength(50)]
        public string UpdUser { get; set; }

        public DateTime? AddDate { get; set; }

        public DateTime? UpdDate { get; set; }

        public int? ScreenOrder { get; set; }
    }
}
