using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class BUSINESSSOURCE
    {
        public int BusinessSourceID { get; set; }
        public string BusinessSource1 { get; set; }
        public Nullable<System.DateTime> DisableDate { get; set; }
        public string AddUser { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public string UpdateUser { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}
