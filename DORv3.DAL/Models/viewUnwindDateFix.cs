using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class viewUnwindDateFix
    {
        public Nullable<int> DealerId { get; set; }
        public int DORId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public Nullable<System.DateTime> UnwindDate { get; set; }
        public string lname1 { get; set; }
        public string AddUser { get; set; }
        public string UpdUser { get; set; }
        public Nullable<System.DateTime> BackoutDate { get; set; }
    }
}
