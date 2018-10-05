namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserRoleXRef")]
    public partial class UserRoleXRef
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RefId { get; set; }

        public int? SecurityId { get; set; }

        public int? RoleId { get; set; }

        public DateTime? AddDate { get; set; }

        public DateTime? UpdDate { get; set; }

        [StringLength(50)]
        public string AddUser { get; set; }

        [StringLength(50)]
        public string UpdUser { get; set; }
    }
}
