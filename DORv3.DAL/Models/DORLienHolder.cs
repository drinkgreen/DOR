using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class DORLienHolder
    {
        public int DORLienHolderId { get; set; }
        public string DORLienHolder1 { get; set; }
        public Nullable<int> Dealer { get; set; }
        public Nullable<System.DateTime> DisableDate { get; set; }
        public string AddUser { get; set; }
        public string UpdUser { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
    }
}
