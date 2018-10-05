using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class DealStatu
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public Nullable<System.DateTime> DisableDate { get; set; }
        public string AddUser { get; set; }
        public string UpdUser { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
    }
}
