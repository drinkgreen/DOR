using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class viewScreenTypeOrder
    {
        public int ScreenId { get; set; }
        public string ScreenName { get; set; }
        public string ScreenType { get; set; }
        public Nullable<int> ScreenOrder { get; set; }
    }
}
