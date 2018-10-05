using System;
using System.Collections.Generic;

namespace DORv3.DAL
{
    public partial class XRef_UserDealershipRoles
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int DealershipID { get; set; }
        public int RoleID { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
