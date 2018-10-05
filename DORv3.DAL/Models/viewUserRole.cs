using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class viewUserRole
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public Nullable<int> DealerShip { get; set; }
        public Nullable<int> RoleId { get; set; }
        public int SecurityId { get; set; }
        public Nullable<System.DateTime> DisableDate { get; set; }
    }
}
