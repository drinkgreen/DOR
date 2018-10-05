using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class UserRole
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int DealershipID { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; }
        public string EnteredBy { get; set; }
        public System.DateTime EnteredDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
