using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class DORProduct
    {
        public int DORProductId { get; set; }
        public Nullable<int> DORId { get; set; }
        public Nullable<int> OtherProductId { get; set; }
        public string PType { get; set; }
        public string AddDate { get; set; }
        public Nullable<decimal> PAmount { get; set; }
        public Nullable<int> Recap { get; set; }
        public string VSCOption { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string AddUser { get; set; }
        public string UpdUser { get; set; }
    }
}
