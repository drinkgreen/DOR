using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class SalesManager
    {
        public int SMId { get; set; }
        public string SMName { get; set; }
        public Nullable<int> Dealer { get; set; }
        public Nullable<System.DateTime> DisableDate { get; set; }
        public string AddUser { get; set; }
        public string UpdUser { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
    }
}
