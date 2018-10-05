using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class OtherProduct
    {
        public int OtherProductId { get; set; }
        public string Product { get; set; }
        public string PName { get; set; }
        public string PType { get; set; }
        public Nullable<int> POrder { get; set; }
        public Nullable<System.DateTime> DisableDate { get; set; }
        public string AddUser { get; set; }
        public string UpdUser { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
    }
}
