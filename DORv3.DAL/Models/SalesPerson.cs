using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class SalesPerson
    {
        public int ID { get; set; }
        public Nullable<int> SPtoMasterId { get; set; }
        public string SPName { get; set; }
        public Nullable<int> Dealer { get; set; }
        public Nullable<System.DateTime> DisableDate { get; set; }
        public string AddUser { get; set; }
        public string UpdUser { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
    }
}
