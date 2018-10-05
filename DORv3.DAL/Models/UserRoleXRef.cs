using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class UserRoleXRef
    {
        public int RefId { get; set; }
        public Nullable<int> SecurityId { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public Nullable<System.DateTime> UpdDate { get; set; }
        public string AddUser { get; set; }
        public string UpdUser { get; set; }
    }
}
