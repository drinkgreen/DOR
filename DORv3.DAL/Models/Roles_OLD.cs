using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class Roles_OLD
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Comment { get; set; }
        public string AddUser { get; set; }
        public string UpdUser { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public Nullable<System.DateTime> UpdDate { get; set; }
    }
}
