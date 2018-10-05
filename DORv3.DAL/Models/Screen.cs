using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class Screen
    {
        public int ScreenId { get; set; }
        public string ScreenName { get; set; }
        public string ScreenType { get; set; }
        public string ScreenASP { get; set; }
        public Nullable<int> ScreenOpt { get; set; }
        public string AddUser { get; set; }
        public string UpdUser { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public Nullable<System.DateTime> UpdDate { get; set; }
        public Nullable<int> ScreenOrder { get; set; }
    }
}
