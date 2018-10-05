using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class Security
    {
        public int SecurityId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public Nullable<int> DealerShip { get; set; }
        public Nullable<System.DateTime> DisableDate { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public Nullable<System.DateTime> UpdDate { get; set; }
        public string AddUser { get; set; }
        public string UpdUser { get; set; }
    }
}
