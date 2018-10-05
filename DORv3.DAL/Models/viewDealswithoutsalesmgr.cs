using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class viewDealswithoutsalesmgr
    {
        public int DORId { get; set; }
        public Nullable<int> DealerId { get; set; }
        public string DealNumber { get; set; }
        public string StockNumber { get; set; }
        public string lname1 { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public Nullable<int> SaleManagerId { get; set; }
    }
}
