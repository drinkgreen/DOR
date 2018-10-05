using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class SalesCategory
    {
        public int SalesCategoryId { get; set; }
        public string SalesCategory1 { get; set; }
        public Nullable<System.DateTime> DisableDate { get; set; }
        public string AddUser { get; set; }
        public string UpdUser { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
    }
}
