using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class MonthlyHistory
    {
        public int MonthlyHistId { get; set; }
        public Nullable<int> DealerId { get; set; }
        public Nullable<System.DateTime> HistDate { get; set; }
        public Nullable<int> NewCount { get; set; }
        public Nullable<int> UsedCount { get; set; }
        public Nullable<int> TotalCount { get; set; }
    }
}
